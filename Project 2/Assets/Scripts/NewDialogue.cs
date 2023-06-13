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

    int indexToCheck0 = 0;
    int indexToCheck1 = 1;

    // [SerializeField]
    // private Sprite[] portrait2;

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
            // {
    //     if(step>= speaker.Length)
    //     {
    //         step = 0;
    //         animator.SetBool("IsOpen", false); // Closes the dialogue box
    //         portraitImage2.sprite = null;
    //     } else{
    //         animator.SetBool("IsOpen", true); // Opens the dialogue box
    //         speakerText.text = speaker[step];
    //         dialogueText.text = dialogueWords[step];

    //         if (step % 2 == 0)
    //         {
    //             portraitImage.sprite = portrait[step];
 
    //             if (step > 0)
    //             {
    //                 portraitImage2.sprite = portrait[step - 1];
    //             }
    //         }
    //         else
    //         {
    //             portraitImage2.sprite = portrait[step];
 
    //             if (step > 0)
    //             {
    //                 portraitImage.sprite = portrait[step - 1];
    //             }
    //         }

    //         step += 1;
    //     }
    // }
        //  {
        // if(step>= speaker.Length)
        // {
        //     step = 0;
        //     animator.SetBool("IsOpen", false); // Closes the dialogue box
        //     portraitImage2.sprite = null;
        // } else{
        //     animator.SetBool("IsOpen", true); // Opens the dialogue box
        //     speakerText.text = speaker[step];
        //     dialogueText.text = dialogueWords[step];
        //     portraitImage.sprite = portrait[step];

        //     if (step > 0)
        //     {
        //         portraitImage2.sprite = portrait[step - 1];
        //     }
        //     step += 1;
        // }
        //  }
    {
    //     if(step>= speaker.Length)
    //     {
    //         step = 0;
    //         animator.SetBool("IsOpen", false); // Closes the dialogue box
    //     } else{
    //         animator.SetBool("IsOpen", true); // Opens the dialogue box
    //         speakerText.text = speaker[step];
    //         dialogueText.text = dialogueWords[step];
    //         portraitImage.sprite = portrait[step];
    //         // portraitImage2.sprite = portrait[step];
    //         step += 1;
    //     }
    // }
    // }

        if(step>= speaker.Length)
        {
            step = 0;
            animator.SetBool("IsOpen", false); // Closes the dialogue box
        } 
        
        if (step<= speaker.Length)
        {

            if(speaker[indexToCheck0].Contains("De Jonge"))
            {
                portraitImage.transform.position = position1.transform.position;
                Debug.Log(portraitImage.transform.position);
            }

            if(speaker[indexToCheck1].Contains("De Oude"))
            {
                portraitImage.transform.position = position2.transform.position;
                Debug.Log(portraitImage.transform.position);
            }

            animator.SetBool("IsOpen", true); // Opens the dialogue box
            speakerText.text = speaker[step];
            dialogueText.text = dialogueWords[step];
            portraitImage.sprite = portrait[step];
            step += 1;

            
        }
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
