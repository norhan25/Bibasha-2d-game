using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    // Start is called before the first frame update

    new Rigidbody2D rigidbody;
    float speed = 0.5f, movementDirX, range = 2f, distToPlayer, min = -3f, max = 70f; // 20 and -20 r the x coordinates of screen edges
    Vector2 localScale;
    public static bool isAttacking = false;
    public Transform player;
    Animator anim;


    void Start()
    {
        movementDirX = 1f;
        rigidbody = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer <= range)
        {
            ChasePlayer();
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
            anim.SetFloat("Movement", rigidbody.velocity.x);
        }
    }

    void ChasePlayer()
    {
        if ((transform.position.x < player.position.x && HeroController.movement != 0) || transform.position.x < min)
        {
            
            rigidbody.velocity = new Vector2(movementDirX * speed, 0);
            transform.localScale = new Vector2(localScale.x, localScale.y);
        }

        else if ((transform.position.x > player.position.x && HeroController.movement != 0) || transform.position.x > max)
        {

            rigidbody.velocity = new Vector2(-movementDirX * speed, 0);
            transform.localScale = new Vector2(-localScale.x, localScale.y);
        }

        anim.SetFloat("Movement", speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("FallDetectorlvl1"))
        {
            transform.position = new Vector3(12,-1,0);
        }
    }
}
