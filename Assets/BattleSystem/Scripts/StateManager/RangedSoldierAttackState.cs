using System.Collections;
using UnityEngine;

public class RangedSoldierAttackState : SoldierAttackBaseState
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private string _attack = "Attack";
    [SerializeField] private float _fixedTransationDuration = 0.1f;

    [SerializeField] private SoldierTargetProviderBase _soldierTargetProvider = null;

    [SerializeField] private Soldier _mySoldier = null;

    [SerializeField] Transform _arrowRefTransform;

    [SerializeField] private Projectile _bulletPrefab;


    private IEnumerator _lockOnTargetRoutine; 

    public override void Enter()
    {
        _animator.CrossFadeInFixedTime(_attack, _fixedTransationDuration);
        StartLockToTargetRoutine();
    }

    public override void Exit()
    {
        StopLockToTargetRoutine();
    }

    public override void AttackTriggered()
    {
        Projectile bullet = GameObject.Instantiate(_bulletPrefab, _arrowRefTransform.position, Quaternion.LookRotation(_soldierTargetProvider.GetTargetSoldier().transform.position - _mySoldier.transform.position));
    }


    private void StartLockToTargetRoutine()
    {
        StopLockToTargetRoutine();

        _lockOnTargetRoutine = LockOnTargetProgress();
        StartCoroutine(LockOnTargetProgress());
    }

    private void StopLockToTargetRoutine()
    {
        if(_lockOnTargetRoutine != null)
        {
            StopCoroutine(LockOnTargetProgress());
        }
    }

    private IEnumerator LockOnTargetProgress()
    {
        while(!_soldierTargetProvider.GetTargetSoldier().GetComponent<Damagable>().IsDead)
        {
            _mySoldier.transform.rotation = Quaternion.LookRotation(_soldierTargetProvider.GetTargetSoldier().transform.position -  _mySoldier.transform.position);
            yield return new WaitForEndOfFrame();            
        }
    }
}
    
