using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{

    private float VerticalMovement;     // For vertical movement of player on ladder
    private float ClimbSpeed = 3f;      // Climbing speed of player on ladder
    private bool IsClimbing;            // Checking whether player is climbing or not
    private bool IsLadder;              // Checking whether there is a ladder or not 
    Animator anim;

    //[SerializeField] private Rigidbody2D rgb;
    Rigidbody2D rgb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If player press UP key or W which are default keys for vertical movement where value resides between 1 and -1
        VerticalMovement = Input.GetAxis("Vertical");

        if (IsLadder && VerticalMovement > 0)
        {
            IsClimbing = true;      // So player is trying to climb on the ladder 
        }
    }

    private void FixedUpdate()
    {
        if (IsClimbing)
        {
            anim.SetBool("IsClimbing", IsClimbing);
            rgb.gravityScale = 0f;
            rgb.velocity = new Vector2(rgb.velocity.x, ClimbSpeed * VerticalMovement);
        }
        else
        {
            rgb.gravityScale = 1f;
            anim.SetBool("IsClimbing", IsClimbing);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ladder"))
        {
            IsLadder = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Ladder"))
        {
            IsLadder = false;
            IsClimbing = false;
        }
    }

}
