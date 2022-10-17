using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    public WanderState wanderState;
    public int searchTime = 0;
    public int searchLimit = 5000;
    public override State RunCurrentState()
    {
        
        if (searchTime > searchLimit)
        {
            Debug.Log("Lost him");
            return wanderState;
        }
        else
        {
            return this;
        }
    }
}
