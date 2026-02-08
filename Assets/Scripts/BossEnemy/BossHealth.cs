using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealth : MonoBehaviour
{
    // Start is called before the first frame update
    static public float currhealth;
    static float maxhealth = 100f;
    static public Animator Bossanim;
    



    // This variable will hold the value of heart_pickup, which will be max 2 times and then we will destroy that heart object

    int health_count;
    void Start()
    {
        currhealth = maxhealth;
        Bossanim = GetComponent<Animator>();
    }

    

    public static void TakeDamage(int damage)
    {
        currhealth -= damage;
         
        Bossanim.SetTrigger("Hurt");
        
    }

}
