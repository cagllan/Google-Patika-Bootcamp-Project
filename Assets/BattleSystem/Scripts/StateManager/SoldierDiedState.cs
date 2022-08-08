using UnityEngine;

public class SoldierDiedState : SoldierBaseState
{
    [SerializeField] private Animator _animator = null;
    [SerializeField] private string _died = "Died";
    [SerializeField] private float _fixedTransationDuration = 0.1f;

 
    public override void Enter()
    {
        _animator.CrossFadeInFixedTime(_died, _fixedTransationDuration);
    }
    
    public override void Exit()
    {
  
    }
}
