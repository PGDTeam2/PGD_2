using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingPath : MonoBehaviour
{
    [SerializeField] private Transform[] waypointList;
    [SerializeField] private int currentWaypoint = 0;

    [SerializeField] private float speed = 3;

    private Transform nextWaypoint;

    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
           if(nextWaypoint == null)
            {
                nextWaypoint = waypointList[currentWaypoint];
                
            }
            Patrol();
    }
    void Patrol()
    {
        //Facing towards the destination
        

        //Moving towards the destination
        transform.position = Vector3.MoveTowards(transform.position, nextWaypoint.position,
        speed * Time.deltaTime);

        //When the agent reaches the waypoint it will move on to the next
        if(transform.position.x == waypointList[currentWaypoint].transform.position.x &&
           transform.position.z == waypointList[currentWaypoint].transform.position.z)
        {
            
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
        }
    }
}
