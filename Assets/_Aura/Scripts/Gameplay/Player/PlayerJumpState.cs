using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState,IBaseState
{
    public PlayerJumpState(PlayerStateMachine _playerStateMachine) : base(_playerStateMachine)
    {
    }

    public void Enter()
    {
        Debug.Log("Entered jump state");
    }

    public void Tick(float deltaTime)
    {

    }
    public void Exit()
    {
       
    }


}
