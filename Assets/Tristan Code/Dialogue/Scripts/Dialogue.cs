using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{

    [TextArea(3, 10)]
    public string[] sentences;
    public string[] names;
    //different expressions, if we dont wanna do this, its fine, im just gonna keep it as an option :D
    public Sprite[] sprites;
    public AudioClip[] voices;
    public Sprite[] BGsprites;
    public bool bossTrigger;
    public bool sceneTransition;
    public bool tutorialTrigger;
    public int sceneNumber;
    public Tutorial tutorial;


}
