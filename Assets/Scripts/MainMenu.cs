using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Overworld");
    }

    public void LoadGame()
    {
        //Debug.Log("Loading Load Game Screen...");
       // SceneManager.LoadScene("LoadGame");
    }

    public void LoadOptions()
    {
      //  Debug.Log("Loading Options...");
        //SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        //Debug.Log("Quitting Game");
        Application.Quit();
    }
    
}
