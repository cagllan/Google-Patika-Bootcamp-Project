using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleStartController : MonoBehaviour
{
    private static BattleStartController _instance;
    public static BattleStartController Instance 
    { 
        get 
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<BattleStartController>();
            }
            return _instance;
        } 
    }

    // Event
    public Action OnStartBattle { get; set; }

    public void StartBattle()
    {
        SoldierProvider.Instance.GetSoldiers();
        OnStartBattle?.Invoke();
    }
}
