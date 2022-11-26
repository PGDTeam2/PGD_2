using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingPlayer : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] private float fov = 90;
    [SerializeField] private float grabLength = 0.4f;
    [SerializeField] private Transform playerSpawnPoint;

    private NavMeshAgent agent;

    internal bool playerCaught;
    internal bool goBackPatrol;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerCaught);
        FindPlayer();
        if (playerCaught)
        {
            bringingPlayerBackToSpawn();
        }
    }

    internal bool FindPlayer()
    {
        var distance = player.transform.position - transform.position;

        //Calculates the angle from which the agent can see the player
        if (Vector3.Angle(transform.forward, distance.normalized) < fov / 2)
        {
            float length = (player.transform.position - transform.position).magnitude;
            //Calculates the agents raycast
            if (Physics.Raycast(transform.position, distance.normalized, out RaycastHit hitInfo, length + 1))
            {
                //checks if the raycast hits the player and checks if the agent isnt coming back from the spawnpoint
                if (hitInfo.collider.CompareTag("player") && !goBackPatrol)
                {
                    agent.destination = player.transform.position;
                   
                    //grabs the player and puts him back to the spawnpoint
                    if (hitInfo.distance < grabLength)
                    {
                        Debug.Log("w");
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
   
    internal bool bringingPlayerBackToSpawn()
    {
        //when the agent isn't located on the spawnpoint move towards the spawnpoint
        if (transform.position.x != playerSpawnPoint.transform.position.x && 
            transform.position.z != playerSpawnPoint.transform.position.z)
        {
            agent.destination = playerSpawnPoint.transform.position;

            //moves the player with the agents so the agent automatically creates the path for both objects
            player.transform.position = transform.position;
            return true;
        }
        else 
        {
            StartCoroutine(goBackToPatrol());
            return false; 
        }

    }
    internal IEnumerator goBackToPatrol()
    {
        goBackPatrol = true;
        playerCaught = false;

        yield return new WaitForSeconds(5);
        goBackPatrol = false;
    }
}
