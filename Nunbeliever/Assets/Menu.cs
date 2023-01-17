using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    PlayerController playerController;
    public bool Continue;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            menu.SetActive(true);
        }

        if (menu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            playerController.canMove = false;
            Time.timeScale = 0;
        }
        else
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1;
        }
        
    }
   public void DeactivateMenu()
    {
        playerController.canMove = true;
        menu.SetActive(false);
    }

    public void RestartLevel()
    {
        var curScene = SceneManager.GetActiveScene().name;
        GetComponent<FadeOut>().switchscene(curScene);
    }
}
