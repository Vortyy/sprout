using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Healthbar healthbar;
    AudioSource jump;

    public float speed = 20f;
    public float jumpVelocity = 25f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public bool isGrounded = false;
    public float healValue = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthbar = GetComponent<Healthbar>();
        jump = GetComponent<AudioSource>();
    }



    private void Update()
    {
        // Jump
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else if (rb.velocity.y > 0 && !Input.GetKey("space"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y == 0)
        {
            animator.SetBool("isFalling", false);
        }

        if (Input.GetKeyDown("space") && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            isGrounded = false;
            animator.SetBool("isJumping", true);
            jump.Play();
        }

        // Can move if not dead
        if (!healthbar.dead)
        {
            // Lateral movement
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
                transform.localScale = new Vector2(1, 1);
                animator.SetBool("isMoving", true);
            }
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                transform.localScale = new Vector2(-1, 1);
                animator.SetBool("isMoving", true);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                animator.SetBool("isMoving", false);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            isGrounded = false;
            animator.SetBool("isDead", true);
        }
    }

    // Detect collision with floor
    private void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (hit.gameObject.tag == "Wall")
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isMoving", false);
        }
    }
}
