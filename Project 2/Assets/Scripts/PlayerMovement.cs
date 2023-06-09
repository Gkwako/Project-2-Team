using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player character
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
            transform.Translate(Vector3.right * 0 * Time.deltaTime);
        }
    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.name == "Rock")
        {
            speed = 0f;
        }
        
    }

    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Rock")
        {
            speed = 1.5f;
        }

    }
    */

    //  public void EndDialogue()
    // {
    //     speed = 5f;
    // }
}

