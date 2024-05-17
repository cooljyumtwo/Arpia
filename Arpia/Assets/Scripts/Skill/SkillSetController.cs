using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;

public class SkillSetController : MonoBehaviour
{ 

    private Animator _animator;

    private readonly int hashAir = Animator.StringToHash("isAction");

    private void Start()
    {
        Debug.Log("Start_SkillSetController");
        // 부모 오브젝트의 Transform을 가져옴

        _animator = GetComponent<Animator>();
    }

    public void SkillClick(int idx)
    {
        Debug.Log("SkillSetController_SkillClick_idx : " + idx);
        switch (idx) 
        {
            case -2:
                _animator.SetBool("isActionMenuOn", true);
                break;
            case -1:
                _animator.SetBool("isActionMagicOn", false);
                break;
            case 0:
                _animator.SetBool("isActionMenuOn", false);
                break;
            case 1:
                _animator.SetBool("isActionMagicOn", true);
                break;
            case 2:
                _animator.SetBool("isActionMenuOn", false);
                break;

        }
    }
}
