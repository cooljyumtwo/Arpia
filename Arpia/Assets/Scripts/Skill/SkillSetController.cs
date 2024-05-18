using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillSetController : MonoBehaviour
{
    private Animator _animator;

    private readonly int hashAir = Animator.StringToHash("isAction");

    private void Start()
    {
        Debug.Log("Start_SkillSetController");

        _animator = GetComponent<Animator>();

        // 자식 오브젝트들에게 EventTrigger 추가
        AddEventTriggersToChildren();
    }

    private void AddEventTriggersToChildren()
    {
        AddEventTriggersRecursively(transform);
    }

    private void AddEventTriggersRecursively(Transform parent)
    {
        foreach (Transform child in parent)
        {
            // EventTrigger 컴포넌트 추가
            EventTrigger trigger = child.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerClick
            };

            // 클릭 이벤트가 발생하면 OnChildClick 호출
            entry.callback.AddListener((data) => { OnChildClick(child); });

            trigger.triggers.Add(entry);

            // 현재 child의 모든 자식들에게 재귀적으로 호출
            AddEventTriggersRecursively(child);
        }
    }

    private void OnChildClick(Transform child)
    {
        // 가장 상위 부모 오브젝트를 찾아서 이벤트 처리
        SkillSetController parentController = child.root.GetComponent<SkillSetController>();

        if (parentController != null)
        {
            parentController.HandleChildClick(child.gameObject.name);
        }
    }

    private void HandleChildClick(string childName)
    {
        Debug.Log("SkillSetController_HandleChildClick_childName : " + childName);
        switch (childName)
        {
            case "Attack":
                _animator.SetBool("isActionMenuOn", false);
                break;
            case "Magic":
                _animator.SetBool("isActionMagicOn", true);
                break;
            case "Cancel":
                _animator.SetBool("isActionMenuOn", true);
                break;
            case "Back":
                _animator.SetBool("isActionMagicOn", false);
                break;
            case "Fire":
                _animator.SetBool("isSpellFire", true);
                break;
            case "BackFire":
                _animator.SetBool("isSpellFire", false);
                break;
            default:
                Debug.LogWarning("Unknown child name: " + childName);
                break;
        }
    }
}
