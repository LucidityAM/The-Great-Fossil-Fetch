using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenAnimation : MonoBehaviour
{
    //takes whole game screen Object
    public GameObject WinScreen;

    public Animator fossilsAnim;
    public Animator artAnim;
    public Animator HPAnim;

    public bool inWinScreen;

    public int fossilGenerated;

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
