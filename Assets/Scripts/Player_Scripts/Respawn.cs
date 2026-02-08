using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{
    static public Vector3 respawn_lvl1, respawn_lvl2, respawn_lvl3;
    static public int lifecount = 3;
    static public  Text LifeCount;
    static public bool GameOver = false;

    static public Vector3 PlayerNewPosition;
    // Start is called before the first frame update
    void Start()
    {
        //PlayerNewPosition = new Vector3(-2, -1, 0);
        respawn_lvl1 = new Vector3(-2, -1, 0);
        respawn_lvl2 = new Vector3(18, -1, 0);
        respawn_lvl3 = new Vector3(38, -1, 0);
        LifeCount = GameObject.FindGameObjectWithTag("LifeCount").GetComponent<Text>();
    }

    // Update is called once per frame
    static public Vector3  RespawnOnCurrLvl(string collision)
    {
        
        if (collision == "FallDetectorlvl1")
        {
            PlayerNewPosition =  respawn_lvl1;
            
        }
        else if (collision == "FallDetectorlvl2")
        {
            PlayerNewPosition = respawn_lvl2;
            
        }
        else if (collision == "FallDetectorlvl3")
        {
            PlayerNewPosition = respawn_lvl3;
            
        }
        
        
        lifecount--;        // Deducting Life on each respawn

        if (lifecount == 0)
        {
            GameOver = true;
        }
        else {
            // Getting Full HealthBar At a Life Lost
            Hero_health.currhealth = 100;
            Hero_health.healthbar.fillAmount = 1;
            
        }

        LifeCount.text = lifecount.ToString() + "up"; // Displaying Lifes of player

        return PlayerNewPosition;
        
    }
}
