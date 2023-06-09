using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player character
    public float pauseSpeed = 1f;
    public bool isPaused;

    void Update()
    {
        // Move the player character to the right
        if(isPaused == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if(isPaused == true)
        {
            transform.Translate(Vector3.right * pauseSpeed * Time.deltaTime);
        }

    }
}

