using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class NewDialogue : MonoBehaviour
{
    [SerializeField]
    private TMP_Text speakerText;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private Image portraitImage;

    // [SerializeField]
    // private Image portraitImage2;

    // dialogue content
    [SerializeField]
    public string[] speaker;

    [SerializeField]
    [TextArea]
    private string[] dialogueWords;

    [SerializeField]
    private Sprite[] portrait;

    public Transform position1;
    public Transform position2;

    public Animator animator; // Animator for the DialogueBox

    public int step;
    public int currentIndex;

    public Collider2D collider;

    [SerializeField]
    Button button;

    public bool scene1;
    public bool scene2;
    public bool scene3;

    public Animator anim;
    public BoxCollider2D coll;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (collision.gameObject.tag == "Player")
        //{
            //remove listener
            //how to change assigned function in onclick via script
            

            //add new listener
           // button.onClick.AddListener(OnClickNextStep);

            // step = 0;
            //StepButtonClick();
          //  GameManager.instance.noSpeedPlayer();
        //}
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //remove listener
            //how to change assigned function in onclick via script

            step = 0;

            //add new listener
            button.onClick.AddListener(OnClickNextStep);

            // step = 0;
            StepButtonClick();
            Debug.Log(" Enter ");

            SoundManager.PlaySound("Trumpet1");


            //Destroy(coll);

            GameManager.instance.noSpeedPlayer();
            GameManager.instance.player.isPaused = true;

            if (scene1)
            {
                GameManager.instance.dialogue1 = true;
                GameManager.instance.dialogue2 = false;
                GameManager.instance.dialogue3 = false;
                GameManager.instance.player.isPaused = true;


            }

            if (scene2)
            {
                GameManager.instance.dialogue1 = false;
                GameManager.instance.dialogue2 = true;
                GameManager.instance.dialogue3 = false;
                GameManager.instance.player.isPaused = true;

            }

            if (scene3)
            {
                GameManager.instance.dialogue1 = false;
                GameManager.instance.dialogue2 = false;
                GameManager.instance.dialogue3 = true;
                GameManager.instance.player.isPaused = true;

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.noSpeedPlayer();
            GameManager.instance.player.isPaused = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //GameManager.instance.normalSpeedPlayer();
            //GameManager.instance.player.isPaused = false;


            if (scene1)
            {
                //GameManager.instance.dialogue1 = false;
            }

            if (scene2)
            {
                //GameManager.instance.dialogue2 = false;
            }

            if (scene3)
            {
                //GameManager.instance.dialogue3 = false;
            }
        }
    }

    private void StepButtonClick()
    {
        if (step >= speaker.Length)
        {
            //GameManager.instance.dialogue1 = false;
            GameManager.instance.player.isPaused = false;
            GameManager.instance.normalSpeedPlayer();
            GameManager.instance.dialogueZoom = false;

            //step = 0;
            animator.SetBool("IsOpen", false); // Closes the dialogue box
            button.onClick.RemoveListener(StepButtonClick);
            //Destroy(collider);
            anim.SetTrigger("End");
            step++;

            //GameManager.instance.normalSpeedPlayer();
            //GameManager.instance.player.isPaused = false;

        }

        if (step > speaker.Length)
        {

            Destroy(collider);

            if (scene1)
            {
                GameManager.instance.dialogue1 = false;
            }

            if (scene2)
            {
                GameManager.instance.dialogue2 = false;
            }

            if (scene3)
            {
                GameManager.instance.dialogue3 = false;
            }

        }

        if (step < speaker.Length)
        {
            //GameManager.instance.noSpeedPlayer();
            //GameManager.instance.player.isPaused = true;

            //GameManager.instance.dialogue1 = true;
            GameManager.instance.player.isPaused = true;
            GameManager.instance.noSpeedPlayer();
            GameManager.instance.dialogueZoom = true;

            if (speaker[step] == "De Jonge")
            {
                portraitImage.transform.position = position1.position;
            }
            else if (speaker[step] == "De Oude")
            {
                portraitImage.transform.position = position2.position;
            }

            animator.SetBool("IsOpen", true); // Opens the dialogue box
            speakerText.text = speaker[step];
            dialogueText.text = dialogueWords[step];
            portraitImage.sprite = portrait[step];
            step++;
        }
    }

    private void OnClickNextStep() // Called by an OnClick button in Unity
    {
        StepButtonClick();
        GameManager.instance.player.isPaused = true;
        GameManager.instance.noSpeedPlayer();
    }
}

// Bron : https://www.youtube.com/watch?v=vR6H3mu_xD8&list=PLSR2vNOypvs4Pc72kaB_Y1v3AszNd-UuF