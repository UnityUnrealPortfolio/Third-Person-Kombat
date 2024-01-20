using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState, IBaseState
{
    #region private fields
    int targetingStateBlendHash = Animator.StringToHash("TargetingStateBlend");
    #endregion
    public PlayerTargetingState(PlayerStateMachine _playerStateMachine) : base(_playerStateMachine)
    {
    }

    public void Enter()
    {
        Debug.Log("Entering targeting state!");
        playerStateMachine.Targeter.currentSelectedTarget.HandleTargeted();
        playerStateMachine.InputReader.OnExitTargetEvent += HandleExitTargetingState;

        playerStateMachine.PlayerAnimator.Play(targetingStateBlendHash);
    }
    public void Tick(float deltaTime)
    {

    }

    #region Input Callbacks

    private void HandleExitTargetingState()
    {
        playerStateMachine.SwitchStates(new PlayerFreeLookState(playerStateMachine));
    }

    #endregion
    public void Exit()
    {
        Debug.Log("Exiting targeting state!");
        playerStateMachine.Targeter.currentSelectedTarget.HandleUntargeted();

        playerStateMachine.InputReader.OnExitTargetEvent -= HandleExitTargetingState;

    }

  
}
