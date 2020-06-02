using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenAnimation : MonoBehaviour
{
    //takes whole game screen Object
    public GameObject WinScreen;

    public Animator fossilsAnim;
    public Animator artAnim;
    public Animator HPAnim;

    public Text fossilName;

    public bool inWinScreen;

    // Start is called before the first frame update
    void Start()
    {
        inWinScreen = false;

        WinScreen.SetActive(false);

        fossilsAnim.SetBool("isOpen", false);
        artAnim.SetBool("isOpen", false);
        HPAnim.SetBool("isOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(inWinScreen == true && Input.GetKeyDown(KeyCode.Escape)) { StartCoroutine(CloseWinScreen()); }

        switch (WeaponStats.fossilGenerated)
        {
            case 0:
                fossilName.text = "Pitch Black Darkness";
                break;
            case 1:
                fossilName.text = "MeteorStrike";
                break;
            case 2:
                fossilName.text = "Albino Skull";
                break;
            case 3:
                fossilName.text = "Dark Pulse";
                break;
            case 4:
                fossilName.text = "Vitality Swap";
                break;
            case 5:
                fossilName.text = "Ephemeral Essence";
                break;
            case 6:
                fossilName.text = "Blazing Inferno";
                break;
            case 7:
                fossilName.text = "Purify Arena";
                break;
            case 8:
                fossilName.text = "Cleansing Vapor";
                break;
            case 9:
                fossilName.text = "Phantom Talons";
                break;
            case 10:
                fossilName.text = "Reverse Strike";
                break;
            case 11:
                fossilName.text = "Vampiric Fang";
                break;
            case 12:
                fossilName.text = "All Out Attack";
                break;
            case 13:
                fossilName.text = "Low Kick";
                break;
            case 14:
                fossilName.text = "Ancient Relic";
                break;
            case 15:
                fossilName.text = "Secret Power";
                break;
            case 16:
                fossilName.text = "Tail Stab";
                break;
            case 17:
                fossilName.text = "Holy Bone Spear";
                break;
        }

    }


    public IEnumerator OpenWinScreen()
    {
        inWinScreen = true;

        WinScreen.SetActive(true);
        artAnim.SetBool("isOpen", true);
        yield return new WaitForSeconds(0.3f);
        fossilsAnim.SetBool("isOpen", true);
        yield return new WaitForSeconds(0.4f);
        HPAnim.SetBool("isOpen", true);
    }

    public void StartIEnumerator(string name)
    {
        StartCoroutine(name);
    }

    public IEnumerator CloseWinScreen()
    {
        inWinScreen = false;

        HPAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.3f);
        artAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.4f);
        fossilsAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.6f);
        WinScreen.SetActive(false);

    }
}
