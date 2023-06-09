using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue2 : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject dialogueBox;
    public string[] lines;
    public float textSpeed;
    
    public Animator anim;
    public Dialogue dialogueOption;
    public DialogueTrigger dialogueTrigger;

    public bool isPlayerNear; // Checks if the player is in range of the NPC
    public bool isPlayerTalking; // Checks if the player is talking to the NPC, can continue to the next sentence instead of starting the dialogue

    // public float invokeTime;

    private int index;
   
    // Start is called before the first frame update
     void Start()
    {
        dialogueBox.gameObject.SetActive(false);
        textComponent.text = string.Empty;
        // Invoke("StartDialogue",invokeTime);
    }

    public void Update()
    {
            if (Input.GetButtonDown("Fire3") && isPlayerNear == true) // If left shift is pressed and the player is in range
            {
                dialogueBox.gameObject.SetActive(true);
                index = 0;
                StartCoroutine(TypeLine());
            }  

            if(Input.GetButtonDown("Fire3") && isPlayerTalking == true) // If the dialogue has started
            {
                isPlayerNear = false; // Makes sure the player doesn't start up the dialogue again from the start
                // GameManager.instance.dialogueManager.DisplayNextSentence(); // Player can continue to the next sentence
            }            
    }

    // Ranges of the interactzones of NPC's
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsActive", true);
            dialogueTrigger.dialogue = dialogueOption;
            isPlayerNear = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsActive", false);
            isPlayerNear = false;
            isPlayerTalking = false;
            // GameManager.instance.dialogueManager.EndDialogue(); // Ends the dialogue when the player gets out of range of the NPC
        }
    }

     IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } 
        else
        {
            gameObject.SetActive(false);
        } 
    }
}
