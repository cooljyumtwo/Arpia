using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    [SerializeField]
    private List<GameObject> _teamObjects = new List<GameObject>();

    [SerializeField]
    private List<GameObject> _enemyObjects = new List<GameObject>();

    [SerializeField]
    private bool _isPlayerTurn = false;

    [SerializeField]
    private GameObject _playerAttackTarget;

    public bool IsPlayerTurn
    {
        get { return _isPlayerTurn; }
        set { _isPlayerTurn = value; }
    }

    private void Awake()
    {
        Instance = this;

        CreateBattleObject();
    }

    private void FixedUpdate()
    {
        PlayerTurn();
    }
    private void CreateBattleObject()
    {
        GameObject team = GameObject.Find("Team");
        if (team != null)
        {
            for (int i = 0; i < team.transform.childCount; i++)
            {
                GameObject child = team.transform.GetChild(i).gameObject;
                _teamObjects.Add(child);
            }
        }
        else
        {
            Debug.LogError("Team GameObject를 찾을 수 없습니다.");
        }

        GameObject enemy = GameObject.Find("Enemy");
        if (team != null)
        {
            for (int i = 0; i < enemy.transform.childCount; i++)
            {
                GameObject child = enemy.transform.GetChild(i).gameObject;
                _enemyObjects.Add(child);
            }
        }
        else
        {
            Debug.LogError("Enemy GameObject를 찾을 수 없습니다.");
        }
    }

    private void PlayerTurn()
    {
        if (!_isPlayerTurn) return;
      //  _playerAttackTarget = _enemyObjects[0];
    }

    public void ClickObject(GameObject clickedEnemy)
    {
        Debug.Log(clickedEnemy.name + "가 클릭되었습니다.");
        // 추가적인 처리 로직을 여기에 작성
        if (!_isPlayerTurn) return;
        if (_playerAttackTarget == clickedEnemy)
        {
            Debug.Log(clickedEnemy.name + "Hit!");
            _playerAttackTarget.GetComponent<BattleObject>().Hit(-10);
            _playerAttackTarget.transform.GetChild(1).gameObject.SetActive(false);
            _playerAttackTarget = null;


        }
        else
        {
            _playerAttackTarget.transform.GetChild(1).gameObject.SetActive(false);
            _playerAttackTarget = clickedEnemy;
            _playerAttackTarget.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
