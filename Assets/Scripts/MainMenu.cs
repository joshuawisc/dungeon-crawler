using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadGame()
    {
        Debug.Log("Load Game Screen...");
       // SceneManager.LoadScene("LoadGame");
    }

    public void LoadSystemSettings()
    {
        Debug.Log("Loading System Settings...");
        //SceneManager.LoadScene("System Settings");
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
    
}
