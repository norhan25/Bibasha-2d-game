using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    // Start is called before the first frame update

    public int TotalCash;
    int levelrespawnCompletioncount = 0;
    public static bool lvl1_completed, lvl2_completed, lvl3_completed;

    Text MoneyText;
    void Start()
    {
        MoneyText = GameObject.FindGameObjectWithTag("Money").GetComponent<Text>();   
    }

    // Update is called once per frame
     void Update()
    {
        // Here We r checking for level Completion By Player 
        // In case of Passing One lvl he will transform to next and at the end game over

        if (lvl1_completed == true && levelrespawnCompletioncount==0)
        {
            WaitMoveNxtLvl(10);
            transform.position = Respawn.respawn_lvl2;
            levelrespawnCompletioncount++;
            
        }
        else if (lvl2_completed == true && levelrespawnCompletioncount==1)
        {
            
            WaitMoveNxtLvl(10);
            transform.position = Respawn.respawn_lvl3;
            levelrespawnCompletioncount++;
        }
        else if (lvl3_completed == true && levelrespawnCompletioncount == 2)
        {
            WaitMoveNxtLvl(10);
            Respawn.GameOver = true;
            levelrespawnCompletioncount++;
        }
    }


    public void Coins_Counter(int Score)
    {
        TotalCash += Score;
        MoneyText.text = "Cash: " + TotalCash.ToString() + "$";
        
;    }

    IEnumerator WaitMoveNxtLvl(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
