using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    public float shootTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > shootTime && GameManager.instance.canHearCannons == true)
        {
            timer = 0;
            shoot();
        }
        
    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}

// Bron: https://www.youtube.com/watch?v=--u20SaCCow&t=433s
