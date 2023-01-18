using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public GameObject targetObject;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Nun"))
        {
            Debug.Log("h");
            Pathfinding.canWalk = true;
        }
    }
}
