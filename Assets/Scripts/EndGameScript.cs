using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Unfounded_scene");
    }

    public void ExitDemo()
    {
        Application.Quit();
    }
    
    public void MainMenuReturn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
