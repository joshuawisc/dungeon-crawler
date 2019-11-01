using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    // Start is called before the first frame update
    public Item item;

    public void use()
    {
        if (item)
        {
            Debug.Log("You Clicked" + item.name);
        }
    }

    public void UpdateInfo()
    {
        Text displayText = transform.Find("Text").GetComponent<Text>();
        Image displayImage = transform.Find("Image").GetComponent<Image>();

        if (item)
        {
            displayText.text = item.name;
            displayImage.sprite = item.image;
            displayImage.color = Color.white;
        }

        else
        {
            displayText.text = "";
            displayImage.sprite = null;
        }
    }

    private void Start()
    {
        UpdateInfo();
        
    }
}
