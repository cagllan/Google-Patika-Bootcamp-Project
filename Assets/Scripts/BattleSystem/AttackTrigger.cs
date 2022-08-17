using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    [SerializeField] private SoldierAttackBaseState _soldierAttackState = null;    

    // using event on attack animation.
    public void TriggerAttack()
    {      
        _soldierAttackState.AttackTriggered();
    }
}
