using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChasingPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    [SerializeField] private float fov = 90;
    [SerializeField] internal float angle;
    // Start is called before the first frame update
    void Start()
    {
      agent = GetComponent<NavMeshAgent>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
        FindPlayer();
    }
    public bool FindPlayer()
    { 
        var distance = player.transform.position - transform.position;
        float length = (player.transform.position - transform.position).magnitude;

        if (Vector3.Angle(transform.forward, distance.normalized) < fov / 2)
        {
            if (Physics.Raycast(transform.position, distance.normalized, out RaycastHit hitInfo, length + 1))
            {
                if (hitInfo.collider.CompareTag("player"))
                {
                    agent.destination = player.transform.position;
                    return true;
                }
                else return false;
            } 
            else return false;
        }
        else return false;
    }


}
