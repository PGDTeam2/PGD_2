using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    [SerializeField] private float interactionRange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hitInfo, interactionRange))
            {
                if (hitInfo.collider.CompareTag("Door"))
                {
                    hitInfo.collider.SendMessageUpwards("OnInteract");
                }
            }
        }
    }
}
