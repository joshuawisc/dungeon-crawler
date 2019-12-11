using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public static Vector3 posi = new Vector3(3.5f , 5.3f , 1.5f);

    public GameObject camera;
    public GameObject pauseMenuUI;
    public GameObject inventoryUI;
    public GameObject playerChar;
    public int currLevel = 1;
    // Update is called once per frame


    void Start()
    {
        GameObject prefab = Resources.Load<GameObject>("Player");
        playerChar = Instantiate(prefab) as GameObject;
        playerChar.transform.position = posi;
        Camera.main.GetComponent<CameraController>().lookAt = playerChar.transform;
        GameObject e = GameObject.Find("Enemy");
        if(e != null)
        {
            e.GetComponent<EnemyController>().target = playerChar;
        }
        
        //Debug.Log(pos);
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (PauseMenu.isPaused)
            {
                PauseMenu.Resume(pauseMenuUI);
            } else
            {
                PauseMenu.Pause(pauseMenuUI);
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !PauseMenu.isPaused)
        {
            if (InventoryMenu.inInventory)
            {
                InventoryMenu.closeInventory(inventoryUI);
            }
            else
            {
                InventoryMenu.openInventory(inventoryUI , playerChar);
            }
        }
        if (currLevel == 1)
        {
            if (playerChar.transform.position.x > 390)
            {
                currLevel = 2;
                SceneManager.LoadScene("Level2");
            }
        }
    }

    public void SavePlayer ()
    {
        SaveSystem.SavePlayer(playerChar, this);
    }

    public void LoadPlayer()
    {
        PlayerInfo data = SaveSystem.LoadPlayer();

        //SceneManager.LoadScene("BasicMap10.31");

        SceneManager.LoadScene(data.currentScene);
        

        

        GameObject player = Resources.Load<GameObject>("Player");
        if(player != null)
        {
            Vector3 pos = new Vector3(data.playerObject[0], data.playerObject[1], data.playerObject[2]);
            //player.transform.position = new Vector3(0,0,0);

            posi = pos;
            //GameObject ret = Instantiate(player) as GameObject;
            //ret.transform.position = pos;
            //Camera.main.GetComponent<CameraController>().lookAt = ret.transform;
            //Debug.Log(pos);

        }
        


        //Vector3 position;
        
        //playerChar.transform.position = position;
    }
    
    public void setup()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
    }

}
