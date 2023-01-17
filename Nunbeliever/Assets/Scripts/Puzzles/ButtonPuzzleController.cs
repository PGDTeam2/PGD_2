using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPuzzleController : MonoBehaviour
{
    internal static ButtonPuzzleController instance;

    [SerializeField] private Button[] buttons;
    [SerializeField] private AudioSource gramophone;
    [SerializeField] private NightStandPickup nightstand;

    private int pressedIndex;
    private bool finished;

    private void Awake()
    {
        instance = this;
    }

    public void ButtonPressed(Button button)
    {
        if (!finished)
            StartCoroutine(CheckButton(button));
    }

    private IEnumerator CheckButton(Button button)
    {
        button.SetState(true);

        yield return new WaitForSeconds(1f);

        if (button == buttons[pressedIndex])
        {
            pressedIndex++;
            if (pressedIndex >= buttons.Length)
            {
                finished = true;
                OnFinishPuzzle();
            }
        }
        else
        {
            pressedIndex = 0;
            OnFailPuzzle();
        }
    }

    private void OnFailPuzzle()
    {
        gramophone.pitch -= 0.05f;
        foreach (var button in buttons)
        {
            button.SetState(false);
        }
    }

    private void OnFinishPuzzle()
    {
        gramophone.pitch = 1;
        nightstand.Open();
    }
}
