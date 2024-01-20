using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : BaseStateMachine
{
    [field:SerializeField]public InputReceiver InputReader {  get; private set; }
    [field:SerializeField]public CharacterController Controller { get; private set; }
    //will need to start out with a base player state
    private void Start()
    {
        SwitchStates(new PlayerIdleState(this));
    }
   
}
 
