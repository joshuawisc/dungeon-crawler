using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour , IPointerClickHandler
{
    public Item currentItem;
    public RawImage SlotIcon;
    public Image itemIcon;
    private bool validated = false;
    public int monoIndex = 0;


    private void OnValidate()
    {
        if (!validated)
        {
            validated = true;
            SlotIcon = GetComponent<RawImage>();
        }
    }

    public void Update()
    {
        getIcon();
    }

    private void getIcon()
    {
        if(currentItem != null)
        {
            SlotIcon.texture = currentItem.icon;
        }
        

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click Slot: " + monoIndex);
        InventoryMenu.useItemSlot(monoIndex);
    }

    
    
}
