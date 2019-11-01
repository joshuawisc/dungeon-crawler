using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Item> list = new List<Item>();
    public GameObject player;
    public GameObject InventoryPanel;
    public static Inventory instance;

    void updatePanelSlots()
    {
       int index = 0;
        foreach(Transform child in InventoryPanel.transform)
        {
            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if(index < list.Count)
            {
                slot.item = list[index];
            }
            else
            {
                slot.item = null;
            }
            slot.UpdateInfo();
            index++;
        }
    }
    void Start()
    {
        instance = this;
        updatePanelSlots(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add(Item item)
    {
        if (list.Count < 1) {
            list.Add(item);
        }
        updatePanelSlots();
    }

    public void Remove(Item item)
    {
        list.Remove(item);
        updatePanelSlots();
    }
}
