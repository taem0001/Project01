using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 6f;
    private bool dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        dir = true;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dir ? speed : -speed, 0);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Ground")
        {
            dir = !dir;
        }
    }
}
