using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScriptOnce : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] public Dialogue dialogue;
    [SerializeField] private float waitingTime;
    public GameObject SceneSwitch;
    CareGiverSM careGiverSM;

    // Start is called before the first frame update
    void Start()
    {
        careGiverSM = GameObject.FindGameObjectWithTag("Nun").GetComponent<CareGiverSM>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollideOnce"))
        {

            StartCoroutine(careGiverSM.goBackToPatrol());
            careGiverSM.currentState = careGiverSM.searchState;
            if (!dialogueManager.alreadyTriggered)
            {
                SceneSwitch.SetActive(true);
                dialogueManager.alreadyTriggered = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                other.gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
                dialogueManager.DisplayNextSentence();
            }

        }
    }

}
