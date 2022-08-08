using UnityEngine;
using System;

public abstract class SoldierTargetProviderBase : MonoBehaviour
{
    public abstract Action<Soldier> OnSoldierUpdated {get; set;}
    public abstract Action OnNoTargetSoldierFound {get;set;}    
    public abstract Soldier GetTargetSoldier();
}
