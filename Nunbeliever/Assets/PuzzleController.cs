using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField]
    public GameObject puzzleResult;

    public int puzzlePiecesNeeded;

    public int activatedPuzzlePieces = 0;

    public bool platesStayOn = false;

    public bool multipleUsePlates = false;

    public bool orderPuzzle = false;

    public string correctOrder;

    private string inputOrder = "";

    private bool puzzleComplete = false;

    private PressurePlate[] pressurePlates;

    private void Awake()
    {
        pressurePlates = GetComponentsInChildren<PressurePlate>();

        Debug.Log(pressurePlates.Length);
    }

    private void Update()
    {

        if (activatedPuzzlePieces >= puzzlePiecesNeeded && !puzzleComplete)
        {
            //Debug.Log(inputOrder);
            if (orderPuzzle)
            {
                if (inputOrder == correctOrder)
                {
                    puzzleComplete = true;
                }
                else
                {
                    resetCharacters();
                }
            }
            else
            {
                puzzleComplete = true;
            }
        }

        if (activatedPuzzlePieces < puzzlePiecesNeeded)
        {
            puzzleComplete = false;
        }


        //Testing only
        if (puzzleComplete)
        {
            puzzleResult.transform.rotation = Quaternion.LookRotation(new Vector3(Random.Range(0, 2), 0, 0), new Vector3(0, 1, 0));
        }
    }

    public void addCharacter(char input)
    {
        inputOrder += input;
    }

    public void removeCharacter(char input)
    {
        for (int i = 0; i < inputOrder.Length; i++)
        {
            if (inputOrder[i] == input)
            {
                inputOrder.Remove(i);
            }
        }
    }

    public void resetCharacters()
    {
        inputOrder = "";


        pressurePlates = GetComponentsInChildren<PressurePlate>();


        foreach (PressurePlate plate in pressurePlates)
        {
            plate.ResetButton();
        }
    }


}
