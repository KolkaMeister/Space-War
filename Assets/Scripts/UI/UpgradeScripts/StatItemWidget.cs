using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatItemWidget : MonoBehaviour,IItemRenderer<StatItem>
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text currentValue;
    [SerializeField] private TMP_Text upgradeValue;
    [SerializeField] private Button upgradeButton;

    private StatItem data;

    public void SetData(StatItem _data,int index)
    {
        data = _data;
        icon.sprite = data.Icon;
        PlayerPrefsController.onStatsChanged += OnStatsChanged;
        OnStatsChanged(data.Id);
    }
    private void OnStatsChanged(string id)
    {
        if (id != data.Id) return;
        var statLevel = PlayerPrefsController.GetStatLevel(data.Id);
        currentValue.text = data.LevelDatas[statLevel].Value.ToString();
        if (statLevel>=data.MaxLevel)
        {
            upgradeButton.gameObject.SetActive(false);
            upgradeValue.text = "MAX";
        }
        else
        {
            upgradeButton.gameObject.SetActive(true);
            upgradeValue.text = data.LevelDatas[statLevel + 1].Cost.ToString();
        }
    }
    public void OnClick()
    {
        PlayerPrefsController.UpgradeStat(data.Id);
    }
    private void OnDestroy()
    {
        PlayerPrefsController.onStatsChanged -= OnStatsChanged;
    }
}
