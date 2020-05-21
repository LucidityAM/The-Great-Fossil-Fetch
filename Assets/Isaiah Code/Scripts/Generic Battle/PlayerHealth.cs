using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider hpSlider;
    public Slider energySlider;

    public Text playerHealth, playerEnergy;
    void Update()
    {
        hpSlider.maxValue = 100;
    }
    
}
