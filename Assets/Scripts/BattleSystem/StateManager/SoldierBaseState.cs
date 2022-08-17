using UnityEngine;

public abstract class SoldierBaseState : MonoBehaviour, IBaseState
{ 
    public abstract void Enter();

    public abstract void Exit();
}


