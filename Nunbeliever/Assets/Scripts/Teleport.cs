using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public Transform faceDirection;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DelayTeleport(other));
        }
    }

        IEnumerator DelayTeleport(Collider player)
    {
        yield return new WaitForSeconds(0.3f);
        player.transform.position = teleportTarget.position;
        player.transform.eulerAngles = new Vector3(4.5f, 0, 0);
        

    }
}
