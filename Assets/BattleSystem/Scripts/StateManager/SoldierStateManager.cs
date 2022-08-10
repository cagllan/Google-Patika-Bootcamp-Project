using UnityEngine;
using UnityEngine.UI;

public class SoldierStateManager : MonoBehaviour
{
    [SerializeField] private SoldierIdleState _soldierIdleState = null;
    [SerializeField] private SoldierMoveState _soldierMoveState = null;
    [SerializeField] private SoldierAttackBaseState _soldierAttackState = null;
    [SerializeField] private SoldierDiedState _soldierDiedState = null;
    [SerializeField] private SoldierVictoryState _soldierVictoryState = null;

    [SerializeField] private Damagable _damagable;
    [SerializeField] private SoldierTargetProviderBase _soldierTargetProvider = null;

    private SoldierBaseState _currentState;

    private void Awake() 
    {
        _currentState = _soldierIdleState;
        _currentState.Enter();

        _soldierTargetProvider.OnNoTargetSoldierFound += OnNoTargetSoldierFound;
        _soldierMoveState.OnReached += OnReachedTarget;
        _damagable.OnDied += OnSoldierDied;

        TeamVictoryControl.Instance.OnSoldierTeamWon += OnSoldierVictory;

        BattleStartController.Instance.OnStartBattle += OnStartBattle;
    }   

    private void Start() 
    {
        _soldierTargetProvider.OnSoldierUpdated += OnSoldierUpdated;
    }

    private void OnDestroy() 
    {
        _soldierTargetProvider.OnNoTargetSoldierFound -= OnNoTargetSoldierFound;
        _soldierMoveState.OnReached -= OnReachedTarget;
        _soldierTargetProvider.OnSoldierUpdated -= OnSoldierUpdated;

        _damagable.OnDied -= OnSoldierDied;

        if (BattleStartController.Instance != null ) BattleStartController.Instance.OnStartBattle -= OnStartBattle;

        if (TeamVictoryControl.Instance != null)
        {
            TeamVictoryControl.Instance.OnSoldierTeamWon -= OnSoldierVictory;
        }
    }

    
    private void OnStartBattle()
    {
        _soldierTargetProvider.UpdateTargetSoldier();
        ChangeState(_soldierMoveState);
    }

    private void ChangeState(SoldierBaseState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }

    private void OnNoTargetSoldierFound()
    {
        ChangeState(_soldierVictoryState);
    }

    private void OnReachedTarget()
    {
         ChangeState(_soldierAttackState);
    }


    private void OnSoldierUpdated(Soldier soldier)
    {
        
        ChangeState(_soldierMoveState);
    }

    private void OnSoldierDied(Damagable damagable)
    {
        _soldierTargetProvider.OnNoTargetSoldierFound -= OnNoTargetSoldierFound;
        _soldierMoveState.OnReached -= OnReachedTarget;
        _damagable.OnDied -= OnSoldierDied;
        _soldierTargetProvider.OnSoldierUpdated -= OnSoldierUpdated;

        ChangeState(_soldierDiedState);
    }

    private void OnSoldierVictory(ESoldierTeam soldierTeam)
    {
        if(this.GetComponentInParent<Soldier>().SoldierType == soldierTeam && !_damagable.IsDead)
        {
            ChangeState(_soldierVictoryState);
        }        
    }
}
