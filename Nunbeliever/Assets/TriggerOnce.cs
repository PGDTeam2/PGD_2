using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOnce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }

}
