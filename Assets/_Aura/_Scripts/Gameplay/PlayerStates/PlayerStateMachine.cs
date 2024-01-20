using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : BaseStateMachine
{
    [field:SerializeField]public InputReceiver InputReader {  get; private set; }
    [field:SerializeField]public CharacterController Controller { get; private set; }

    [field:SerializeField]public Animator PlayerAnimator { get; private set; }

    [field:SerializeField]public float SpeedMultiplier { get; private set; }

    public Transform CameraTransform { get; private set; }

    [field:SerializeField]public float TurnLerpTime { get; private set; }

    [field:SerializeField]public Targeter Targeter { get; private set; }
    //will need to start out with a base player state
    private void Start()
    {
        CameraTransform = Camera.main.transform;
        SwitchStates(new PlayerFreeLookState(this));
    }
   
}
 
