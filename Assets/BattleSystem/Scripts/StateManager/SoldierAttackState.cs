using UnityEngine;

public class SoldierAttackState : SoldierBaseState
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private string _attack = "Attack";
    [SerializeField] private float _fixedTransationDuration = 0.1f;

    [SerializeField] private SoldierTargetProviderBase _soldierTargetProvider;

    [SerializeField] private DamageDealer _mySoldier;

    private Damagable _enemySoldier;

    public override void Enter()
    {
        _animator.CrossFadeInFixedTime(_attack, _fixedTransationDuration);
    }

    public override void Exit()
    {
        
    }

    public void DealDamage()
    { 
        _enemySoldier = _soldierTargetProvider.GetTargetSoldier().GetComponent<Damagable>();
        _mySoldier.DealDamage(_enemySoldier);
    }
}
