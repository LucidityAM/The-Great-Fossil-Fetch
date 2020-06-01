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
    public GameObject tutorialImage;
    public Image tutorialSprite;
    private Animator tutorialImageAnim;
    private Animator textBoxAnim;
    private Animator backgroundAnim;

    //Player access for making them stop moving n stuff
    public GameObject Player;
    private PlayerMovementFinal Movement;
    private LoadBattle battleTrigger;
    public PauseScript Pause;

    //Pulbic arrays that represent the text
    private string headerText;
    private string[] sentences;
    private bool[] hasPictures;
    private Sprite[] images;

    //checks if ur in a convo
    private bool isActive;
    //checks if the text has ended
    private bool endText;
    private bool playedOnce;

    public static TutorialManager Instance;
    
    public Tutorial battleTutorial;

    //indicator of the current sentence
    private int currentSentence;

    void Start()
    {
        textBox.SetActive(false);
        Background.SetActive(false);
        tutorialImage.SetActive(false);
        endText = false;
        isActive = false;
        playedOnce = false;
        textBoxAnim = textBox.GetComponent<Animator>();
        backgroundAnim = Background.GetComponent<Animator>();
        Movement = Player.GetComponent<PlayerMovementFinal>();
        battleTrigger = Player.GetComponent<LoadBattle>();

        tutorialImageAnim = tutorialImage.GetComponent<Animator>();

        currentSentence = 0;
    }

    public void StartTutorial(Tutorial tutorial)
    {
        currentSentence = 0;
        Movement.enabled = false;
        battleTrigger.enabled = false;
        header.text = "";
        endText = false;

        if(Pause != null) { Pause.enabled = false; }

        sentences = new string[tutorial.sentences.Length];
        hasPictures = new bool[tutorial.hasPictures.Length];
        images = new Sprite[tutorial.images.Length];
        //creating arrays that can be accessed everywhere
        for(int i = 0; i < tutorial.sentences.Length; i++)
        {
            sentences[i] = tutorial.sentences[i];
        }
        for (int j = 0; j < tutorial.hasPictures.Length; j++)
        {
            hasPictures[j] = tutorial.hasPictures[j];
        }
        for (int k = 0; k < tutorial.images.Length; k++)
        {
            images[k] = tutorial.images[k];
        }
        headerText = tutorial.headerText;
        header.text = headerText;

        tutorialImageAnim.SetBool("isOpen", true);
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
        tutorialImageAnim.SetBool("isOpen", true);
        if (currentSentence <= 0) { currentSentence = 0; }
        if (currentSentence == sentences.Length)
        {
            EndTutorial();
            return;
        } 
        if (hasPictures[currentSentence] == true)
        {
            tutorialImage.SetActive(true);
            tutorialImageAnim.SetBool("isOpen", true);
            tutorialSprite.sprite = images[currentSentence];
        } else
        {
            tutorialImage.SetActive(false);
            tutorialImageAnim.SetBool("isOpen", false);
            tutorialSprite.sprite = null;
        }
        body.text = "";

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
        currentSentence = 0;
        Movement.enabled = true;
        battleTrigger.enabled = true;

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

        if (battleTutorial != null)
        { 
            if (BattleCount.battleCount == 1  && playedOnce == false &&  BattleCount.inBattle == true)
            {
                playedOnce = true;
                StartTutorial(battleTutorial);
                tutorialImageAnim.SetBool("isOpen", true);
            }
        }
    }
}

