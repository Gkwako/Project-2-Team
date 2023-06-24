using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOutTrigger : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator anim4;
    public Animator anim5;
    public Animator anim6;
    public Animator anim7;

    public Animator anim8;
    public Animator anim9;

    public Animator anim10;
    public Animator anim11;
    public Animator anim12;
    public Animator anim13;
    public Animator anim14;
    public Animator anim15;


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

            anim1.SetTrigger("Ending");
            anim2.SetTrigger("Ending");
            anim3.SetTrigger("Ending");
            anim4.SetTrigger("Ending");
            anim5.SetTrigger("Ending");
            anim6.SetTrigger("Ending");
            anim7.SetTrigger("Ending");
            anim8.SetTrigger("Ending");
            anim9.SetTrigger("Ending");

            anim10.SetTrigger("Ending");
            anim11.SetTrigger("Ending");
            anim12.SetTrigger("Ending");
            anim13.SetTrigger("Ending");
            anim14.SetTrigger("Ending");
            anim15.SetTrigger("Ending");

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
