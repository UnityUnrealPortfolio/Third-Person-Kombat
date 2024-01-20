using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState,IBaseState
{
    Vector3 movement = Vector3.zero;
    public PlayerIdleState(PlayerStateMachine _playerStateMachine) : base(_playerStateMachine)
    {
    }

    public void Enter()
    {
        playerStateMachine.InputReader.OnJumpEvent += HandleJumpEvent;
        playerStateMachine.InputReader.OnMoveEvent += HandleMove;
    }

    private void HandleMove(Vector2 _movementInput)
    {
        
        movement.x = _movementInput.x;
        movement.y = playerStateMachine.transform.position.y;
        movement.z = _movementInput.y;

        //move the knight via the statemachine
        
    }

    public void Tick(float deltaTime)
    {
        
        playerStateMachine.Controller.Move(movement * deltaTime);
    }
    public void Exit()
    {
        playerStateMachine.InputReader.OnJumpEvent -= HandleJumpEvent;
    }


    private void HandleJumpEvent()
    {
        playerStateMachine.SwitchStates(new PlayerJumpState(playerStateMachine));
    }

}
