using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject[] coins;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (coins == null)
        {
            coins = GameObject.FindGameObjectsWithTag("Coin");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // player gets reset when dead
        if (collision.tag == "Death Zone" || collision.tag == "Enemy")
        {
            playerReset();
        }
    }

    void playerReset()
    {   
        // reset player values
        transform.position = new Vector3(0, 0, 0);
        rb.velocity = new Vector2(0, 0);

        // reset coins
        foreach (GameObject coin in coins)
        {
            if (!coin.activeInHierarchy)
            {
                coin.gameObject.SetActive(true);
            }
        }
    }
}