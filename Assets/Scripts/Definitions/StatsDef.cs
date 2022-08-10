using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Defs/StatDef", fileName = "StatDef")]
public class StatsDef : ScriptableObject
{
    [SerializeField] private StatItem[] statItems;

    public StatItem Get(string id)
    {
        foreach (var item in statItems)
        {
            if (item.Id==id)
            {
                return item;
            }
        }
        return default;
    }

    public StatItem[] GetAll()
    {
        return statItems;
    }
}


[Serializable]
public struct StatItem
{
    [SerializeField] private string id;
    [SerializeField] private Sprite icon;
    [SerializeField] private StatLevelData[] levelDatas;

    public int MaxLevel => levelDatas.Length - 1;
    public string Id => id;

    public Sprite Icon => icon;

    public StatLevelData[] LevelDatas => levelDatas;
}

[Serializable]

public struct StatLevelData
{ 
    [SerializeField] private int value;
    [SerializeField] private int cost;

    public int Value => value;

    public int Cost => cost;
}

