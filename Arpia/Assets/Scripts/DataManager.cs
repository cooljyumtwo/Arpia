using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public struct MonsterData 
{
    public int Key;
    public string Name;
    public float Hp;
    public float Power;
}
public class DataManager : Singleton<DataManager>
{
    private Dictionary<int, MonsterData> monsterDatas = new Dictionary<int, MonsterData>();
    private void Awake()
    {
        LoadData();
    }

    public MonsterData GetMonsterData(int key) { return monsterDatas[key]; }

    public void LoadData()
    {
        LoadMonsterData();
    }
    private void LoadMonsterData() 
    {
        TextAsset textAsset = Resources.Load<TextAsset>("TextData/MonsterData");

        string temp = textAsset.text.Replace("\r\n","\n");
        string[] str = textAsset.text.Split("\n");

        for (int i = 1; i < str.Length; i++)
        {
            string[] data = str[i].Split(',');

            MonsterData dataMonster;
            dataMonster.Key = int.Parse(data[0]);
            dataMonster.Name = data[1];
            dataMonster.Hp = float.Parse(data[2]);
            dataMonster.Power = float.Parse(data[3]);

            monsterDatas.Add(dataMonster.Key, dataMonster);
        }
    }
}
