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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator OpenWinScreen()
    {
        WinScreen.SetActive(true);

    }
}
