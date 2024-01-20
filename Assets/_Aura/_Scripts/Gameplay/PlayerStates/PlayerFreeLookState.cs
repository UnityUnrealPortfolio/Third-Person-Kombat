using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState, IBaseState
{
    [SerializeField] float animatorDampTime;
   
    #region Private fields
    Vector3 movement = Vector3.zero;
    Vector3 forwardMovement = Vector3.zero;
    Vector3 sideMovement = Vector3.zero;
    Vector3 moveInput = Vector3.zero;
    int freeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");
    int freeLookStateBlendHash = Animator.StringToHash("FreeLookStateBlend");
    #endregion
    public PlayerFreeLookState(PlayerStateMachine _playerStateMachine) : base(_playerStateMachine)
    {
    }

    public void Enter()
    {
        playerStateMachine.InputReader.OnJumpEvent += HandleJumpEvent;
        playerStateMachine.InputReader.OnMoveEvent += HandleMove;

        //subsribe to enter state event
        playerStateMachine.InputReader.OnEnterTargetEvent += HandleEnterTargetingState;
        playerStateMachine.PlayerAnimator.Play(freeLookStateBlendHash);

    }


    #region Input Callbacks

    private void HandleMove(Vector2 _movementInput)
    {
        
        movement.x = _movementInput.x;
        movement.y = 0f;
        movement.z = _movementInput.y;
      
    }


    private void HandleEnterTargetingState()
    {
        if (!playerStateMachine.Targeter.GetSelectedTarget())
            return;

        playerStateMachine.SwitchStates(new PlayerTargetingState(playerStateMachine));
    }
    #endregion

    public void Tick(float deltaTime)
    {
        CalculateMovement();

        //Move
        playerStateMachine.Controller.Move(deltaTime * playerStateMachine.SpeedMultiplier * moveInput);

        HandleAnimationAndTurn(deltaTime);
    }

    private void HandleAnimationAndTurn(float _deltaTime)
    {
        if (movement.magnitude == 0f)
        {
            playerStateMachine.PlayerAnimator.SetFloat(freeLookSpeedHash,0,animatorDampTime,_deltaTime);
            return;
        }

        playerStateMachine.PlayerAnimator.SetFloat(freeLookSpeedHash,1,animatorDampTime,_deltaTime);
        playerStateMachine.transform.rotation = Quaternion.Slerp(playerStateMachine.transform.rotation,
            Quaternion.LookRotation(new Vector3(moveInput.x,0f,moveInput.z)),
            _deltaTime * playerStateMachine.TurnLerpTime);
    }

    private void CalculateMovement()
    {
        sideMovement = playerStateMachine.CameraTransform.right.normalized * movement.x;
        sideMovement.y = 0;
        forwardMovement = playerStateMachine.CameraTransform.forward.normalized * movement.z;
        forwardMovement.y = 0;
        moveInput = forwardMovement + sideMovement + new Vector3(0,-9.8f,0f);
    }

    public void Exit()
    {
        playerStateMachine.InputReader.OnJumpEvent -= HandleJumpEvent;
        playerStateMachine.InputReader.OnMoveEvent -= HandleMove;
        playerStateMachine.InputReader.OnEnterTargetEvent -= HandleEnterTargetingState;

    }


    private void HandleJumpEvent()
    {
        playerStateMachine.SwitchStates(new PlayerJumpState(playerStateMachine));
    }

}
