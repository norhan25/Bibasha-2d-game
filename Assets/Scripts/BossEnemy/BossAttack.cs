using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("IBASHA"))
        {
            anim.SetBool("AttackHero", true);

            Hero_health.TakeDamage(20);      // Boss Will Take Health 20
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("IBASHA"))
        {
            anim.SetBool("AttackHero", false);
        }
    }
}
