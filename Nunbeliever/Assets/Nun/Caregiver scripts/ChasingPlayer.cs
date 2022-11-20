using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private float fov = 90;
    [SerializeField] private float grabLength = 0.4f;
    [SerializeField] private Transform playerSpawnPoint;

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
        FindPlayer();
        if (playerCaught)
        {
            CatchingPlayer();
        }
    }
    internal bool FindPlayer()
    {
        var distance = player.transform.position - transform.position;
        float length = (player.transform.position - transform.position).magnitude;

        if (Vector3.Angle(transform.forward, distance.normalized) < fov / 2)
        {
            if (Physics.Raycast(transform.position, distance.normalized, out RaycastHit hitInfo, length + 1))
            {
                if (hitInfo.collider.CompareTag("player") && !goBackPatrol)
                {
                    agent.destination = player.transform.position;
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
    private bool CatchingPlayer()
    {
        if (transform.position.x != playerSpawnPoint.transform.position.x && 
            transform.position.z != playerSpawnPoint.transform.position.z)
        {
            agent.destination = playerSpawnPoint.transform.position;
            player.transform.position = transform.position;
            return true;
        }
        else 
        {
            StartCoroutine(moveBack());
            return false; 
        }

    }
    internal IEnumerator moveBack()
    {
        goBackPatrol = true;
        playerCaught = false;

        yield return new WaitForSeconds(5);
        goBackPatrol = false;
    }
}
