using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player character
    public float pauseSpeed = 1f;
    public bool isPaused;

    public bool isEnding;

    // Fade to transparency
    public SpriteRenderer spriteRenderer;
    public float fadeDuration = 3f; // Duration in seconds
    public bool fadeOutOnly = false; // If true, the sprite will only fade out and stay transparent

    private Color originalColor;
    private float timer = 0f;
    public bool fading = false;
    private bool fadeComplete = false;

    public Rigidbody2D rigid;


    void Start()
    {
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // Move the player character to the right
        if(isPaused == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if(isPaused == true)
        {
            transform.Translate(Vector3.right * pauseSpeed * Time.deltaTime);
        }

        if (isEnding)
        {
            GameManager.instance.slowSpeedPlayer();

            Vector3 targetPosition = GameManager.instance.cameraScript.lookAt2.transform.position;
            Vector3 currentPosition = GameManager.instance.cameraScript.player.transform.position;

            // Calculate the new position with a smooth transition
            Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, (Time.deltaTime * 0.1f));

            // Update the camera's position
            transform.position = newPosition;

            if(transform.position == newPosition)
            {
                //GameManager.instance.noSpeedPlayer();
            }
        }

        /*
        if (GameManager.instance.dialogue1)
        {
            Vector3 targetPosition = GameManager.instance.cameraScript.lookAt3.transform.position;
            Vector3 currentPosition = GameManager.instance.cameraScript.lookAt.transform.position;

            // Calculate the new position with a smooth transition
            Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * 0.15f);

            // Update the camera's position
            transform.position = newPosition;
        }

*/

        if (fading)
        {
            timer += Time.deltaTime;

            // Calculate the new alpha value based on the elapsed time and fade duration
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

            // Update the sprite's color with the new alpha value
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Check if the fading is complete
            if (timer >= fadeDuration)
            {
                fading = false;
                fadeComplete = true;

                if (fadeOutOnly)
                {
                    spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
                }
            }
        }
    }

    public void StartFade()
    {
        fading = true;
        fadeComplete = false;
        timer = 0f;
        spriteRenderer.color = originalColor;
    }

    public bool IsFadeComplete()
    {
        return fadeComplete;
    }
}

