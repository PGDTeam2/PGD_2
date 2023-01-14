using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShader : MonoBehaviour
{
    [SerializeField]
    private Material material;
    [SerializeField]
    private bool on;

    public bool Switch { set { on = value; } }

    private void Start()
    {
        material.SetInt("_Boolean", on ? 1 : 0);
    }

    private void OnApplicationQuit()
    {
        material.SetInt("_Boolean", 0);
    }
}
