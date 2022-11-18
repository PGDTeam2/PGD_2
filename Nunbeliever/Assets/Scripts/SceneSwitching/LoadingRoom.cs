using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingRoom : MonoBehaviour
{
    [SerializeField] private GameObject door1;
    [SerializeField] private GameObject door2;
    [SerializeField] private string nextScene;
    private bool isSwitching;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            door1.SetActive(true);
            if(!isSwitching)
            {
                isSwitching = true;
                StartCoroutine(LoadNextLevel());
            }
        }
    }

    IEnumerator LoadNextLevel()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        Scene sceneToLoad = SceneManager.GetSceneByName(nextScene);

        while (!loading.isDone)
        {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("player"), sceneToLoad);
        SceneManager.SetActiveScene(sceneToLoad);

        SceneManager.UnloadSceneAsync("SampleScene");

        door2.SetActive(false);
    }
}
