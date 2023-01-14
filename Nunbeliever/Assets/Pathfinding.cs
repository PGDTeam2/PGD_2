using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public GameObject[] waypoints;
    public float moveSpeed = 1.0f;
    public float waitTime = 2.0f;

    private int currentWaypoint = 0;

  

    public void MoveToNextWaypoint()
    {
        if (currentWaypoint < waypoints.Length)
        {
            iTween.MoveTo(gameObject, iTween.Hash("position", waypoints[currentWaypoint].transform.position, "speed", moveSpeed, "easetype", "linear", "oncomplete", "WaitForSeconds"));
        }
    }

    public void WaitForSeconds()
    {
        StartCoroutine(WaitAndMove(waitTime));
        
    }

    IEnumerator WaitAndMove(float time)
    {
        transform.Rotate(0, -90, 0);
        yield return new WaitForSeconds(time);
        transform.Rotate(0, 90, 0);
        currentWaypoint++;

        if(currentWaypoint >= waypoints.Length)
        {
            gameObject.SetActive(false);
        }
        else
        {
            MoveToNextWaypoint();
        }

        

    }
}

