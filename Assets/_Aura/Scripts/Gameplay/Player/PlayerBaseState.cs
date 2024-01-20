using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{
    protected PlayerStateMachine playerStateMachine;

    public PlayerBaseState(PlayerStateMachine _playerStateMachine)
    {
        playerStateMachine = _playerStateMachine;
    }



}
