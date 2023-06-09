using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGWaves : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            GameManager.instance.player.speed = 1.5f;
        }

    }
}
