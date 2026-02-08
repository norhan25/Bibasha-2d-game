using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hero_health : MonoBehaviour
{
    // Start is called before the first frame update
    static public float currhealth;
    static float maxhealth = 100f;
    static public Animator Playeranim;
    static public Image healthbar;
    
    
    
    
    // This variable will hold the value of heart_pickup, which will be max 2 times and then we will destroy that heart object

    int health_count;            
    void Start()
    {
        currhealth = maxhealth;
        healthbar = GameObject.FindGameObjectWithTag("Healthbar").GetComponent<Image>();
        
        Playeranim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.tag == "Obstacle" && currhealth > 0)
        {
            TakeDamage(10);                    //obstacle damage is 5
        }
        else if (collision.gameObject.tag == "Health_Tag" && currhealth < 100)
        {
            currhealth += 5;                   // health increment 
            health_count++;
            healthbar.fillAmount = currhealth / maxhealth;

            SoundManager.PlaySound("HPickup");

            if (health_count == 2)
            {
                Destroy(collision.gameObject);
                health_count = 0;
            }

        }
    }

    public static void TakeDamage(int damage)
    {
        currhealth -= damage;
        healthbar.fillAmount = currhealth / maxhealth;

        Playeranim.SetTrigger("isHurt");
        SoundManager.PlaySound("hurt");

    }

}
