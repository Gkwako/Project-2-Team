using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject spawnObject;
    public Vector3 spawnPosition;

    public Animator anim;

    public GameObject dialogueBox;

    public IntroDialogue introDialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnPosition = GameManager.instance.player.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            introDialogue.StartDialogue();

            Destroy(gameObject);

            Debug.Log("Spawns it");
        }
    }
}
