using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip backgroundSound, fireSound, screamSound, drumSound, celloSound, windSound, paperSound, paperSound2, trumpet1, trumpet2;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        backgroundSound = Resources.Load<AudioClip>("BGsea");
        fireSound = Resources.Load<AudioClip>("Kanon");
        screamSound = Resources.Load<AudioClip>("BattleCry2");
        drumSound = Resources.Load<AudioClip>("WarDrums2");
        celloSound = Resources.Load<AudioClip>("Cello2.1");
        windSound = Resources.Load<AudioClip>("Wind");
        paperSound = Resources.Load<AudioClip>("Paper");
        paperSound2 = Resources.Load<AudioClip>("Paper2");
        trumpet1 = Resources.Load<AudioClip>("Trumpet1.1");
        trumpet2 = Resources.Load<AudioClip>("Trumpet2.1");


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
        switch (clip)
        {
            case "Paper2":
                audioSrc.PlayOneShot(paperSound2);
                break;
        }
        switch (clip)
        {
            case "Trumpet1":
                audioSrc.PlayOneShot(trumpet1);
                break;
        }
        switch (clip)
        {
            case "Trumpet2":
                audioSrc.PlayOneShot(trumpet2);
                break;
        }
    }
}

// Bron: https://www.youtube.com/watch?v=8pFlnyfRfRc

// SoundManager.PlaySound("fireSound") * toevoegen aan de script waar sound moet komen
