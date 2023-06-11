// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class DialogueTrigger : MonoBehaviour
// {
//     public Animator anim;
//     public Dialogue dialogue;

//     public void TriggerDialogue()
//     {
//         FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
//     }
    

//     void OnCollisionEnter2D(Collision2D collision)
//     {
//         if(collision.gameObject.tag == "Player")
//         {
//             TriggerDialogue();
//         }
//     }

// }