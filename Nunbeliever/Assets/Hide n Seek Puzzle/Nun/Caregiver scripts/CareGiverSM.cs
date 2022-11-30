using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class CareGiverSM : StateMachine
{
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public SearchState searchState;
    [HideInInspector] public ChaseState chaseState;
    [HideInInspector] public CatchState catchState;

    [Header("Pathfinding")]
    [HideInInspector] internal int currentWaypoint = 0;
    [HideInInspector] internal bool reachedWaypoint;
    [HideInInspector] internal Transform nextWaypoint;
    [HideInInspector] internal NavMeshAgent agent;
    [SerializeField] internal Transform[] waypointList; //assign the waypoints in the inspector

    [Header("Catching the player")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Transform playerSpawnPoint; //transform position where the player gets put back
    [SerializeField] private Transform carry; //transform where the player positions when caught
    [SerializeField] private float grabLength = 1f;
    [SerializeField] internal float fov = 90;
 
    internal bool playerCaught;
    internal bool playerSeen;
    internal bool goBackPatrol;

    Animator animator;

    private void Awake()
    {
        idleState = new IdleState(this);
        searchState = new SearchState(this);
        catchState = new CatchState(this);
        chaseState = new ChaseState(this);
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        setState(idleState);
    }
    internal void setAnimation(int animationState)
    {
        animator.SetInteger("animation", animationState);
    }
    internal void Patrol()
    {
        //Moving towards the destination
        agent.destination = waypointList[currentWaypoint].transform.position;

        //assigns the first waypoint.
        if (nextWaypoint == null)
        {
            nextWaypoint = waypointList[currentWaypoint];
        }

        //When the agent reaches the waypoint it will move on to the next
        if (transform.position.x == waypointList[currentWaypoint].transform.position.x &&
           transform.position.z == waypointList[currentWaypoint].transform.position.z)
        {
            Vector3 direction = (waypointList[currentWaypoint].transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);

            if (currentWaypoint < waypointList.Length - 1)
            {
                currentWaypoint++;
                nextWaypoint = waypointList[currentWaypoint];
            }
            else
            {
                currentWaypoint = 0;
                nextWaypoint = null;
            }
            reachedWaypoint = true;

        }
    }


    internal bool bringingPlayerBackToSpawn()
    {
        //when the agent isn't located on the spawnpoint move towards the spawnpoint
        if (transform.position.x != playerSpawnPoint.transform.position.x &&
            transform.position.z != playerSpawnPoint.transform.position.z)
        {
            agent.destination = playerSpawnPoint.transform.position;
            playerController.canMove = false;

            //moves the player with the agents so the agent automatically creates the path for both objects
            playerController.transform.SetPositionAndRotation(carry.transform.position, carry.transform.rotation);
            return true;
        }
        else
        {
            playerController.canMove = true;
            StartCoroutine(goBackToPatrol());
            return false;
        }

    }
    internal void followPlayer()
    {
        agent.destination = playerController.transform.position;
    }

    internal IEnumerator goBackToPatrol()
    {
        goBackPatrol = true;
        playerCaught = false;

        yield return new WaitForSeconds(5);
        goBackPatrol = false;
    }

    internal bool FindPlayer()
    {
        var distance = playerController.transform.position - transform.position;

        //Calculates the angle from which the agent can see the player
        if (Vector3.Angle(transform.forward, distance.normalized) < fov / 2)
        {
            float length = (playerController.transform.position - transform.position).magnitude;
            //Calculates the agents raycast
            if (Physics.Raycast(transform.position, distance.normalized, out RaycastHit hitInfo, length + 1))
            {
                //checks if the raycast hits the player and checks if the agent isnt coming back from the spawnpoint
                if (hitInfo.collider.CompareTag("Player") && !goBackPatrol)
                {
                    //grabs the player and puts him back to the spawnpoint
                    if (hitInfo.distance < grabLength)
                    {
                        playerCaught = true;
                    }
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }

}
