using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // public void StartScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    // }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
