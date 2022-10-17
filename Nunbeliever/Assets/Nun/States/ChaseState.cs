using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public SearchState searchState;
    public bool lostPlayer;
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent Agent;
    public bool MustBeVisible;
    public GameObject Nun;
    public int chaseTime = 0;
    public int chaseLimit = 2000;
    public Vector3 previousPosition;

    private void Start()
    {
        Nun = GameObject.FindWithTag("Nun");
        Agent = Nun.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Player = GameObject.FindWithTag("player");
        MustBeVisible = true;
    }

    public override State RunCurrentState()
    {
        Agent.speed = 3f;
        if (!LookForPlayer())
        {
            chaseTime++;
        }
        else
        {
            chaseTime--;
        }
        if(chaseTime < 0) chaseTime = 0;
        previousPosition = Agent.transform.position;

        if (chaseTime > chaseLimit && previousPosition == Agent.transform.position)
        {
            chaseTime = 0;
            return searchState;
        }
        else
        {
            return this;
        }

    }

    public bool LookForPlayer()
    {
        var delta = Player.transform.position - Agent.transform.position;
        float length = (Player.transform.position - Agent.transform.position).magnitude;

        if (Physics.Raycast(Agent.transform.position, delta.normalized, out RaycastHit hitInfo, length + 1) || !MustBeVisible)
        {
            if (hitInfo.collider.CompareTag("player") || !MustBeVisible)
            {
                Agent.destination = Player.transform.position;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
