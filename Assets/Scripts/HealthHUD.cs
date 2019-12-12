using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Text healthText;
    public Vector2 pos = new Vector2(60, 60);
    public Vector2 size = new Vector2(200, 20);
    public Texture2D fullTex;
    public Texture2D emptyTex;
    public float fill = 0f;


    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x*fill, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }



    // Update is called once per frame
    void Update()
    {
        BaseStats stats = GameObject.Find("Player(Clone)").GetComponent<CombatScript>().stats;
        fill = (float)stats.health / (float)stats.maxHealth;
        healthText.text = "Health: " + GameObject.Find("Player(Clone)").GetComponent<CombatScript>().stats.health.ToString();
    }
}
