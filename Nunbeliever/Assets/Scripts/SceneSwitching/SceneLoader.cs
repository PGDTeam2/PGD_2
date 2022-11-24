using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SceneTransition
{
    public string SourceScene;
    public string TargetScene;
}

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private SceneTransition[] transitions;

    internal static SceneLoader instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void TriggerTransition()
    {

    }
}
