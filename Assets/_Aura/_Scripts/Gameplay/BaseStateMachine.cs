using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    //reference to the current state
    protected IBaseState currentState;

    protected virtual void Update()
    {
        currentState?.Tick(Time.deltaTime); 
    }
    public virtual void SwitchStates(IBaseState nextState)
    {
        currentState?.Exit();
        currentState = nextState;
        currentState?.Enter();
    }
}
