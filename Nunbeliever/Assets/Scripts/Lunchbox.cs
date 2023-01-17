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
        switchScene.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && !opened)
        {
            Evan.dialogue = newDialogue;
            opened = true;
            Destroy(gameObject);
            switchScene.SetActive(true);
        }

    }
}
