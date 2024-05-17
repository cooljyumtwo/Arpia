using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleObject : MonoBehaviour, IPointerClickHandler
{

    [SerializeField]
    GameObject _skillSetPrefebs;

    [SerializeField]
    GameObject _skillSet;

    [SerializeField]
    private bool isEnemy;

    [SerializeField]
    private int _hp = 100;

    [SerializeField]
    private float _coolTime = 0.0f;

    [SerializeField]
    private float _maxCoolTime = 30.0f;



    private void Start()
    {
        Debug.Log("Start_BattleObject");

        Init();
        SetObject();
    }

    private void FixedUpdate()
    {
        _coolTime += Time.deltaTime;
        if (_coolTime > _maxCoolTime)
        {
            if (!isEnemy)
            {
                PlayerAttack();

                _skillSet.SetActive(true);
            }
        }
    }

    void Init() 
    {
        isEnemy = false;

        if (!isEnemy)
            CreateSkillPrefebs();
    }

    void SetObject()
    {

    }
    void CreateSkillPrefebs() 
    {
        // 프리팹 인스턴스화
        GameObject skillSetInstance = Instantiate(_skillSetPrefebs);

        // 인스턴스화된 프리팹을 현재 게임 오브젝트의 자식으로 설정
        skillSetInstance.transform.SetParent(this.transform, false);
        _skillSet = skillSetInstance;
        _skillSet.SetActive(false);
    }

    void PlayerAttack()
    {
        BattleManager.Instance.IsPlayerTurn = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.Instance.ClickObject(gameObject);
        
    }

    public void Hit(int damage)
    {
        _hp += damage;
    }
}
