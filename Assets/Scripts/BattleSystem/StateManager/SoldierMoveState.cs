using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class SoldierMoveState : SoldierBaseState
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private string _move = "Move";
    [SerializeField] private float _fixedTransationDuration = 0.1f;
    [SerializeField] NavMeshAgent _nMeshAgent = null;
    [SerializeField] Transform _enemyTransform = null;    
    [SerializeField] private float _reachDistance = 2;
    [SerializeField] private SoldierTargetProviderBase _closestAliveEnemy;

    private IEnumerator _moveRoutine;

    // Event
    public Action OnReached{get;set;}

    private void Awake() 
    {
        _nMeshAgent.stoppingDistance = _reachDistance;
    }

    public override void Enter()
    {
        
        if(_closestAliveEnemy.GetTargetSoldier() == null) return;
        
        _animator.CrossFadeInFixedTime(_move, _fixedTransationDuration);

        _enemyTransform = _closestAliveEnemy.GetTargetSoldier().transform;

        _nMeshAgent.SetDestination(_enemyTransform.transform.position);
 
        StartMoveRoutine();        
    }

    public override void Exit()
    {        
        StopMoveRoutine();
    }
    
    private void StartMoveRoutine()
    {
        StopMoveRoutine();
        _nMeshAgent.isStopped = false;
        _moveRoutine = MoveProgress();
        StartCoroutine(_moveRoutine);
    }

    private void StopMoveRoutine()
    {
        if(_moveRoutine != null)
        {
            _nMeshAgent.isStopped = true;
            
            StopCoroutine(_moveRoutine);    
        }
    }


    private IEnumerator MoveProgress()
    {
        while(true)
        {
            _nMeshAgent.destination = _enemyTransform.position;

            if(Vector3.Distance(transform.position, _enemyTransform.position) <= _reachDistance)
            {          
                OnReached?.Invoke();  
            }

            yield return new WaitForEndOfFrame();            
        }        
    }

}
