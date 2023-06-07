using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    private DialogueTrigger DialogueTrigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            {
                GetComponent<DialogueTrigger>();
         
            }
        
        }
        
    }
}

