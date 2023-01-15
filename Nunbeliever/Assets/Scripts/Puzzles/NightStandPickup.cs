using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightStandPickup : MonoBehaviour
{
    [SerializeField] internal GameObject Key;
    [SerializeField] private Animator doorAnimator;

    internal bool IsOpen { get; private set; }
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Open()
    {
        doorAnimator.SetBool("open", true);
        IsOpen = true;
        audioSource.Play();
    }
}
