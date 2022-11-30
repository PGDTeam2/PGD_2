using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchState : State
{
    private CareGiverSM sM;
    private GameObject playerSpawnPoint;
    private GameObject carry;
    public CatchState(CareGiverSM stateMachine) : base(stateMachine)
    {
        sM = (CareGiverSM)this.machine;
        carry = GameObject.FindGameObjectWithTag("Carry");
        playerSpawnPoint = GameObject.FindGameObjectWithTag("Spawnpoint");
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();

        sM.setAnimation(2); //grab animation
        bringingPlayerBackToSpawn();

        if (!sM.playerCaught)
        {
            machine.changeState(sM.searchState);
            
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
    internal bool bringingPlayerBackToSpawn()
    {
        //when the agent isn't located on the spawnpoint move towards the spawnpoint
        if (sM.transform.position.x != playerSpawnPoint.transform.position.x &&
            sM.transform.position.z != playerSpawnPoint.transform.position.z)
        {
            sM.agent.destination = playerSpawnPoint.transform.position;
            sM.playerController.canMove = false;

            //moves the player with the agents so the agent automatically creates the path for both objects
            sM.playerController.transform.SetPositionAndRotation(carry.transform.position, carry.transform.rotation);
            return true;
        }
        else
        {
            sM.playerController.canMove = true;
            sM.StartCoroutine(sM.goBackToPatrol());
            return false;
        }

    }

}
