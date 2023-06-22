using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCanon : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("target");
        SoundManager.PlaySound("Kanon");  

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force; 

        // add gravity after some time
        Invoke("AddGravity", 2);
    }

    void AddGravity() 
    {   
        rb.gravityScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}