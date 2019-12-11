using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private List<Item> inventory;
    private PlayerData holderData;

    public Inventory(PlayerData holder)
    {
        holderData = holder;
        inventory = new List<Item>();
    }

    public Item[,] getInv()
    {
        int monocount = 0;
        Item[,] arrayTransform = new Item[5, 5];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                arrayTransform[i, j] = inventory[monocount];
                monocount++;
            }
        }
        return arrayTransform;
    }

    public void addItem(Item addition)
    {
        inventory.Add(addition);
    }

    public void useItem(int x, int y)
    {
        int monoindex = toMonoIndex(x, y);
        useItem(monoindex);
    }

    public void useItem(int monoindex)
    {
        Item use = inventory[monoindex];
        Item rep = ScriptableObject.CreateInstance<Item>();
        rep.iid = "00";
        rep.icon = Resources.Load<Texture>("Items/itembg");

        if (use.iid.Equals("01"))
        {
            holderData.tempheal(50);
        }
        inventory[monoindex] = rep;
    }

    public void removeItem(int x, int y)
    {
        int monoindex = toMonoIndex(x, y);
        inventory.RemoveAt(monoindex);
    }

    private int toMonoIndex(int x, int y)
    {
        int mi = 0;
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                mi++;
            }
        }
        return mi;
    }

    public List<Item> getInventoryList()
    {
        return inventory;
    }

}
