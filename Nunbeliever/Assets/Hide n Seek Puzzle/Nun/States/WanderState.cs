using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : State
{
    public ChaseState chaseState;
    public bool canSeeThePlayer;
    public GameObject Player;
    public NavMeshAgent Agent;
    public bool MustBeVisible;
    public GameObject Nun;
    private int wanderingTime = 0;
    private int wanderingTreshhold = 3000;
    private int wanderDistance = 20;
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
        Agent.speed = 1.5f;
        Walk();
        if (LookForPlayer())
        {
            return chaseState;
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

    private void Walk()
    {
        if (wanderingTime > wanderingTreshhold)
        {
            if (previousPosition == Agent.transform.position)
            {
                Vector3 randomDirection = Random.insideUnitSphere * wanderDistance;
                Agent.destination += randomDirection;
            }
            previousPosition = Agent.transform.position;
            wanderingTime = 0;
        }
        wanderingTime += Random.Range(1, 3);
    }
}
