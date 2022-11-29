using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TPToOutside : MonoBehaviour
{
    private GameObject m_spawnPoint;
    private GameObject m_whiteOutPanel;
    private GameObject m_outsideLight;
    private GameObject m_player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            m_spawnPoint = GameObject.FindWithTag("OutsideSpawn");
            m_whiteOutPanel = GameObject.FindWithTag("WhiteOutPanel");
            m_outsideLight = GameObject.FindWithTag("OutsideLight");
            m_player = other.gameObject;
            StartCoroutine(DoTransition());
        }
    }

    IEnumerator DoTransition()
    {
        var image = m_whiteOutPanel.GetComponent<Image>();

        // Fade in white screen
        float t = 0;
        while (t < 1f)
        {
            t += 0.01f;
            image.color = new Color(1f, 1f, 1f, t);
            yield return null;
        }

        // Set Player transform
        m_player.transform.position = m_spawnPoint.transform.position;
        m_player.transform.rotation = m_spawnPoint.transform.rotation;

        // Switch lighting and scene
        m_outsideLight.GetComponent<Light>().enabled = true;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Demo"));

        yield return new WaitForSeconds(0.1f);

        // Fade out white screen
        while (t > 0f)
        {
            t -= 0.01f;
            image.color = new Color(1f, 1f, 1f, t);
            yield return new WaitForSeconds(0.0002f / Time.deltaTime);
        }
    }
}
