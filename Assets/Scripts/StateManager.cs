using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject inventoryUI;

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

        if (Input.GetKeyDown(KeyCode.E))
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
    }
}
