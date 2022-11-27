using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class IdleState : State
{
    private CareGiverSM sM;
    
    public IdleState(CareGiverSM machine) : base("IdleState", machine)
    {
        sM = (CareGiverSM)this.machine;   
    }
    public override void Enter()
    {
        
        base.Enter();
    }
    public override void Update()
    {
        if (sM.FindPlayer())
        {
            machine.changeState(sM.chaseState);
            return;
        }
        sM.StartCoroutine(enterWalk());
        base.Update();
        
    }
    internal IEnumerator enterWalk()
    {
        sM.setAnimation(1);
        sM.fov = 360;
        yield return new WaitForSeconds(4.5f);
        sM.setAnimation(0);
        machine.changeState(((CareGiverSM)machine).searchState);
    }
    public override void Exit()
    {
        sM.fov = 90;
        sM.StopAllCoroutines();
        base.Exit();    
    }

}
