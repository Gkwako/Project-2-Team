using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOutTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            GameManager.instance.finalFade();
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            GameManager.instance.finalZoom();
        }

    }
}
