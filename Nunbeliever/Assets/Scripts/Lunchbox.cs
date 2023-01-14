using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lunchbox : MonoBehaviour
{
    [SerializeField] private DialogueTrigger Evan;

    public Dialogue newDialogue;
    private bool opened = false;


    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && !opened)
        {
            Evan.dialogue = newDialogue;
            opened = true;
            Destroy(gameObject);
        }

    }
}
