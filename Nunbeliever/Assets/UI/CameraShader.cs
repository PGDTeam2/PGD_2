using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShader : MonoBehaviour
{
    [SerializeField]
    private Material material;
    [SerializeField]
    private bool on;


    public void Switch(bool on)
    {
        this.on = on;
        material.SetInt("_Boolean", on ? 1 : 0);
    }

    private void Start()
    {
        Switch(on);
    }

    private void OnApplicationQuit()
    {
        Switch(false);
    }
}
