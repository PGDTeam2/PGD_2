using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public string name;
    protected StateMachine machine;
    public State(string name, StateMachine machine)
    {
        this.name = name;
        this.machine = machine;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }


}
