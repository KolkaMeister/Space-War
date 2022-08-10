using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGroup<TDataType, TItemWidget>
    where TItemWidget : MonoBehaviour, IItemRenderer<TDataType>
{
    protected Transform container;
    protected TItemWidget itemWidget;

    protected List<TItemWidget> createdItems = new List<TItemWidget>();
    public DataGroup(Transform _container, TItemWidget _itemWidget)
    {
        container = _container;
        itemWidget = _itemWidget;
    }

    public virtual void SetData(TDataType[] data)
    {
        for (int i = createdItems.Count; i < data.Length; i++)
        {
            var item = Object.Instantiate<TItemWidget>(itemWidget, container);
            createdItems.Add(item);
        }
        for (int i = 0; i < data.Length; i++)
        {
            createdItems[i].gameObject.SetActive(true);
            createdItems[i].SetData(data[i], i);
        }
        for (int i = data.Length; i < createdItems.Count; i++)
        {
            createdItems[i].gameObject.SetActive(false);
        }
    }

}