using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTrigger : MonoBehaviour
{
    //bool to determine if you already triggered this
    private bool hasCollided;
    public Dialogue dialogue;
    public Dialogue bossDialogue;

    //starts dialogue
    public void TriggerDialogue()
    {
        StartCoroutine(FindObjectOfType<DialogueManager>().StartDialogue(dialogue));
    }

    public void Start()
    {
        //checks what scene you are in and starts dialogue if ur in the dialogue scene
        if(SceneManager.GetActiveScene().name == "DialogueScene")
        {
            TriggerDialogue();
        }

        hasCollided = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (hasCollided == false)
            {
                hasCollided = true;
                TriggerDialogue();
            }
        }
    }

    private void Update()
    {
        if (DialogueVariables.endBoss == true)
        {
            if (bossDialogue != null)
            { 
                StartCoroutine(FindObjectOfType<DialogueManager>().StartDialogue(bossDialogue));
            }
        }
    }
}
