using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    public GameObject[] waypoints;
    public float moveSpeed = 1.0f;
    public float waitTime = 2.0f;
    
    private int currentWaypoint = 0;
    NavMeshAgent navMeshAgent;
   Animator animator;
    public static bool canWalk = false;
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    public void Update()
    { if (canWalk)
        {
            if (currentWaypoint < waypoints.Length)
            {
                animator.SetBool("Walking", true);
                navMeshAgent.destination = waypoints[currentWaypoint].transform.position;
            }

            if (waypoints[currentWaypoint].transform.position.x + waypoints[currentWaypoint].transform.position.z == navMeshAgent.transform.position.x + navMeshAgent.transform.position.z)
            {

                animator.SetBool("Walking", false);
                currentWaypoint++;
            }
            if (currentWaypoint == waypoints.Length)
            {
                gameObject.SetActive(false);
            }
        }
      
    }


        

    }


