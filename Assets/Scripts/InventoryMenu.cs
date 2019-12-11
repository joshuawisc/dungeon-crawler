using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool inInventory = false;
    private static GameObject pc;
    private static bool isValidated = false;
    private static Inventory inv;
    private static ItemSlot[] UISlots;
    
    // Update is called once per frame
    public static void openInventory(GameObject inventoryUI , GameObject playerChar)
    {
        pc = playerChar;
        inv = playerChar.GetComponent<PlayerData>().getInventoryObject();
        // Get Inventory from Player
        List<Item> inventory = playerChar.GetComponent<PlayerData>().getInventoryList();
        GameObject inventoryMenuChild = inventoryUI.transform.GetChild(0).gameObject;
        UISlots = inventoryMenuChild.GetComponentsInChildren<ItemSlot>();

        for (int i = 0; i < UISlots.Length; i++)
        {
            UISlots[i].monoIndex = i;
        }
        isValidated = true;

        for (int i = 0; i < inventory.ToArray().Length; i ++)
        {
            if(inventory[i] != null)
            {
                UISlots[i].currentItem = inventory[i];
            }
            else
            {
                UISlots[i].currentItem = new Item() { iid = "00", icon = Resources.Load<Texture>("Items/itembg") };

            }
        }

        inventoryUI.SetActive(true);
        Time.timeScale = 0f;
        inInventory = true;
    }

    void Update()
    {

        List<Item> inventory = pc.GetComponent<PlayerData>().getInventoryList();
        GameObject inventoryMenuChild = pc.transform.GetChild(0).gameObject;
        



        for (int i = 0; i < inventory.ToArray().Length; i++)
        {
            if (inventory[i] != null)
            {
                //Debug.Log(UISlots.Length);
                UISlots[i].currentItem = inventory[i];
            }
            else
            {
                UISlots[i].currentItem = new Item() { iid = "00", icon = Resources.Load<Texture>("Items/itembg") };
            }
        }

        for (int i = 0; i < UISlots.Length; i ++)
        {
            UISlots[i].Update();
        }
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

    public static void useItemSlot(int monoindex)
    {
        inv.useItem(monoindex);
    }
}
