using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerData : MonoBehaviour
{
    private BaseStats stats;
    private CombatScript cs;

    private int inventorySize = 25;  //5x5
    private Inventory inventory;
    private Transform playerObject;


    private string currentScene = "Level2";
    //private Vector3 currentPos;


    private GameObject playerRef;

    void Start()
    {
        
        cs = GetComponent<CombatScript>();
        playerObject = GetComponent<Transform>();
        Debug.Log(playerObject.position.x);
        inventory = new Inventory(this);
        //Placeholder Inventory
        for(int i = 0; i < inventorySize; i++)
        {
            Item item = Resources.Load<Item>("Items/Potion");

            inventory.addItem(item);
        }

        

    }

    void Update()
    {
        
        stats = cs.stats;
    }

    public Inventory getInventoryObject()
    {
        return inventory;
    }

    public List<Item> getInventoryList()
    {
        return inventory.getInventoryList();
    }

    public string getCurrMap()
    {
        return currentScene;
    }

    public Transform getPlayerPos()
    {
        return playerObject;
    }

    public PlayerInfo serialize()
    {
        return new PlayerInfo(inventory.getInventoryList(), playerObject, currentScene);
    }

}
