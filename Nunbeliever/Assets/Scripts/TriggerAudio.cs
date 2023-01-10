using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    private void Start()
    {
        audio= GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audio.Play();
            Destroy(gameObject, audio.clip.length);
          
        }
    }
}
