using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{


    [SerializeField] Player player;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] KeyCode menuToggle;

    public GameObject completeLevelUI;
    public UIManager gameManager;
    bool pauseMenuActive = false;
    bool isPaused = false;

    public void pauseGame()
    {
        if (isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;

        }
        else 
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    public void OnTriggerEnter()
    {
        SceneManager.LoadScene("EndMenu");
    }

    public void EndGame()
    {
        completeLevelUI.SetActive(true);
    }

    public bool PauseMenuActive
    {
        get { return pauseMenuActive; }
    }

    public void MainMenuReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Start()
    {
        if (pauseMenu != null) pauseMenu.SetActive(false);
    }

    void Update()
    {

        if (pauseMenu != null)
        {
            if (Input.GetKeyUp(menuToggle)) pauseMenuActive = !pauseMenuActive;

            if (pauseMenuActive)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1.0f;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }


    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitDemo()
    {
        Application.Quit();
    }
}
