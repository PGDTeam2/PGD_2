using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    public override State RunCurrentState()
    {
        Debug.Log("Lost him");
        return this;
    }
}
