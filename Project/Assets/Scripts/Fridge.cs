using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour
{


    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DialogueTriggerer"))
        {
            DialogueTriggerer dialogueTriggerer = collision.gameObject.GetComponent<DialogueTriggerer>();
            dialogueTriggerer.TriggerDialogue();
        }
    }
}
