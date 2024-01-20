using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBaseState 
{
    public void Enter();
    public void Tick(float deltaTime);
    public void Exit();
}
