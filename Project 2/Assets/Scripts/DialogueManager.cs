using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI  nameText;
    public TextMeshProUGUI  dialogueText;

    public Animator animator; // Animator for the DialogueBox

    private Queue<string> sentences;

    void Awake()
    {
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true); // Opens the dialogue box
        nameText.text = dialogue.npcname;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false); // Closes the dialogue box]  
    }

}

// ------------------------------------------------------------------------------------------------------------------
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;

// public class DialogueManager : MonoBehaviour
// {
//     public TextMeshProUGUI  nameText;
//     public TextMeshProUGUI  dialogueText; 

//     public Animator animator; // Animator for the DialogueBox

//     private Queue<string> sentences;
    
//     public Dialogue[] dialogues;
//     private int currentDialogue;

//     public Pool dialogue;


//     void Awake()
//     {
//     }

//     void Start()
//     {
//         sentences = new Queue<string>();
//     }

//     private void Update()
//     {
//     }
//     public void StartDialogue(Dialogue dialogue)
//     {

//         animator.SetBool("IsOpen", true); // Opens the dialogue box

//         nameText.text = dialogue.npcname1;

//         sentences.Clear();

//         foreach (string sentence in dialogue.sentences)
//         {
//             sentences.Enqueue(sentence);
//         }

//         DisplayNextSentence();

//     }

//     public void DisplayNextSentence()
//     {
//         if (sentences.Count == 0)
//         {
//             EndDialogue();
//             return;
//         }

//         string sentence = sentences.Dequeue();
//         StopAllCoroutines();
//         StartCoroutine(TypeSentence(sentence));

//     }
         
//         //  if (sentences.Count == 0)
//         // {
//         //     EndDialogue();
//         //     return;
//         // }
//         // else
//         // {
//         //     // currentDialogue++; // Moves to the next dialogue line
//         //     // dialogueText.text = dialogues[currentDialogue].sentences[0]; // Changes the dialogue name

//         //     // dialogues[currentDialogue].npcname1 = dialogue.npcname2; // Change npc name to the newName value
            
//         //     // TODO: End Conversation
//         //     // Debug.Log("End of conversation.");
//         //     //    string sentence = sentences.Dequeue();
//         //     // StopAllCoroutines();
//         //     // StartCoroutine(TypeSentence(sentence));
  
//         // }
        
//         // string sentence = sentences.Dequeue();
//         // StopAllCoroutines();
//         // StartCoroutine(TypeSentence(sentence));

//     }

//     IEnumerator TypeSentence(string sentence)
//     {
//         dialogueText.text = "";
//         foreach (char letter in sentence.ToCharArray())
//         {
//             dialogueText.text += letter;
//             yield return null;
//         }

//     }

//     public void EndDialogue()
//     {
//         if(sentences.Clear());

        
//         animator.SetBool("IsOpen", false); // Closes the dialogue box
//     }
// }