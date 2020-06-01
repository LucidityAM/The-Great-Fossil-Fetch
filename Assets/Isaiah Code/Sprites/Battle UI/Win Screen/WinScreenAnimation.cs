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

    // Start is called before the first frame update
    void Start()
    {
        WinScreen.SetActive(false);

        fossilsAnim.SetBool("isOpen", false);
        artAnim.SetBool("isOpen", false);
        HPAnim.SetBool("isOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OpenWinScreen()
    {
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
        HPAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.3f);
        artAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.4f);
        fossilsAnim.SetBool("isOpen", false);
        yield return new WaitForSeconds(0.6f);
        WinScreen.SetActive(false);

    }
}
