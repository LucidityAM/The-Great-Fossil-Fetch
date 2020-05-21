using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindObjectOfType<DialogueManager>().StartDialogue(dialogue));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
