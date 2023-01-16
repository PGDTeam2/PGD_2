using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteract : MonoBehaviour
{
    private bool pressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            pressed = true;
    }

    private void FixedUpdate()
    {
        if (pressed)
        {
            if (Physics.Raycast(transform.position, transform.forward, out var hitInfo, 1, LayerMask.GetMask("Button")))
            {
                ButtonPuzzleController.instance.ButtonPressed(hitInfo.collider.GetComponent<Button>());
            }
            pressed = false;
        }
    }
}
