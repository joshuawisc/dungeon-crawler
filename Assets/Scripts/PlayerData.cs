using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerData : MonoBehaviour
{
    private BaseStats stats;
    private CombatScript cs;

    private int inventorySize = 25;  //5x5
    private List<Item> Inventory;
    private Transform playerObject;


    private string currentScene = "Level2";
    //private Vector3 currentPos;


    private GameObject playerRef;

    void Start()
    {
        cs = GetComponent<CombatScript>();
        playerObject = GetComponent<Transform>();
        Inventory = new List<Item>();
        //Placeholder Inventory
        for(int i = 0; i < inventorySize; i++)
        {
            Item item = null;
            if (i % 2 == 0 && i < inventorySize/2) item = Resources.Load<Item>("Items/Potion");
            Inventory.Add(item);
        }

        

    }

    void Update()
    {
        
        stats = cs.stats;
    }


    public List<Item> getInventory()
    {
        return Inventory;
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
        return new PlayerInfo(Inventory, playerObject, currentScene);
    }

}
