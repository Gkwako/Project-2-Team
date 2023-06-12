using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTap : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color transparentColor = new Color(1f, 1f, 1f, 0f); // Transparent color
    public Color coloredColor = new Color(1f, 1f, 1f, 1f); // Colored color
    public float fadeDuration = 1f;

    private bool isFading = false;
    private Color targetColor;
    private float currentFadeTime = 0f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = transparentColor; // Set initial transparency to transparent
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Start fading to colored
            isFading = true;
            targetColor = coloredColor;
            currentFadeTime = 0f;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Start fading to transparent
            isFading = true;
            targetColor = transparentColor;
            currentFadeTime = 0f;
        }

        if (isFading)
        {
            // Calculate the current transparency based on fade progress
            currentFadeTime += Time.deltaTime;
            float t = currentFadeTime / fadeDuration;
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, t);

            // Check if the fading is complete
            if (spriteRenderer.color.Equals(targetColor))
            {
                isFading = false;
            }
        }
    }
}