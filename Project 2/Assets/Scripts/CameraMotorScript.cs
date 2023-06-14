using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotorScript : MonoBehaviour
{
    public Transform lookAt;
    public Transform lookAt2;
    public Camera cam;
    public PlayerMovement player;

    public float boundX = 0f;
    public float boundY = 0f;
    public float boundZ = 0f;

    public bool zoomOut;

    void Start()
    {
        lookAt = GameObject.Find("Player").transform;
        cam = Camera.main;
        SoundManager.PlaySound("BGsea");
    }

    void Update()
    {
        //if(zoomOut)
        //{
            //lookAt = lookAt2;
        //}

        Vector3 delta = Vector3.zero;

        // // This is to check if we're inside the bounds on the X axis
                 float deltaX = lookAt.position.x - transform.position.x;
                 if(deltaX > boundX || deltaX < -boundX)
                 {
                     if(transform.position.x < lookAt.position.x)
                     {
                        delta.x = deltaX - boundX;
                     }

                     else
                     {
                        delta.x = deltaX + boundX;
                     }
                }


        //     // This is to check if we're inside the bounds on the Y axis
                 float deltaY = lookAt.position.y + 2f - transform.position.y;
                 if(deltaY > boundY || deltaY < -boundY)
                 {
                     if(transform.position.y < lookAt.position.y)
                     {
                         delta.y = deltaY - boundY;
                     }

                     else
                     {
                         delta.y = deltaY + boundY;
                     }
                 }

                 
                 float deltaZ = lookAt.position.z - transform.position.z;

                 if(deltaZ > boundZ || deltaZ < -boundZ)
                 {
                     if(transform.position.z < lookAt.position.z)
                     {
                         delta.z = deltaZ - boundZ - 10;
                     }

                     else
                     {
                        delta.z = deltaZ + boundZ - 10;
                     }
                 }

                 transform.position += new Vector3(delta.x, delta.y, delta.z);

    }

}
