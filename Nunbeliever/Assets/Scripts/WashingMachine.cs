using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachine : MonoBehaviour
{
    AudioSource audioSource;
    private bool opened = false;

    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !opened)
        {
            opened = true;
            audioSource.Stop();
            GetComponentsInChildren<Transform>()[2].eulerAngles += new Vector3(0f, 0f, -30f);
            
        }

    }
}
