using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Defs/DefsFacade", fileName = "DefsFacade")]
public class DefsFacade : ScriptableObject
{
    [SerializeField] public StatsDef statsDef;

    public StatsDef StatsDef => statsDef;

    private static DefsFacade instance;
    public static DefsFacade I => instance ? instance : instance = Resources.Load<DefsFacade>("Defs/DefsFacade");

}
