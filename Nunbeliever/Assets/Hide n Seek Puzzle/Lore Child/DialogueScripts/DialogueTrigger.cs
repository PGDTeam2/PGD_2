using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private bool alreadyTriggered = false;
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    {
        TriggerDialogue();
    }
    public void TriggerDialogue()
	{
        if (!alreadyTriggered)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            alreadyTriggered = true;
        }
	}

}
