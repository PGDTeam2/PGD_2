using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialoque : MonoBehaviour
{
    public Text textToShow;

    private void OnTriggerEnter(Collider other)
    {
        textToShow.gameObject.SetActive(true);
    }
}
