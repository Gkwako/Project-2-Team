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
    public float delay;

    private int index;
    private float nextTypetime;
    private bool dialogueStarted;

    void Start()
    {
        dialogueBox.gameObject.SetActive(false);
        textComponent.text = string.Empty;
        dialogueStarted = false;
    }

    void Update()
    {
        if (dialogueStarted && Time.time > nextTypetime)
        {
            if (text.text == lines[index])
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

    public void StartDialogue()
    {
        if (!dialogueStarted)
        {
            dialogueStarted = true;
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
        if (index < lines.Length - 1)
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartDialogue();
        }
    }
}