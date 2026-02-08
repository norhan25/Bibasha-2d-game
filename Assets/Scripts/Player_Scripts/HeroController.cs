using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed = 1f;
    public float jump_speed = 4f;
    public float timedelay = 0.5f;
    public float Radius;
    static public float movement;
    Rigidbody2D rb;
    public Transform groundcheckpoint;
    public LayerMask groundlayer;
    bool isTouchingground;
    public Animator anim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
        // This variable contains the state of Player whether he is touching ground or not
        isTouchingground = Physics2D.OverlapCircle(groundcheckpoint.position, Radius, groundlayer);
        
        // Movement Contains The Value of IBASHA in X-Axis
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            //SoundManager.PlaySound("run");
        }
        else if (movement < 0f)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            //SoundManager.PlaySound("run");
        }

        // Changing the velocity of Player acording to time and speed To create the effectv of movement
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        
        // Jumping Condition
        if (Input.GetButtonDown("Jump") && isTouchingground)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump_speed);
            SoundManager.PlaySound("jump");
        }
        //Playing animations of Running and Jumping

        anim.SetFloat("Movement", Mathf.Abs(rb.velocity.x));
        anim.SetBool("OnGround", isTouchingground);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.tag.Equals("FallDetectorlvl1"))
        //{
        //    transform.position = Respawn.RespawnOnCurrLvl(collision.gameObject.tag); 

        //}
        //else if (collision.gameObject.tag.Equals("FallDetectorlvl2"))
        //{
        //    transform.position = Respawn.RespawnOnCurrLvl(collision.gameObject.tag);
        //}
        //else if (collision.gameObject.tag.Equals("FallDetectorlvl3"))
        //{
        //    transform.position = Respawn.RespawnOnCurrLvl(collision.gameObject.tag);
        //}

        if (collision.gameObject.tag.Equals("FallDetectorlvl1"))
        {
             transform.position = Respawn.RespawnOnCurrLvl(collision.gameObject.tag);

        }
        else if (collision.gameObject.tag.Equals("FallDetectorlvl2"))
        {
            transform.position = Respawn.RespawnOnCurrLvl(collision.gameObject.tag);
        }
        else if (collision.gameObject.tag.Equals("FallDetectorlvl3"))
        {
            transform.position = Respawn.RespawnOnCurrLvl(collision.gameObject.tag);
        }

    }
}
