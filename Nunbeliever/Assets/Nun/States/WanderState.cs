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
    private GameObject Nun;


    private void Start()
    {
        Nun = GameObject.FindWithTag("Nun");
        Agent = Nun.GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("player");
        MustBeVisible = true;
    }

    public override State RunCurrentState()
    {
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
                //Vector3 tmp = Player.transform.position;
                //tmp.x = Mathf.Round(tmp.x);
                //tmp.y = Mathf.Round(tmp.y);
                //tmp.z = Mathf.Round(tmp.z);
                //Agent.destination = tmp;
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
