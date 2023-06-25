using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottleScript : MonoBehaviour
{
    private GameObject selectedObject; // Reference to the selected object
    public float speed = 5f; // Speed of the bottle
    public GameObject dialogueBox;
    public float WaitForSeconds;
    private bool activateDialogueBox;

    public Animator anim;
    public Animator anim2;

    public string paperText;
    public TextMeshProUGUI paper;

    void Update()
    {
        // Move the bottle to the right
        transform.Translate(Vector3.left * Time.deltaTime);
    }
   
    void Start()
    {
        activateDialogueBox = false;
        if(dialogueBox)
        {
            //dialogueBox.gameObject.SetActive(false);
        }
    }

    void OnMouseDown()  
    {
        anim.SetTrigger("Tap");
        anim2.SetTrigger("Activate");

        paper.text = paperText;

        activateDialogueBox = true;
        dialogueBox.gameObject.SetActive(true);
        Debug.Log("opent");
        SoundManager.PlaySound("Paper");
        StartCoroutine(CloserDialogue());

        GameManager.instance.dialogueActive = true;
        GameManager.instance.slowSpeedPlayer();
    }
       
    IEnumerator CloserDialogue(){
		if(activateDialogueBox)
        {
		  yield return new WaitForSeconds(5);
	      //dialogueBox.gameObject.SetActive(false);
		  Debug.Log("closed");
            SoundManager.PlaySound("Paper");
            //anim2.SetTrigger("Disactivate");


            GameManager.instance.dialogueActive = false;
          GameManager.instance.normalSpeedPlayer();

        }
    }
}

