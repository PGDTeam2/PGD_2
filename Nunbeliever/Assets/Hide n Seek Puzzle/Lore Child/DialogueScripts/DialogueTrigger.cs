using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    /* This script is made for the dialogues coming from evan
     * when you come close to him as a player this will trigger
     */

    [SerializeField] private PlayerController player;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private Transform backPoint;

    public Dialogue dialogue;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!dialogueManager.alreadyTriggered)
        {
            if (dialogueManager.walkBack) 
            { 
            player.canMove = false; // the player can't move in this dialogue
             }
            TriggerDialogue();
            animator.SetTrigger("Talk"); //animation for evan to talk
            dialogueManager.alreadyTriggered = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("House d3"))
        {
            dialogueManager.DisplayNextSentence();
        }
    }
    private void Update()
    {
        if (dialogueManager.walkBack)
        {
            animator.SetBool("walkBack", true);
            animator.ResetTrigger("Talk");

            //when hes done talking he will walk back to his old position
            transform.position = Vector3.MoveTowards(transform.position, backPoint.transform.position, 0.02f);
            Vector3 direction = (backPoint.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);

            string[] temp = new string[1];
            temp[0] = "I'll just wait here..";
            dialogue.sentences = temp;
            if (dialogueManager.alreadyTriggered)
            {
                player.canMove = true;
            }
            
        }

        if (transform.position == backPoint.transform.position)
        {
            animator.SetBool("walkBack", false);
            dialogueManager.walkBack = false;
            dialogueManager.alreadyTriggered = false;
        }

    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
