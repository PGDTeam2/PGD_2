using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TPToOutside : MonoBehaviour
{
    private GameObject m_whiteOutPanel;
    [SerializeField] string m_scene;
    [SerializeField] int r;
    [SerializeField] int g;
    [SerializeField] int b;
    private void Awake()
    {
        /*if (!SceneManager.GetSceneByName("Demo").isLoaded)
            SceneManager.LoadSceneAsync("Demo", LoadSceneMode.Additive);*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            //m_spawnPoint = GameObject.FindWithTag("OutsideSpawn");
            m_whiteOutPanel = GameObject.FindWithTag("WhiteOutPanel");
            //m_outsideLight = GameObject.FindWithTag("OutsideLight");
            //m_player = other.gameObject;
            StartCoroutine(DoTransition(m_scene, r, g, b));
        }
    }

    IEnumerator DoTransition(string scene,int r, int g, int b)
    {
        var image = m_whiteOutPanel.GetComponent<Image>();

        // Fade in white screen
        float t = 0;
        while (t < 1f)
        {
            t += 0.01f;
            image.color = new Color(r, g, b, t);
            yield return null;
        }
        SceneManager.LoadScene(scene);

        // Set Player transform
        //m_player.transform.position = m_spawnPoint.transform.position;
       // m_player.transform.rotation = m_spawnPoint.transform.rotation;

        // Switch lighting and scene
       // SceneManager.SetActiveScene(SceneManager.GetSceneByName("Demo"));
        //m_outsideLight.GetComponent<Light>().enabled = true;

        yield return new WaitForSeconds(0.1f);

        // Fade out white screen
        /*while (t > 0f)
        {
            t -= 0.01f;
            image.color = new Color(1f, 1f, 1f, t);
            yield return new WaitForSeconds(0.0002f / Time.deltaTime);
        }
        if(t < 0f)
        {
          StartCoroutine(wakeUp());
        }*/
    }

}
