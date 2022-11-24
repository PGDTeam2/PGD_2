using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMechanic : MonoBehaviour
{

    float range = 4f;
    Camera cam;
    Camera mainCamera;
    public static bool hiding;

    PlayerController playerController;

    private void Start()
    {
        mainCamera = Camera.main;
        playerController = gameObject.GetComponent<PlayerController>();
    }
    void Update()
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
                cam = hit.transform.gameObject.GetComponentInChildren<Camera>();
                cam.enabled = true;
                hiding = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E) && Camera.main == null)
        {
            cam.enabled=false;
            mainCamera.enabled = true;
            hiding=false;
        }
    }
}
