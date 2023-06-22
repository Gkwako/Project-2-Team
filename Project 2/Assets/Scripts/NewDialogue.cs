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

    private int step;
    private int currentIndex;

    public Collider2D collider;

    [SerializeField]
    Button button;

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //remove listener
            //how to change assigned function in onclick via script
            

            //add new listener
            button.onClick.AddListener(OnClickNextStep);

            // step = 0;
            StepButtonClick();
        }
    }

    private void StepButtonClick()
    {
        if (step >= speaker.Length)
        {
            GameManager.instance.normalSpeedPlayer();
            GameManager.instance.dialogueZoom = false;

            //step = 0;
            animator.SetBool("IsOpen", false); // Closes the dialogue box
            button.onClick.RemoveListener(StepButtonClick);
            Destroy(collider);
        }

        if (step < speaker.Length)
        {
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

    public void OnClickNextStep() // Called by an OnClick button in Unity
    {
        StepButtonClick();
    }
}

// Bron : https://www.youtube.com/watch?v=vR6H3mu_xD8&list=PLSR2vNOypvs4Pc72kaB_Y1v3AszNd-UuF