using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	// this script manages every dialogue in the game.
	
	public TextMeshProUGUI nameText;
	public TextMeshProUGUI dialogueText;
	public GameObject dialogueScreen;
	internal bool walkBack;
	internal bool alreadyTriggered = false;

	private Queue<string> sentences;

	// Use this for initialization
	void Start()
	{
		sentences = new Queue<string>();
	}
    private void Update()
    {
        
    }

    public void StartDialogue(Dialogue dialogue)
	{
		dialogueScreen.SetActive(true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		dialogueScreen.SetActive(true);
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return new WaitForSeconds(0.06f);
		}
	}

	void EndDialogue()
	{
		walkBack = true;
		dialogueScreen.SetActive(false);
	}
	internal IEnumerator unloadSentence()
	{
		yield return new WaitForSeconds(6);
		dialogueScreen.SetActive(false);
	}
}