using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    //Text
    public Text header;
    public Text body;
    public Text pageNum;

    //Visual Stuff: Sprites, Backgrounds, Actual Box for text
    public GameObject textBox;
    public GameObject Background;
    private Animator textBoxAnim;
    private Animator backgroundAnim;

    //Player access for making them stop moving n stuff
    public GameObject Player;
    public PauseScript Pause;

    //Pulbic arrays that represent the text
    private string headerText;
    private string[] sentences;

    //checks if ur in a convo
    private bool isActive;
    //checks if the text has ended
    private bool endText;

    public static TutorialManager Instance;
    

    //indicator of the current sentence
    private int currentSentence;

    void Start()
    {
        textBox.SetActive(false);
        Background.SetActive(false);
        endText = false;
        isActive = false;
        textBoxAnim = textBox.GetComponent<Animator>();
        backgroundAnim = Background.GetComponent<Animator>();
        currentSentence = 0;
    }

    public void StartTutorial(Tutorial tutorial)
    {
        header.text = "";
        endText = false;

        if(Pause != null) { Pause.enabled = false; }

        sentences = new string[tutorial.sentences.Length];
        for(int i = 0; i < tutorial.sentences.Length; i++)
        {
            sentences[i] = tutorial.sentences[i];
        }
        headerText = tutorial.headerText;
        header.text = headerText;

        DisplayNextSentence();

        //Enabling all visual components
        Background.SetActive(true);
        textBox.SetActive(true);
        backgroundAnim.SetBool("isOpen", true);
        textBoxAnim.SetBool("isOpen", true);
    }


    //Displays the next sentence according to int CurrentSentence
    public void DisplayNextSentence()
    {
        if(currentSentence <= 0) { currentSentence = 0; }
        body.text = "";
        if (currentSentence == sentences.Length)
        {
            EndTutorial();
            return;
        }

        string sentence = sentences[currentSentence];
        string name = sentences[currentSentence];

        StopAllCoroutines();

        StartCoroutine(TypeSentence(sentence, name));
        currentSentence++;

    }

    public void DisplayLastSentence()
    {
        currentSentence-= 2;
        DisplayNextSentence();
    }

    IEnumerator TypeSentence(string sentence, string name)
    {
        pageNum.text = currentSentence + 1 + "      " + "/" + "     " + sentences.Length;
        //Typing letter by letter
        foreach (char letter in sentence.ToCharArray())
        {
            if (endText == true)
            {
                textBoxAnim.SetBool("isOpen", false);
                backgroundAnim.SetBool("isOpen", false);
            }

            body.text += letter;
            yield return null;
        }
    }

    public void EndTutorial()
    {
        if (Pause != null) { Pause.enabled = true; }
        currentSentence = 0;
        endText = true;
        backgroundAnim.SetBool("isOpen", false);
        textBoxAnim.SetBool("isOpen", false);
        Background.SetActive(false);
        textBox.SetActive(false);

    }

    private void Update()
    {
        if (isActive == true && Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }

        if (isActive == true && Input.GetKeyDown(KeyCode.Escape))
        {
            EndTutorial();
        }
    }
}

