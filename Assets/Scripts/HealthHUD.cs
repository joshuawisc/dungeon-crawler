using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Text healthText;
    
    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = "Health: " + GameObject.Find("Player").GetComponent<CombatScript>().stats.health.ToString();
    }
}
