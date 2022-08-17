using System.Collections.Generic;
using UnityEngine;
using System;

public class SoldierTargetProvider_ClosestAliveEnemy : SoldierTargetProviderBase
{
    [SerializeField] private ESoldierTeam _targetSoldierType;
    [SerializeField] private Soldier _mySoldier = null;

    private Soldier _selectedTargetSoldier = null;

    public override Action<Soldier> OnSoldierUpdated { get; set;}
    public override Action OnNoTargetSoldierFound { get; set; }

    public override Soldier GetTargetSoldier()
    {   
        return _selectedTargetSoldier;
    }
    

    public override void UpdateTargetSoldier()
    {
        Soldier targetSoldier;

        float soldierDistance;    

        List<Soldier> targetSoldiers = SoldierProvider.Instance.GetSoldiersBySoldierType(_targetSoldierType, true);

        if(targetSoldiers.Count <= 0) 
        {
            OnNoTargetSoldierFound?.Invoke();
            return;
        }        

        soldierDistance = Vector3.Distance(_mySoldier.transform.position, targetSoldiers[0].transform.position);
        targetSoldier = targetSoldiers[0];

        for (int i = 1; i < targetSoldiers.Count; i++)
        {
            float distance = Vector3.Distance(_mySoldier.transform.position, targetSoldiers[i].transform.position);
            if(soldierDistance > distance)
            {
                soldierDistance = distance;
                targetSoldier = targetSoldiers[i];
            }
        }
        
        Soldier previousSoldier = _selectedTargetSoldier;

        _selectedTargetSoldier = targetSoldier;
       

        if (_selectedTargetSoldier == null) return;

        _selectedTargetSoldier.GetComponent<Damagable>().OnDied += OnDamagableDied;

        if (previousSoldier != _selectedTargetSoldier)
        {
            OnSoldierUpdated?.Invoke(_selectedTargetSoldier);
        }        
    }

    private void OnDamagableDied(Damagable damagable)
    {
        _selectedTargetSoldier.GetComponent<Damagable>().OnDied -= OnDamagableDied;
        UpdateTargetSoldier();
    }

}
