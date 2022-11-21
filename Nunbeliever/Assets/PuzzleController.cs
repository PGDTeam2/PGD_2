using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField]
    public GameObject puzzleResult;

    public int puzzlePiecesNeeded;

    public int activatedPuzzlePieces = 0;
    
    private bool puzzleComplete = false;

    private void Update()
    {
        if (activatedPuzzlePieces >= puzzlePiecesNeeded && !puzzleComplete)
        {
            Debug.Log("yeeeeeeeeeeeeee");
            puzzleComplete = true;
        }
    }

}
