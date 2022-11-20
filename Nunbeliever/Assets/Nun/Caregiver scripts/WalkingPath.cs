using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPath : MonoBehaviour
{
    [SerializeField] private Transform[] waypointList;

    [SerializeField] private float speed = 3;

    private int currentWaypoint = 0;
    private Transform nextWaypoint;

    // Start is called before the first frame update
    void Start()
    {
       transform.position =  waypointList[currentWaypoint].transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Patrol()
    {
        //Facing towards the destination
        transform.forward = Vector3.RotateTowards(transform.forward, nextWaypoint.position -
        transform.position, speed * Time.deltaTime, 0.0f);

        //Moving towards the destination
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.position,
        speed * Time.deltaTime);

        //When the agent reaches the waypoint it will move on to the next
        if(transform.position == waypointList[currentWaypoint].transform.position)
        {
            currentWaypoint++;
            nextWaypoint = waypointList[currentWaypoint];
        }
    }
}
