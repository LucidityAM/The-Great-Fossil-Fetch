using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    //stuff that needs to be disabled
    public PlayerMovementFinal playerMovement;
    public LoadBattle battleTrigger;
    public GameObject player;
    public MenuSoundManager menuSound;

    public AudioClip openSound;
    public AudioClip backSound;
    //check if paused 
    private bool isPaused;

    //visual background
    public GameObject menuBG;
    //check what menu you are in
    private int menuState;
    //Menu components
    public GameObject mainMenu;
    public GameObject inventory;
    public GameObject status;
    public GameObject fossils;
    public GameObject system;
    public GameObject help;

    //Animators for the menu components
    private Animator mainMenuAnim;
    private Animator inventoryAnim;
    private Animator statusAnim;
    private Animator fossilsAnim;
    private Animator systemAnim;
    private Animator helpAnim;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        menuBG.SetActive(false);

        //Getting animators then disabling
        mainMenuAnim = mainMenu.GetComponent<Animator>(); 
        mainMenu.SetActive(false); 
        inventoryAnim = inventory.GetComponent<Animator>(); 
        inventory.SetActive(false);
        statusAnim = status.GetComponent<Animator>();
        status.SetActive(false);
        fossilsAnim = fossils.GetComponent<Animator>();
        fossils.SetActive(false);
        systemAnim = system.GetComponent<Animator>();
        system.SetActive(false);
        helpAnim = help.GetComponent<Animator>();
        help.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Menu States: 0 = Main Menu, 1 = Inventory, 2 = Status, 3 = Fossils, 4 = System
            if (!isPaused)
            {
                StartCoroutine("OpenMenu");
                menuSound.PlaySound(openSound);
            }
            else if (menuState != 0 && menuState != 5)
            {
                mainMenuAnim.SetBool("isClosed2", false);
                StartCoroutine("CloseAllSubMenus");
                menuSound.PlaySound(backSound);
            }
            else if (menuState == 5) { StartCoroutine("CloseIntoSystem"); }
            else
            {
                StartCoroutine("CloseMenu");
                menuSound.PlaySound(backSound);
            }
        }

        if(isPaused == true)
        {
            playerMovement.enabled = false;
            battleTrigger.enabled = false;
            playerMovement.enabled = true;
            battleTrigger.enabled = true;
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    //Opens Menus
    IEnumerator OpenMenu()
    {
        menuState = 0;
        isPaused = true;
        //Disabling player and stuff;

        //Enabling menu and stuff
        mainMenu.SetActive(true);
        mainMenuAnim.SetBool("isOpen", true);
        menuBG.SetActive(true);
        yield return null;
    }

    //Closes Menus
    IEnumerator CloseMenu()
    {
        menuBG.SetActive(false);
        menuState = 0;
        isPaused = false;

        //Enabling menu and stuff. i cant do an array for some reason cuz it gets anrgy at me :(
        mainMenuAnim.SetBool("isOpen", false);
        inventoryAnim.SetBool("isOpen", false);
        statusAnim.SetBool("isOpen", false);
        fossilsAnim.SetBool("isOpen", false);
        systemAnim.SetBool("isOpen", false);
        helpAnim.SetBool("isOpen", false);

        yield return new WaitForSeconds(0.2f);

        mainMenu.SetActive(false);
        inventory.SetActive(false);
        status.SetActive(false);
        fossils.SetActive(false);
        system.SetActive(false);
        help.SetActive(false);
        menuBG.SetActive(false);
    }

    IEnumerator CloseAllSubMenus()
    {
        menuState = 0;
        inventoryAnim.SetBool("isOpen", false);
        statusAnim.SetBool("isOpen", false);
        fossilsAnim.SetBool("isOpen", false);
        systemAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.1f);
        inventory.SetActive(false);
        status.SetActive(false);
        fossils.SetActive(false);
        system.SetActive(false);
        mainMenuAnim.SetBool("isClosed2", false);
        mainMenuAnim.SetBool("isOpen", true);
    }

    IEnumerator CloseIntoSystem()
    {
        menuState = 4;
        helpAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.4f);
        help.SetActive(false);
    }

    //Methods that Open Each Inventory piece
    public IEnumerator Inventory()
    {
        menuState = 1;
        mainMenuAnim.SetBool("isClosed2", true);
        inventory.SetActive(true);
        inventoryAnim.SetBool("isOpen", true);
        yield return null;
    }

    public IEnumerator Status()
    {
        menuState = 2;
        mainMenuAnim.SetBool("isClosed2", true);
        status.SetActive(true);
        statusAnim.SetBool("isOpen", true);
        yield return null;
    }

    public IEnumerator Fossils()
    {
        menuState = 3;
        mainMenuAnim.SetBool("isClosed2", true);
        fossils.SetActive(true);
        fossilsAnim.SetBool("isOpen", true);
        yield return null;
    }

    public IEnumerator System()
    {
        menuState = 4;
        mainMenuAnim.SetBool("isClosed2", true);
        system.SetActive(true);
        systemAnim.SetBool("isOpen", true);
        yield return null;
    }

    public IEnumerator Help()
    {
        menuState = 5;
        help.SetActive(true);
        helpAnim.SetBool("isOpen", true);
        yield return null;
    }

    //Button Methods to open the menus
    public void Open(string MenuName)
    {
        StartCoroutine(MenuName);
    }
}
