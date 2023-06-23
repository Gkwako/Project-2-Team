using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI text;
    public GameObject dialogueBox;
    public string[] lines;
    public float textSpeed;
    public float invokeTime;
    public float delay;
    
    private int index;
    float nextTypetime;
    // float delay = 10f;

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
            if(text.text == lines[index])
            {
                NextLine();
                nextTypetime = Time.time + delay;
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[index];
                // nextTypetime = Time.time + delay;
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
            text.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    
    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        } 
        else
        {
            dialogueBox.gameObject.SetActive(false);
        } 
    }
}