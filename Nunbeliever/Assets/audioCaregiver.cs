using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioCaregiver : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    CareGiverSM careGiverSM;
    public AudioClip clip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        careGiverSM = GetComponentInParent<CareGiverSM>();

    }

    // Update is called once per frame
    void Update()
    {
        if(careGiverSM.currentState == careGiverSM.searchState && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
