using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public WanderState wanderState;
    public bool allowMoving = true;

    public override State RunCurrentState()
    {
        if (allowMoving)
        {
            return wanderState;
        }
        else
        {
            return this;
        }
    }
}
