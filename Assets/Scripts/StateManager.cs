using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject inventoryUI;
    public GameObject playerChar;
    public int currLevel = 1;
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

        if (Input.GetKeyDown(KeyCode.E) && !PauseMenu.isPaused)
        {
            if (InventoryMenu.inInventory)
            {
                InventoryMenu.closeInventory(inventoryUI);
            }
            else
            {
                InventoryMenu.openInventory(inventoryUI);
            }
        }
        if (currLevel == 1)
        {
            if (playerChar.transform.position.x > 390)
            {
                currLevel = 2;
                SceneManager.LoadScene("Level2");
            }
        }
    }

    public void SavePlayer ()
    {
        SaveSystem.SavePlayer(playerChar, this);
    }

    public void LoadPlayer()
    {
        PlayerInfo info = SaveSystem.LoadPlayer();

        if (info.level == 1 || currLevel != 1)
        {
            SceneManager.LoadScene("BasicMap10.31");
            currLevel = 1;
        } else if (info.level == 2)
        {
            SceneManager.LoadScene("Level2");
            currLevel = 2;
        }
        Vector3 position;
        position.x = info.position[0];
        position.y = info.position[1];
        position.z = info.position[2];
        playerChar.transform.position = position;
    }
    
}
