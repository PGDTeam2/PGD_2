using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NunFollow : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent Agent;
    public bool MustBeVisible;

    [HideInInspector]
    private int awareness;
    //public int Awareness
    //{
    //    get { return awareness; }
    //    set { if (value <= MaxAwareness) awareness = value; AwarenessDisplay.UpdateAwareness(value); }
    //}
    public int MaxAwareness;
    public int HuntInterval;
    private float huntTimer;
    public int[] HuntChance;

    private Vector3 previousDestination;
    private int wanderingTime = 0;
    private int wanderingTreshhold = 1000;
    public int wanderDistance = 8;

    //public AwarenessDisplay AwarenessDisplay;

    // Update is called once per frame
    void Update()
    {
        var delta = Player.transform.position - Agent.transform.position;
        float length = (Player.transform.position - Agent.transform.position).magnitude;

        if (Physics.Raycast(Agent.transform.position, delta.normalized, out RaycastHit hitInfo, length + 1) || !MustBeVisible)
        {
            if (hitInfo.collider.CompareTag("Player") || !MustBeVisible)
            {
                Agent.destination = Player.transform.position;
            }
        }

        //if (huntTimer > HuntInterval)
        //{
        //    huntTimer = huntTimer - HuntInterval;
        //    if (Random.Range(0, 100) < HuntChance[Awareness])
        //    {
        //        Agent.destination = Player.transform.position;
        //    }
        //}

        huntTimer += Time.deltaTime;

        //Wandering
        if (wanderingTime > wanderingTreshhold)
        {
            if (Agent.destination == previousDestination)
            {
                Vector3 randomDirection = Random.insideUnitSphere * wanderDistance;
                Agent.destination += randomDirection;
            }
            previousDestination = Agent.transform.position;
            wanderingTime = 0;
        }
        wanderingTime += Random.Range(1, 3);


    }
}
