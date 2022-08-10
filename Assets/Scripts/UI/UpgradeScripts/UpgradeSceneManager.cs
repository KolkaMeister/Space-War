using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSceneManager : MonoBehaviour
{
    [SerializeField] private StatItemWidget item;
    [SerializeField] private Transform container;

    private DataGroup<StatItem, StatItemWidget> dataGroup;

    private void Start()
    {
        dataGroup = new DataGroup<StatItem, StatItemWidget>(container, item);
        dataGroup.SetData(DefsFacade.I.StatsDef.GetAll());
    }
}
