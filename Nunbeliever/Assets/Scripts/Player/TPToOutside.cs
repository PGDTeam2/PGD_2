using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TPToOutside : MonoBehaviour
{
    private GameObject spawnPoint;
    private GameObject whiteOutPanel;
    private GameObject outsideLight;
    private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            spawnPoint = GameObject.FindWithTag("OutsideSpawn");
            whiteOutPanel = GameObject.FindWithTag("WhiteOutPanel");
            outsideLight = GameObject.FindWithTag("OutsideLight");
            player = other.gameObject;
            StartCoroutine(DoTransition());
        }
    }

    IEnumerator DoTransition()
    {
        var image = whiteOutPanel.GetComponent<Image>();
        float t = 0;
        while (t < 1f)
        {
            t += 0.01f;
            image.color = new Color(1f, 1f, 1f, t);
            yield return null;
        }
        player.transform.position = spawnPoint.transform.position;
        player.transform.rotation = spawnPoint.transform.rotation;
        outsideLight.GetComponent<Light>().enabled = true;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Demo"));
        yield return new WaitForSeconds(0.1f);
        while (t > 0f)
        {
            t -= 0.01f;
            image.color = new Color(1f, 1f, 1f, t);
            yield return new WaitForSeconds(0.0002f / Time.deltaTime);
        }
    }
}
