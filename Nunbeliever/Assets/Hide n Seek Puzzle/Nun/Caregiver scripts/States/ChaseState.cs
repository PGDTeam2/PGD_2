using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    // Start is called before the first frame update
    private CareGiverSM sM;
    private GameObject player;
    public ChaseState(CareGiverSM stateMachine) : base(stateMachine)
    {
        sM = (CareGiverSM)this.machine;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();

        followPlayer();
        sM.FindPlayer();

        if (sM.playerCaught)
        {
            sM.fov = 90;
            machine.changeState(sM.catchState);
            return;
        }
       else if (!sM.FindPlayer())
        {
            sM.fov = 90;
            machine.changeState(sM.searchState);
        }
        
    }
    internal void followPlayer()
    {
        sM.agent.destination = player.transform.position;
    }
    public override void Exit()
    {
        base.Exit();
    }

}
