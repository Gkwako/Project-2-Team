using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip backgroundSound, fireSound, screamSound, drumSound, celloSound, windSound, paperSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        backgroundSound = Resources.Load<AudioClip>("BGsea");
        fireSound = Resources.Load<AudioClip>("Kanon");
        screamSound = Resources.Load<AudioClip>("Scream");
        drumSound = Resources.Load<AudioClip>("Drum");
        celloSound = Resources.Load<AudioClip>("Cello");
        windSound = Resources.Load<AudioClip>("Wind");
        paperSound = Resources.Load<AudioClip>("Paper");


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
        case "Kanon":
            audioSrc.PlayOneShot (fireSound);
            break;
        }
        switch (clip)
        {
            case "BattleCry":
                audioSrc.PlayOneShot(screamSound);
                break;
        }
        switch (clip)
        {
            case "WarDrums":
                audioSrc.PlayOneShot(drumSound);
                break;
        }
        switch (clip)
        {
            case "Cello":
                audioSrc.PlayOneShot(celloSound);
                break;
        }
        switch (clip)
        {
            case "Wind":
                audioSrc.PlayOneShot(windSound);
                break;
        }
        switch (clip)
        {
            case "Paper":
                audioSrc.PlayOneShot(paperSound);
                break;
        }
    }
}

// Bron: https://www.youtube.com/watch?v=8pFlnyfRfRc

// SoundManager.PlaySound("fireSound") * toevoegen aan de script waar sound moet komen
