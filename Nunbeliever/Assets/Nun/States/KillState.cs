using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillState : State
{
    
    public GameObject Player;
    public NavMeshAgent Agent;
    public bool MustBeVisible;
    public GameObject Nun;
    public Vector3 previousPosition;

    private void Start()
    {
        Nun = GameObject.FindWithTag("Nun");
        Agent = Nun.GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("player");
        MustBeVisible = true;
    }

    public override State RunCurrentState()
    {
        KillPlayer();
        return this;
    }

    public void KillPlayer()
    {
        Debug.Log("You died");
        //Do player death thingy
    }

    
}
