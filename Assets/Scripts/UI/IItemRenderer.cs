using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public interface  IItemRenderer<TDataType> 
{
    public void SetData(TDataType _data,int index);

}
