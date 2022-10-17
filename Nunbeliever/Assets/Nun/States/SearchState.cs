using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    public WanderState wanderState;
    public ChaseState chaseState;
    public int searchTime = 0;
    public int searchLimit = 10000;
    public GameObject Player;
    public UnityEngine.AI.NavMeshAgent Agent;
    public bool MustBeVisible;
    public GameObject Nun;
    public Vector3 previousPosition;
    private int wanderingTime = 0;
    private int wanderingTreshhold = 300;
    private int wanderDistance = 5;
    private bool lastPlayerPositionRemembered = false;
    private Vector3 lastPlayerPosition;

    private void Start()
    {
        Nun = GameObject.FindWithTag("Nun");
        Agent = Nun.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Player = GameObject.FindWithTag("player");
        MustBeVisible = true;
    }

    public override State RunCurrentState()
    {
        if (!lastPlayerPositionRemembered)
        {
            lastPlayerPositionRemembered = true;
            lastPlayerPosition = Player.transform.position;

        }
        Agent.speed = 4f;
        if (LookForPlayer())
        {
            return chaseState;
        }
        else
        {
            Walk();
            if (searchTime > searchLimit && previousPosition == Agent.transform.position)
            {
                Debug.Log("Lost him");
                searchTime = 0;
                return wanderState;
            }
            else
            {
                searchTime++;
                //if (searchTime > searchLimit / 2) wanderDistance = 10;
                //else wanderDistance = 5;

                return this;
            }
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
                //do
                {
                    Vector3 randomDirection = Random.insideUnitSphere * wanderDistance;
                    Agent.destination = randomDirection + lastPlayerPosition;
                    Debug.Log(Vector3.Distance(Agent.destination, lastPlayerPosition));
                } //while (Vector3.Distance(Agent.destination, lastPlayerPosition) > 100);
            }
            previousPosition = Agent.transform.position;
            wanderingTime = 0;
        }
        wanderingTime += Random.Range(1, 3);
    }
}
