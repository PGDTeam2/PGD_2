using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingRoom : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            other.gameObject.transform.SetParent(gameObject.transform);
            other.gameObject.SetActive(false);
            gameObject.transform.position += new Vector3(0, -100, 0);
            other.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.CompareTag("player"))
        {
            other.gameObject.transform.SetParent(null);
        }*/
    }

    IEnumerator LoadNextLevel()
    {
        var nextScene = "";
        var prevSceneName = SceneManager.GetActiveScene().name;
        AsyncOperation loading = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        Scene sceneToLoad = SceneManager.GetSceneByName(nextScene);

        while (!loading.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("player"), sceneToLoad);
        SceneManager.SetActiveScene(sceneToLoad);

        SceneManager.UnloadSceneAsync(prevSceneName);

        door2.SetActive(false);
    }
}
