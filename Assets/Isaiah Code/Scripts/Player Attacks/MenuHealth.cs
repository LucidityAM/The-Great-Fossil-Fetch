using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHealth : MonoBehaviour
{
    public Slider hpSlider;

    public BattleSystemFossil battleSystemFossil;

    // Update is called once per frame
    void Update()
    {
        hpSlider.value = battleSystemFossil.playerUnit.currentHP;
    }
}
