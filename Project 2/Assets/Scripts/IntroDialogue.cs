using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroDialogue : MonoBehaviour
{
     public TextMeshProUGUI textComponent;
    public GameObject dialogueBox;
    public string[] lines;
    public float textSpeed;
    public float invokeTime;
    
    private int index;
    float nextTypetime;
    float delay = 8f;

    void Start()
    {
        dialogueBox.gameObject.SetActive(false);
        textComponent.text = string.Empty;
        Invoke("StartDialogue",invokeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTypetime)
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
                nextTypetime = Time.time + delay;
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
                nextTypetime = Time.time + delay;
            }
        } 
    }

    void StartDialogue()
    {
        if(dialogueBox.gameObject.activeInHierarchy == false)
        {
            dialogueBox.gameObject.SetActive(true);
            index = 0;
            StartCoroutine(TypeLine());
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
            dialogueBox.gameObject.SetActive(false);
        } 
    }
}