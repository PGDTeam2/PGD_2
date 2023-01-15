using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunchbox : MonoBehaviour
{
    [SerializeField] private DialogueTrigger Evan;
    public GameObject switchScene;

    public Dialogue newDialogue;
    private bool opened = false;

    private void Start()
    {
        switchScene = GameObject.FindGameObjectWithTag("SceneSwitch");
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && !opened)
        {
            switchScene.SetActive(true);
            Evan.dialogue = newDialogue;
            opened = true;
            Destroy(gameObject);
        }

    }
}
