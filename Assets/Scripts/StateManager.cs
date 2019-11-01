using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (PauseMenu.isPaused)
             {
                PauseMenu.Resume(pauseMenuUI);
             } else
             {
                PauseMenu.Pause(pauseMenuUI);
            }
        }
    }
}
