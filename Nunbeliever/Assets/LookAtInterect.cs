using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtInterect : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField]
    private Transform camera;
    [SerializeField]
    private int range = 3;
    
    public void Interact()
    {
        if (Physics.Raycast(camera.position,camera.forward, out hit, range))
        {
            PressButton pressButton = hit.collider.GetComponent<PressButton>();
            if (pressButton != null)
            {
                pressButton.Press();
            }
        }
    }

}
