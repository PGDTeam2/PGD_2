using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public SearchState searchState;
    public bool lostPlayer;
    public override State RunCurrentState()
    {
        if (lostPlayer)
        {
            return searchState;
        }
        else
        {
            return this;
        }
    }
}
