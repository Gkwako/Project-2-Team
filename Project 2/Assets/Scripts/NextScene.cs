using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    public string sceneName;
    public float InvokeTime;
    
    void Start(){
        StartCoroutine(LoadSceneDelay());
    }    

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator LoadSceneDelay()
    {
        yield return new WaitForSeconds(InvokeTime);
        SceneManager.LoadScene(sceneName); 
    }
}