using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NewDialogue : MonoBehaviour
{
    [SerializeField]
    private TMP_Text speakerText;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private Image portraitImage;

    // dialogue content
    [SerializeField]
    private string[] speaker;
    
    [SerializeField]
    [TextArea]
    private string[] dialogueWords;

    [SerializeField]
    private Sprite[] portrait;

    // private bool dialogueActive
    public Animator animator; // Animator for the DialogueBox

    private int step;

    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StepButtonClick();
        }
    }

    private void StepButtonClick()
    {
        if(step>= speaker.Length)
        {
            step = 0;
            animator.SetBool("IsOpen", false); // Closes the dialogue box
        } else{
            animator.SetBool("IsOpen", true); // Opens the dialogue box
            speakerText.text = speaker[step];
            dialogueText.text = dialogueWords[step];
            portraitImage.sprite = portrait[step];
            step += 1;

        }
    }

    //  IEnumerator TypeSentence(string dialogueWords)
    // {
    //     dialogueText.text = "";
    //     foreach (char letter in dialogueWords.ToCharArray())
    //     {
    //         if(collision.gameObject.tag == "Player")
    //         {
    //             dialogueText.text += letter;
    //             yield return null;

    //         }
    //     }
    // }
    

    public void OnClickNextStep() // Called by a OnClick button of Unity
    {
        StepButtonClick();
    }

}

// Bron: https://www.youtube.com/watch?v=vR6H3mu_xD8 
