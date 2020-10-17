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
    bool pauseMenuActive = false;

    public void EndGame()
    {
        completeLevelUI.SetActive(true);
        Time.timeScale = 0.0f;
        Invoke("ReloadLevel", 2);
        

    }

    public bool PauseMenuActive
    {
        get { return pauseMenuActive; }
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
