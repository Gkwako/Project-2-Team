using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            // Destroys the following objects when they're double in a scene
            Destroy(gameObject);
            Destroy(HUD);
            Destroy(player.gameObject);
            Destroy(cam.gameObject);
            Destroy(dialogueManager.gameObject);

            return;
        }

        instance = this;

        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    //Dont Destroy Objects
    public PlayerMovement player;
    public GameObject HUD;
    public Camera cam;
    public CameraMotorScript cameraScript;
    public DialogueManager dialogueManager;

    /*
    // Scenes
    enum Scenes { SampleScene, SampleScene2 };
    public string sceneName;
    public int previousScene = 0;
    public int index;
    */

    // Camera zooms
    public bool carpetZoom;
    public bool dialogueZoom;
    public float camSpeed;
    //public GameObject lookAtCarpet;
    public float transitionSpeed = 2.0f;

    public bool dialogueActive;

    // Willem's schetsen
    public Sprite[] backgroundSprites;
    public bool dialogue1;
    public Animator backgroundAnim;
    public float fadeDuration = 1f; // The duration of the fade in seconds
    public int currentSpriteIndex;
    public float currentFadeTime;
    public bool fadingOut;


    void Start()
    {

        SceneManager.sceneLoaded += OnSceneLoaded;

        //currentSpriteIndex = 1;
        fadingOut = false;
        //UpdateSprite();
    }

    void Update()
    {

        // Check if the sprite should be faded
        if (dialogue1 && !fadingOut)
        {
            // Start fading out the current sprite
            fadingOut = true;
            currentFadeTime = fadeDuration;
            //UpdateSprite();
        }
        else if (!dialogue1 && fadingOut)
        {
            // Start fading in the next sprite
            fadingOut = false;
            currentFadeTime = fadeDuration;
            //UpdateSprite();
            //currentSpriteIndex = (currentSpriteIndex + 1) % backgroundSprites.Length;
        }

        // Update the sprite opacity based on the fade progress
        if (currentFadeTime > 0)
        {
            UpdateSprite();

            float fadeProgress = 1f - (currentFadeTime / fadeDuration);
            Color spriteColor = cameraScript.spriteRenderer.color;
            spriteColor.a = fadingOut ? fadeProgress : 1f - fadeProgress;
            cameraScript.spriteRenderer.color = spriteColor;
            currentFadeTime -= Time.deltaTime;
            //UpdateSprite();
        }

        if (currentFadeTime <= 0)
        {
            float fadeProgress = 1f - (currentFadeTime / fadeDuration);
            Color spriteColor = cameraScript.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            cameraScript.spriteRenderer.color = spriteColor;
        }

        //if (dialogue1)
        //{
        //    cameraScript.spriteRenderer.sprite = backgroundSprites[1];
        //}

        //else
        //{
        //    cameraScript.spriteRenderer.sprite = backgroundSprites[0];
        //}
    }

    public void LateUpdate()
    {

        if (carpetZoom)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 60f, camSpeed);

                //Vector3 targetPosition = cameraScript.lookAt2.transform.position;
                //Vector3 currentPosition = cameraScript.lookAt.transform.position;

                // Calculate the new position with a smooth transition
                //Vector3 newPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * transitionSpeed);

                // Update the camera's position
                //transform.position = newPosition;

                // Player position
                player.isEnding = true;

                //player.StartFade();
                //player.fading = true;

        }

        if(dialogueZoom)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 30f, camSpeed);
            backgroundAnim.SetBool("DialogueActive", true);
        }

        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 20f, camSpeed);
            backgroundAnim.SetBool("DialogueActive", false);
        }
    }

    private void UpdateSprite()
    {
        /*
        if (backgroundSprites.Length > 0)
        {
            cameraScript.spriteRenderer.sprite = backgroundSprites[currentSpriteIndex];
        }
        */

        if (dialogue1)
        {
            cameraScript.spriteRenderer.sprite = backgroundSprites[1];
            //cameraScript.lookAt = cameraScript.lookAt3;
        }

        if (!dialogue1)
        {
            cameraScript.spriteRenderer.sprite = backgroundSprites[0];
            //cameraScript.lookAt = cameraScript.lookAt;

        }
    }

    public void finalZoom()
    {
        carpetZoom = true;
        //cameraScript.zoomOut = true;
    }

    public void finalFade()
    {
        player.fading = true;
    }

    // PLAYER SPEED ADJUSTMENT FUNCTIONS

    public void slowSpeedPlayer()
    {
        player.speed = 0.5f;
        //Debug.Log("Slow speed player");
    }

    public void normalSpeedPlayer()
    {
        if(dialogueActive == false)
        {
            player.speed = 5f;
            //Debug.Log("Normal speed player");
        }
    }

    public void fastSpeedPlayer()
    {
        if(dialogueActive == false)
        {
            player.speed = 10f;
            //Debug.Log("Fast speed player");
        }
    }

    public void noSpeedPlayer()
    {
        player.speed = 0f;
        //Debug.Log("No speed player");
    }

    ///////////

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        /*

        // Checks which spawnpoint the player needs to move to, from which scene to which scene
        if (scene.buildIndex == (int)Scenes.SampleScene2 && previousScene == (int)Scenes.SampleScene)
        {
            player.transform.position = (spawnPoint_1Door1);
        }

        if (scene.buildIndex == (int)Scenes.SampleScene && previousScene == (int)Scenes.SampleScene2)
        {
            player.transform.position = (spawnPoint_1Door2);
        }

        previousScene = scene.buildIndex; // Keeps track of what the previousscene was

        */

    }


    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SaveState()
    {
        /*

        string s = "";

        s += currentCoins.ToString() + "|"; // Saves the amount of coins

        PlayerPrefs.SetString("SaveState", s);

        */
    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {

        /*
         * 
        if (s.buildIndex == (int)Scenes.SampleScene)
        {
            SceneManager.sceneLoaded -= LoadState;
        }
        else
        {
            SceneManager.sceneLoaded -= LoadState;
        }

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        currentCoins = int.Parse(data[0]); // Loads the amount of coins

        */

    }

}