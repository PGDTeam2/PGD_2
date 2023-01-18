using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class NoteText : MonoBehaviour
{

    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject Object;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Nun"))
        {
            StartCoroutine(TextFade(0, 1));
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Nun"))
        {
            StartCoroutine(TextFade(1, 0));
        }
    }
    IEnumerator TextFade(float start, float end)
    {
        float duration = 1f; //Fade out over 1 seconds.
        float currentTime = 0f;
        while (currentTime < duration)
        {
            float alpha = Mathf.Lerp(start, end, currentTime / duration);
            Debug.Log(alpha);
            text.color = new Color(255, 255, 255, alpha);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }

}
