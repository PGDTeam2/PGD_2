using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private Transform backPoint;

    private bool alreadyTriggered = false;
    public Dialogue dialogue;
    private Animator animator;

    void Start()
    {
    animator = GetComponent<Animator>();    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!alreadyTriggered)
        {
            player.canMove = false;

            TriggerDialogue();
            alreadyTriggered = true;
        }
    }

    private void Update()
    {
        if (dialogueManager.walkBack)
        {
            animator.SetBool("walkBack",true);
            transform.position = Vector3.MoveTowards(transform.position, backPoint.transform.position, 0.01f);
            Vector3 direction = (backPoint.transform.position-transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction);

            player.canMove = true;
        }

        if (transform.position == backPoint.transform.position)
        { 
            animator.SetBool("walkBack", false);
            dialogueManager.walkBack = false;
        }

    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

}
