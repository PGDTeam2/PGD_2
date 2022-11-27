using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    // Start is called before the first frame update
    private CareGiverSM sM;
    public ChaseState(CareGiverSM stateMachine) : base("ChaseState", stateMachine)
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

        sM.followPlayer();
        sM.FindPlayer();

        if (sM.playerCaught)
        {
            machine.changeState(sM.catchState);
            return;
        }
        if (!sM.FindPlayer())
        {
            machine.changeState(sM.searchState);
        }
        
    }
    public override void Exit()
    {
        base.Exit();
    }

}
