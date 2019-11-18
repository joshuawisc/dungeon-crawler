using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item currentItem;
    public RawImage SlotIcon;
    public Image itemIcon;
    private bool validated = false;


    private void OnValidate()
    {
        if (!validated)
        {
            validated = true;
            SlotIcon = GetComponent<RawImage>();
        }
    }

    void Update()
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
    
}
