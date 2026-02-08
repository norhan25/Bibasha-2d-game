using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    static AudioSource SRC;
    //static AudioClip jump,dead, healthpickup, coinpickup,hurt,run;
    static AudioClip hurt,dead,jump,  fall, run,money, healthpickup, PlayerAttack;

    void Start()
    {
        SRC = GetComponent<AudioSource>();
        jump = Resources.Load<AudioClip>("jump");
        healthpickup = Resources.Load<AudioClip>("health_pickup");
        PlayerAttack = Resources.Load<AudioClip>("PlayerAttack");
        hurt = Resources.Load<AudioClip>("hurt");
        run = Resources.Load<AudioClip>("run");
        money = Resources.Load<AudioClip>("MoneyPickup");
        fall = Resources.Load<AudioClip>("falling");
        dead = Resources.Load<AudioClip>("dead");
    }

    // Update is called once per frame
    static public void PlaySound(string clipname) 
    {
        //switch (clipname)
        //{
        //    case "jump":
        //        src.playoneshot(jump);
        //        break;

        //    case "hpickup":
        //        src.playoneshot(healthpickup);
        //        break;
        //    case "cpickup":
        //        src.playoneshot(coinpickup);
        //        break;

        //    case "hurt":
        //        src.playoneshot(hurt);
        //        break;
        //    case "run":
        //        src.playoneshot(run);
        //        break;
        //    case "dead":
        //        src.playoneshot(dead);
        //        break;
        //}

        switch (clipname)
        {
            case "jump":
                SRC.PlayOneShot(jump);
                break;

            
            case "fall":
                SRC.PlayOneShot(fall);
                break;


            case "hurt":
                SRC.PlayOneShot(hurt);
                break;

            case "run":
                SRC.PlayOneShot(run);
                break;

            case "dead":
                SRC.PlayOneShot(dead);
                break;

            case "money":
                SRC.PlayOneShot(money);
                break;

            case "HPickup":
                SRC.PlayOneShot(healthpickup);
                break;

            case "PlayerAttack":
                SRC.PlayOneShot(PlayerAttack);
                break;


        }
    }
}
