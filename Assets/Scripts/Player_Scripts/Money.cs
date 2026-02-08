using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Money : MonoBehaviour
{
    public int player_money;
    Level_Manager LM_obj;
   
    // Start is called before the first frame update
    void Start()
    {
        LM_obj = FindObjectOfType<Level_Manager>();
    }

    // Update is called once per frame
     

    private void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag.Equals("IBASHA"))
        {
            player_money += 100; 

            SoundManager.PlaySound("money");
            LM_obj.Coins_Counter(player_money);
            Destroy(gameObject);
        }
    }

}
