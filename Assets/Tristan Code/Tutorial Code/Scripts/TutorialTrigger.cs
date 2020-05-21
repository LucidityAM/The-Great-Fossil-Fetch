using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTrigger : MonoBehaviour
{
    //bool to determine if you already triggered this
    private bool hasCollided;
    public Tutorial tutorial;
    public TutorialManager manager;
    //starts dialogue
    public void TriggerTutorial()
    {
        manager.StartTutorial(tutorial);
    }

    public void Start()
    {
        hasCollided = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (hasCollided == false)
            {
                hasCollided = true;
                TriggerTutorial();
            }
        }
    }
}
