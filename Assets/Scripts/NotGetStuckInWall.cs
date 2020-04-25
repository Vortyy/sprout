using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class NotGetStuckInWall : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    Animator animator;
    PlayerController controller;

    public bool temp;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        controller = player.GetComponent<PlayerController>();
    }

    private void LateUpdate()
    {
        temp = controller.isGrounded;
    }

    private void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Wall")
        {
            rb.velocity = new Vector2(0, -27f);
            animator.SetBool("isMoving", false);

            controller.isGrounded = false;
        }
    }

    private void OnTriggerExit2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Wall")
        {
            controller.isGrounded = temp;
        }
    }
}
