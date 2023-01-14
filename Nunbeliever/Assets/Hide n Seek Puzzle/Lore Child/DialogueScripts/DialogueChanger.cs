using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DialogueChanger : MonoBehaviour
{
    /* This script is made for the dialogues coming from evan
     * when you come close to him as a player this will trigger
     */

    [SerializeField] private PlayerController player;
    [SerializeField] private DialogueTrigger Evan;

    public Dialogue newDialogue;
    private bool dialogueChanged = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!dialogueChanged)
        {
            Evan.dialogue = newDialogue;
            dialogueChanged = true;
        }
    }
}
