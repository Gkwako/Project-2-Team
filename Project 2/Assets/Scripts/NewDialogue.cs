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

    private void Start()
    {
        //animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StepButtonClick();
        }
    }

    private void StepButtonClick()
    {
        if (step >= speaker.Length)
        {
            //step = 0;
            animator.SetBool("IsOpen", false); // Closes the dialogue box
        }

        if (step < speaker.Length)
        {
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