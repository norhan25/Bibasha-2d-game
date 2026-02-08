using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillHero : MonoBehaviour
{
    // Start is called before the first frame update

    new Rigidbody2D rigidbody;
    float speed = 20f, movementDirX, range = .5f, distToPlayer, min = -3f, max = 70f; // 20 and -20 r the x coordinates of screen edges
    Vector2 localScale;
    public static bool isAttacking = false;
    public Transform player;
    Animator DeathAngelAnim;


    void Start()
    {
        movementDirX = 1f;
        rigidbody = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        DeathAngelAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log(distToPlayer);

        // Current Health Decreased after 5 Means He is dead 
        if (distToPlayer > range && Hero_health.currhealth < 5)
        {
            ChasePlayer();
        }
        else if ((Hero_health.currhealth < 5) && (distToPlayer <=range))        // Player died and Death angel is near him to Attack
        {
            rigidbody.velocity = Vector2.zero;
            DeathAngelAnim.SetTrigger("KillHero");
            
        }
        else {
            // When The player is alive  So Death angel is at a specific Position In Start of lvl 1 at(-2,1)..
            transform.position = new Vector2(26, 5);
        }
    }

    void ChasePlayer()
    {
        if ((transform.position.x < player.position.x ) || transform.position.x < min )
        {
            
            rigidbody.velocity = new Vector2(movementDirX * speed, 0);
            transform.localScale = new Vector2(localScale.x, localScale.y);
        }

        else if ((transform.position.x > player.position.x  ) || transform.position.x > max )
        {

            rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
            transform.localScale = new Vector2(-localScale.x, localScale.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("IBASHA") )
        {
            //Hero_health.Playeranim.SetTrigger("isDead"); // Accessing Player death animation from health class
            SoundManager.PlaySound("dead");              // playing Death Sound Of Player
            //Destroy(gameObject);                         // Deleting Death Angel
            transform.position = new Vector2(26, 5);        // Placing Angel Again on His Place
            CheckDeathLvlPlayer(player.position.x);

        }
    }

    // This Function will Respawn our player to Start of existing lvl
    public void CheckDeathLvlPlayer(float Herox_axis)
    {
        if (Herox_axis < 16)
        {
            player.position = Respawn.RespawnOnCurrLvl("FallDetectorlvl1");
        }
        else if (Herox_axis < 36)
        {
            player.position = Respawn.RespawnOnCurrLvl("FallDetectorlvl2");
        }
        else if (Herox_axis > 36)
        {
            player.position = Respawn.RespawnOnCurrLvl("FallDetectorlvl3");
        }
    }

}
