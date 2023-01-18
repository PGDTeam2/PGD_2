using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InnerDialogue : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene() != SceneManager.GetSceneByName("House d3"))
        {
            dialogueManager.DisplayNextSentence();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DialogueTrigger"))
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
