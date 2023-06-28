using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartScreen : MonoBehaviour
{
    public GameObject EndScreen;
    public float time;

    void Start()
    {
        EndScreen.gameObject.SetActive(false);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameManager.instance.finalZoom();
            StartCoroutine (InvokeEndScreen(time));
        } 
    }

    IEnumerator InvokeEndScreen(float time)
    {
        yield return new WaitForSeconds(time);
        EndScreen.gameObject.SetActive(true);
    }

}
