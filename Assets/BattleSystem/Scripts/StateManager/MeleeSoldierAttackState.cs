using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSoldierAttackState : SoldierAttackBaseState
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private string _attack = "Attack";
    [SerializeField] private float _fixedTransationDuration = 0.1f;

    [SerializeField] private SoldierTargetProviderBase _soldierTargetProvider = null;

    [SerializeField] private DamageDealer _mySoldier = null;

    private Damagable _enemySoldier;

    public override void Enter()
    {
        _animator.CrossFadeInFixedTime(_attack, _fixedTransationDuration);
    }

    public override void Exit()
    {
        
    }

    public override void AttackTriggered()
    {
        _enemySoldier = _soldierTargetProvider.GetTargetSoldier().GetComponent<Damagable>();
        _mySoldier.DealDamage(_enemySoldier);
    }
}
