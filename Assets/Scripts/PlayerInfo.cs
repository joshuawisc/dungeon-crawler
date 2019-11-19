using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public string currentScene;
    public float[] playerObject;
    //public List<Item> Inventory;
    

    public PlayerInfo (List<Item> inv , Transform trn , string scn)
    {
        currentScene = scn;
        //Inventory = inv;
        playerObject = new float[3];
        playerObject[0] = trn.position.x;
        playerObject[1] = trn.position.y;
        playerObject[2] = trn.position.z;

    }
}
