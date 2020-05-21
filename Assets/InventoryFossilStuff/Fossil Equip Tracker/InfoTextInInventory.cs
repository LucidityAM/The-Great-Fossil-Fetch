using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTextInInventory : MonoBehaviour
{
    public Text attack;
    public Text defense;
    public Text durability;
    public Text fossilName;
    public Text fossilPart;
    public Text flavorText;
    public Image affinity;

    public Sprite cursed;
    public Sprite blessed;
    public Sprite soma;
    public void Update()
    {

        fossilName.text = StatString.fossilName;
        durability.text = StatString.durability;
        flavorText.text = StatString.flavorText;
        fossilPart.text = StatString.fossilPart;
        durability.text = StatString.durability;

        if(StatString.affinity == "blessed")
        {
            affinity.enabled = true;
            affinity.sprite = blessed;
        }
        else if (StatString.affinity == "cursed")
        {
            affinity.enabled = true;
            affinity.sprite = cursed;
        }
        else if (StatString.affinity == "soma")
        {
            affinity.enabled = true;
            affinity.sprite = soma;
        }
        else
        {
            affinity.enabled = false;
        }
    }
}
