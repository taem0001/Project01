using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D coinCollision)
    {
        if (coinCollision.tag == "Player")
        {
            if (gameObject.activeInHierarchy)
            {
                gameObject.SetActive(false);
                
            }
        }
    }
}
