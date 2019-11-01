using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    // Update is called once per frame
   

    public static void Resume(GameObject pauseMenuUI)
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public static void Pause(GameObject pauseMenuUI)
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeClick(GameObject pauseMenuUI)
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Menu");
    }

    public void LoadSystemSettings()
    {
        Debug.Log("Loading System Settings...");
        //SceneManager.LoadScene("System Settings");
    }
    
    public void LoadGameSettings()
    {
        Debug.Log("Loading Game Settings...");
        //SceneManager.LoadScene("Game Settings");
    }
    public void SaveGame()
    {
        Debug.Log("Saving Game..");
        
    }
}
