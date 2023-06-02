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
}