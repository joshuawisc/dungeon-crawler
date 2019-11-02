using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool inInventory = false;

    // Update is called once per frame
    public static void openInventory(GameObject inventoryUI)
    {
        inventoryUI.SetActive(true);
        Time.timeScale = 0f;
        inInventory = true;
    }

    public static void closeInventory(GameObject inventoryUI)
    {
        inventoryUI.SetActive(false);
        Time.timeScale = 1f;
        inInventory = false;
    }

    public void closeInventoryClick(GameObject inventoryUI)
    {
        inventoryUI.SetActive(false);
        Time.timeScale = 1f;
        inInventory = false;
    }
}
