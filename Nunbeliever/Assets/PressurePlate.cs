using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    PuzzleController puzzleController;
    public bool remainPressed;

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
            Debug.Log("yeet");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(pressed && !remainPressed)
        {
            pressed = false;
            puzzleController.activatedPuzzlePieces--;
            Debug.Log("yote");
        }
    }
}
