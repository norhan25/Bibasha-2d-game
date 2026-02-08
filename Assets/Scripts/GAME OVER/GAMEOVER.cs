using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEOVER : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsOver = false;
    public GameObject GameOverUI;
    // Update is called once per frame
    void Update()
    {
        if(Respawn.GameOver == true)
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsOver = true;
            //Respawn.GameOver = false;
        }
        else if(Respawn.GameOver == false)
        {
            
            GameOverUI.SetActive(false);
            GameIsOver = false;
            
        }

        
    }

}