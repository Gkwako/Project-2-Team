using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player character

    void Update()
    {
        // Move the player character to the right
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Rock")
        {
            speed = 0f;
        }
    }

    //  public void EndDialogue()
    // {
    //     speed = 5f;
    // }
}

