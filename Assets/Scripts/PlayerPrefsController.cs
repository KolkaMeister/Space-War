using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string POINTS_KEY = "points";
    const string PLAYER_MAX_HEALTH_KEY = "player max health";

    public static event Action<string> onStatsChanged;
    public static void AddPoints(int value)
    {
        int valueAdd = PlayerPrefs.GetInt(POINTS_KEY) + value;
        PlayerPrefs.SetInt(POINTS_KEY, valueAdd);
    }
    public static int GetPoints()
    {
        return PlayerPrefs.GetInt(POINTS_KEY);
    }
    public static void SpendPoints(int value)
    {
        var remained = PlayerPrefs.GetInt(POINTS_KEY) - value;
        PlayerPrefs.SetInt(POINTS_KEY, remained);
    }

    public static void AddPlayerMaxHeathl(int value)
    {
        int valueAdd = PlayerPrefs.GetInt(PLAYER_MAX_HEALTH_KEY) + value;
        PlayerPrefs.SetInt(PLAYER_MAX_HEALTH_KEY, valueAdd);
    }
    public static int GetPlayerMaxHeathl()
    {
        return PlayerPrefs.GetInt(PLAYER_MAX_HEALTH_KEY);
    }
    public static int GetStatLevel(string id)
    {
        return PlayerPrefs.GetInt(id);
    }
    private static void SetStatLevel(string id, int level)
    {
        PlayerPrefs.SetInt(id, level);
    }
    public static void UpgradeStat(string id)
    {
        var statItem = DefsFacade.I.StatsDef.Get(id);
        var currentStatLevel = GetStatLevel(id);
        if (currentStatLevel >= statItem.MaxLevel) return;

        var currentPoints = GetPoints();
        if (currentPoints < statItem.LevelDatas[currentStatLevel + 1].Cost) return;

        SetStatLevel(id, GetStatLevel(id) + 1);
        onStatsChanged?.Invoke(id);
    }
}
