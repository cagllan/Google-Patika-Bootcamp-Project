using UnityEngine;

public class SoldierIdleState : SoldierBaseState
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private string _idle = "Idle";
    [SerializeField] private float _fixedTransationDuration = 0.1f;
    
    public override void Enter()
    {
        _animator.CrossFadeInFixedTime(_idle, _fixedTransationDuration);
    }

    public override void Exit()
    {
        
    }
}
