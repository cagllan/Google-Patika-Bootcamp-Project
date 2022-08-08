using System.Collections.Generic;
using UnityEngine;
using System;

public class TeamVictoryControl : MonoBehaviour
{
    private static TeamVictoryControl _instance;
    public static TeamVictoryControl Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<TeamVictoryControl>();
            }
            return _instance;
        }
    }

    private List<Soldier> _enemies;
    private List<Soldier> _friendlies;

    public Action<ESoldierTeam> OnSoldierTeamWon {get; set;}

    private void Start() 
    {
        _enemies = SoldierProvider.Instance.GetSoldiersBySoldierType(ESoldierTeam.Enemy, true);

        foreach(Soldier enemy in _enemies)
        {
            enemy.GetComponent<Damagable>().OnDied += OnEnemyDied; 
        }

        _friendlies = SoldierProvider.Instance.GetSoldiersBySoldierType(ESoldierTeam.Friendly, true);

        foreach(Soldier friendly in _friendlies)
        {
            friendly.GetComponent<Damagable>().OnDied += OnFriendlyDied; 
        }
    }

    private void OnDestroy() 
    {
        foreach(Soldier enemy in _enemies)
        {
            if(enemy != null)
            {
                enemy.GetComponent<Damagable>().OnDied -= OnEnemyDied; 
            }            
        }

        foreach(Soldier friendly in _friendlies)
        {
            if(friendly != null)
            {
                friendly.GetComponent<Damagable>().OnDied -= OnFriendlyDied;
            }            
        }
    }


    private void OnFriendlyDied(Damagable damagable)
    {
        int friendlyCount = SoldierProvider.Instance.GetSoldiersBySoldierType(ESoldierTeam.Friendly, true).Count;

        if(friendlyCount <= 0)
        { 
            OnSoldierTeamWon?.Invoke(ESoldierTeam.Enemy);
        }
    }

    private void OnEnemyDied(Damagable damagable)
    {
        int enemyCount = SoldierProvider.Instance.GetSoldiersBySoldierType(ESoldierTeam.Enemy, true).Count;

        if(enemyCount <= 0)
        { 
            OnSoldierTeamWon?.Invoke(ESoldierTeam.Friendly);
        }
    }

}
