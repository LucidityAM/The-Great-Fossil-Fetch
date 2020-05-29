using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCreditDisplay : MonoBehaviour
{
    public GameObject creditScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            creditScreen.SetActive(false);
        }    
    }
}
