using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    private CareGiverSM sM;
    public SearchState(CareGiverSM machine) : base(machine)
    {
        sM = (CareGiverSM)this.machine;
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        
        base.Update();

        sM.setAnimation(0);
        sM.Patrol();
        sM.FindPlayer();

        if (sM.FindPlayer())
        {
            machine.changeState(((CareGiverSM)machine).chaseState);
            return;
        }
        if (sM.reachedWaypoint)
        {
            machine.changeState(sM.idleState);
            sM.reachedWaypoint = false;
            return;
        }

    }
    public override void Exit()
    {
        base.Exit();
    }
}
