using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteract : MonoBehaviour
{
    [SerializeField] private float interactionRange;

    private KeyPickup keyPickup;
    private bool pressed;

    private void Start()
    {
        keyPickup = GetComponent<KeyPickup>();
    }

    private void Update()
    {
        // Cache input so we can raycast more consistently inside of FixedUpdate
        if (Input.GetKeyDown(KeyCode.E))
            pressed = true;
    }

    private void FixedUpdate()
    {
        if (pressed)
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hitInfo, interactionRange, LayerMask.GetMask("Door")))
            {
                hitInfo.collider.SendMessageUpwards("OnInteract", keyPickup.OwnedKeys);
            }
        }
        pressed = false;
    }
}

