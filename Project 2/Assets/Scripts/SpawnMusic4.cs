using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMusic4 : MonoBehaviour
{
    public float timer = 0f;      // Timer variable
    public float interval = 7.5f;  // Interval in seconds (01.31 minutes)

    public bool runMusic;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (runMusic)
        {
            // Decrease the timer each frame
            timer -= Time.deltaTime;

            // Check if the timer has reached 0 or below
            if (timer <= 0f)
            {
                // Play the sound clip
                SoundManager.PlaySound("Fire");

                // Reset the timer
                timer = interval;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("Fire");
            runMusic = true;
        }
    }
}
