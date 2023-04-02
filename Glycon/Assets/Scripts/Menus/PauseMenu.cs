using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        GameObject playerObject = GameObject.Find("Player");
        FirstPersonController firstPersonController = playerObject.GetComponent<FirstPersonController>();
        firstPersonController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused= false;
    }

    void Pause()
    {
        GameObject playerObject = GameObject.Find("Player");
        FirstPersonController firstPersonController = playerObject.GetComponent<FirstPersonController>();
        firstPersonController.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
