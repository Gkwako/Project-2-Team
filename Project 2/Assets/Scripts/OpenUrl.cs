using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUrl : MonoBehaviour
{
    public void Openurl(string Urlname)
    {
        Application.OpenURL(Urlname);
    }
}

// Bron: https://www.youtube.com/watch?v=3L8bDWLfO_8
