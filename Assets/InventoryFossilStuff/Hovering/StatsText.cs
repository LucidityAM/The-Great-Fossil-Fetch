using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsText : MonoBehaviour
{
    public Text statName;
    public Text infoText;
    public Text currentValue;
    public Text swordAttack;
    void Update()
    {
        /*
        statName.text = Ristatic.stat;

        if (Ristatic.stat.Contains("Attack Rate"))
        {
            infoText.text = "The speed that Agnes attacks (limited only to projectiles)";
            currentValue.text = "Value: " + (PlayerStats.attackRate + PlayerStats.attackRateModifier);
            swordAttack.text = "";
        }
        else if (Ristatic.stat.Contains("Strength"))
        {
            infoText.text = "The amount of damage dealt by an attack";
            currentValue.text = "Value for Projectiles: " + (PlayerStats.strength + PlayerStats.strengthModifier);
            swordAttack.text = "Value for Sword: " + ((PlayerStats.strength * 1.5f) + PlayerStats.strengthModifier);
        }
        else if (Ristatic.stat.Contains("Speed"))
        {
            infoText.text = "The speed that Agnes moves";
            currentValue.text = "Value: " + (decimal.Round(new decimal(PlayerStats.speed) + new decimal(PlayerStats.speedModifier), 2));
            swordAttack.text = "";
        }
        else if (Ristatic.stat.Contains("Resolve"))
        {
            infoText.text = "The amount increase and decrease of Agnes's confidence (higher value, more gain, less loss)";
            currentValue.text = "Value: " + PlayerStats.resolve;
            swordAttack.text = "";
        }
        else if (Ristatic.stat.Contains("Range"))
        {
            infoText.text = "The range of a bullet (in seconds)";
            currentValue.text = "Value: " + PlayerStats.range * .0035f;
            swordAttack.text = "";
        }
        */
    }
}
