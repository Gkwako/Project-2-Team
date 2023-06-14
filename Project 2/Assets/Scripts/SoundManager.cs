using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip backgroundSound, fireSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        backgroundSound = Resources.Load<AudioClip>("BGsea");
        fireSound = Resources.Load<AudioClip>("fire");
        
        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip) {
        case "BGsea":
            audioSrc.PlayOneShot (backgroundSound);
            break;
        }
        switch (clip) {
        case "fire":
            audioSrc.PlayOneShot (fireSound);
            break;
        }
    }
}

// Bron: https://www.youtube.com/watch?v=8pFlnyfRfRc

// SoundManager.PlaySound("fireSound") * toevoegen aan de script waar sound moet komen
