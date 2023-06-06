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
    //public Animator animator2;
    public Animator animator3; // Animator for the "Talk" text pop-up above an NPC

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

    public void AnimatorSearch() // Function to search for the "Talk" text pop-up animator, needs to run every time a scene starts
    {
        animator3 = GameObject.Find("TalkCanvas").GetComponent<Animator>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        animator.SetBool("IsOpen", true); // Opens the dialogue box
        //animator2.SetBool("MenuIsOpen", true);
        animator3.SetBool("IsActive", false); // Disappears the "Talk" text pop-up

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
        animator.SetBool("IsOpen", false); // Closes the dialogue box
        //animator2.SetBool("MenuIsOpen", false);
    }
}