using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchState : State
{
    private CareGiverSM sM;
    public CatchState(CareGiverSM stateMachine) : base("CatchState", stateMachine)
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

        sM.setAnimation(2); //grab animation
        sM.bringingPlayerBackToSpawn();

        if (!sM.playerCaught)
        {
            machine.changeState(sM.searchState);
            
        }
    }
    public override void Exit()
    {
        base.Exit();
    }

}
