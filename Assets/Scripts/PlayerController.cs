using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpSpeed = 10f;
    private float inputX;
    private bool jumping;
    private bool isGrounded;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
        body.gravityScale = 2f;
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        // register player movement input
        inputX = Input.GetAxisRaw("Horizontal");

        // register jump input
        jumping = Input.GetKey(KeyCode.UpArrow);
    }

    void FixedUpdate()
    {
        // move the player based on input
        body.velocity = new Vector2(inputX * speed, body.velocity.y);

        // player jumps based on input and if it's grounded
        if (jumping && isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}