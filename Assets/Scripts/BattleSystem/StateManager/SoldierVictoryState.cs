using UnityEngine;

public class SoldierVictoryState : SoldierBaseState
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private string _victory = "Victory";
    [SerializeField] private float _fixedTransationDuration = 0.1f;

    
    public override void Enter()
    {
        _animator.CrossFadeInFixedTime(_victory, _fixedTransationDuration);
    }

    public override void Exit()
    {
       
    }    
}
