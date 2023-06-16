using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGWaves : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player" && GameManager.instance.player.isPaused == false)
        {
            GameManager.instance.normalSpeedPlayer();
        }

        if(collision.gameObject.name == "Player" && GameManager.instance.player.isPaused == true)
        {
            GameManager.instance.slowSpeedPlayer();
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player" && GameManager.instance.player.isPaused == false)
        {
            GameManager.instance.normalSpeedPlayer();
        }

        if (collision.gameObject.name == "Player" && GameManager.instance.player.isPaused == true)
        {
            GameManager.instance.slowSpeedPlayer();
        }

    }
}
