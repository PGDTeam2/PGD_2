using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class OptionsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    float currentVolume;
    [SerializeField] string audioName;
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVolume(float volume)
    {
        mixer.SetFloat(audioName, Mathf.Log10(volume) * 20);
        
    }
}
