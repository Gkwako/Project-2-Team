using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TriggerText : MonoBehaviour
{
    public Text displayText;
    public string textMsg;

    public float displayDuration = 10f;
    private float timer = 0f;
    private static bool displayActive = false;

    public Animator anim;
    public BoxCollider2D coll;

    public void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }


    public void Update()
    {

        // Timer van de tekst

        if (displayActive)
        {
            GameManager.instance.player.isPaused = true;

            timer += Time.deltaTime;

            if (timer >= displayDuration)
            {
                displayText.text = textMsg;
                displayActive = false;
                timer = 0f;
                //GameManager.instance.normalSpeedPlayer();
            }
        }

        if(!displayActive)
        {
            displayText.text = "";

            GameManager.instance.player.isPaused = false;
            timer = 0f;
            //GameManager.instance.player.speed = 1.5f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Collided");
            displayText.text = textMsg;
            displayActive = true;

            anim.SetTrigger("Activate");

            Destroy(coll, 1f);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        /*
        
        if (collider.tag == "Player")
        {
            displayText.text = "";
        }

        */
    }
}