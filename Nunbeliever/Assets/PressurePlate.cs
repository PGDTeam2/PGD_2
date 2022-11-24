using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private PuzzleController puzzleController;
    private ParticleSystem.EmissionModule particles;
    private bool remainPressed;
    private bool multiUse;
    public char puzzleInput;

    private bool pressed = false;
    private int thingsOnPlate = 0;

    private void Awake()
    {

        puzzleController = GetComponentInParent<PuzzleController>();
        remainPressed = puzzleController.platesStayOn;
        multiUse = puzzleController.multipleUsePlates;
    }

    private void OnTriggerEnter(Collider other)
    {
        thingsOnPlate++;
        if (!pressed)
        {
            pressed = true;
            puzzleController.activatedPuzzlePieces++;

            GetComponentInChildren<ParticleSystem>().Play();


            if (puzzleController.orderPuzzle)
            {
                //Debug.Log(puzzleInput);
                puzzleController.AddCharacter(puzzleInput);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        thingsOnPlate--;
        if(pressed && thingsOnPlate <= 0 && !remainPressed)
        {
            pressed = false;
            puzzleController.activatedPuzzlePieces--;

            GetComponentInChildren<ParticleSystem>().Stop();

            if (puzzleController.orderPuzzle && !multiUse)
            {
                puzzleController.RemoveCharacter(puzzleInput);
            }
        }
    }

    public void ResetButton()
    {
        if(pressed) puzzleController.activatedPuzzlePieces--;
        pressed = false;
        //maybe eject the things on the plate
        GetComponentInChildren<ParticleSystem>().Stop();
    }
}
