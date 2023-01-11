using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class FadeOut : MonoBehaviour
{
    private GameObject m_whiteOutPanel;
    [SerializeField] string m_scene;
    [SerializeField] int r;
    [SerializeField] int g;
    [SerializeField] int b;
    [Tooltip("Time to fade"), SerializeField] float waitTime;
    AudioSource audioSource;
    public AudioClip clip;
    public bool audioIncluded;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            m_whiteOutPanel = GameObject.FindWithTag("WhiteOutPanel");
            StartCoroutine(DoTransition(m_scene, r, g, b));
        }
    }
    public void switchscene(string name)
    {
        m_whiteOutPanel = GameObject.FindWithTag("WhiteOutPanel");
        StartCoroutine(DoTransition(name, r, g, b));
    }
    IEnumerator DoTransition(string scene,int r, int g, int b)
    {
        var image = m_whiteOutPanel.GetComponent<Image>();

        // Fade in white screen
        float t = 0;
        while (t < 1f)
        {
            if (audioIncluded)
            {
                audioSource.PlayOneShot(clip);
                audioIncluded = false;
            }

            t += waitTime;
            image.color = new Color(r, g, b, t);
            yield return null;
        }
        SceneManager.LoadSceneAsync(scene);
        yield return new WaitForSeconds(0.1f);

    }
    public void exit()
    {
        Application.Quit();
    }

}
