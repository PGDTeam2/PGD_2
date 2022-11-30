using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class HideMechanic : MonoBehaviour
{

    float range = 4f;
    Camera cam;
    Camera mainCamera;
    public static bool hiding;
    GameObject hidingSpot;
    public float mouseSense = 5;

    float rotationX = 0;
    float rotationY = 0;    
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    

    PlayerController playerController;

    private void Start()
    {
        mainCamera = Camera.main;
        playerController = gameObject.GetComponent<PlayerController>();
    }
    private void Update()
    {
        ChechForColliders();
    }

    public void ChechForColliders()
    {
        LayerMask mask = LayerMask.GetMask("Hiding");
        RaycastHit hit;

        if (Camera.main != null)
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range, mask) && Input.GetKeyDown(KeyCode.E))
            {
                mainCamera.enabled = false;
                hidingSpot = hit.transform.gameObject;
                if (hidingSpot != null)
                {
                    cam = hidingSpot.GetComponentInChildren<Camera>();

                    if(cam != null)
                    {
                        cam.enabled = true;
                        hiding = true;
                    }
                }
            }
            hiding = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && Camera.main == null)
        {
            cam.enabled = false;
            mainCamera.enabled = true;
            hiding = false;
        }
        else if (Camera.main == null)
        {
            MoveHidingCamera();
        }
    }

    private void MoveHidingCamera()
    {
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationY += -Input.GetAxis("Mouse X") * lookSpeed;
        cam.transform.localRotation = Quaternion.Euler(rotationX, -rotationY, 0);
    }
}

