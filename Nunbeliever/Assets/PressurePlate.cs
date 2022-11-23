using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private PuzzleController puzzleController;
    private ParticleSystem.EmissionModule particles;
    public bool remainPressed;
    public char puzzleInput;

    private bool pressed = false;

    private void Awake()
    {

        puzzleController = GetComponentInParent<PuzzleController>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!pressed)
        {
            pressed = true;
            puzzleController.activatedPuzzlePieces++;

            GetComponentInChildren<ParticleSystem>().Play();


            if (puzzleController.orderPuzzle)
            {
                //Debug.Log(puzzleInput);
                puzzleController.addCharacter(puzzleInput);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(pressed && !remainPressed)
        {
            pressed = false;
            puzzleController.activatedPuzzlePieces--;

            GetComponentInChildren<ParticleSystem>().Stop();

            if (puzzleController.orderPuzzle)
            {
                puzzleController.removeCharacter(puzzleInput);
            }
        }
    }

    public void ResetButton()
    {
        if(pressed) puzzleController.activatedPuzzlePieces--;
        pressed = false;
        GetComponentInChildren<ParticleSystem>().Stop();
    }
}
