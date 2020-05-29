using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditDisplay : MonoBehaviour
{
    public GameObject CreditsCanvas;
    public Image CreditImage;
    // Start is called before the first frame update
    void Start()
    {
        CreditsCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCredits(Sprite image)
    {
        CreditsCanvas.SetActive(true);
        CreditImage.sprite = image;
    }
    
    public void CloseCredits()
    {
        CreditsCanvas.SetActive(false);
    }
}
