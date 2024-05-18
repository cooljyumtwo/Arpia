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

        // �ڽ� ������Ʈ�鿡�� EventTrigger �߰�
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
            // EventTrigger ������Ʈ �߰�
            EventTrigger trigger = child.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry entry = new EventTrigger.Entry
            {
                eventID = EventTriggerType.PointerClick
            };

            // Ŭ�� �̺�Ʈ�� �߻��ϸ� OnChildClick ȣ��
            entry.callback.AddListener((data) => { OnChildClick(child); });

            trigger.triggers.Add(entry);

            // ���� child�� ��� �ڽĵ鿡�� ��������� ȣ��
            AddEventTriggersRecursively(child);
        }
    }

    private void OnChildClick(Transform child)
    {
        // ���� ���� �θ� ������Ʈ�� ã�Ƽ� �̺�Ʈ ó��
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
