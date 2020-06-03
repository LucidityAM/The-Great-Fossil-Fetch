using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FossilBattleHover : MonoBehaviour
{
    public GameObject fossilBattle;
    public GameObject instantiatedFossilBattle;

    public bool instantiated = false;
    public RectTransform spawnLocation;

    public Text flavorText;

    public void Delete()
    {
        DeleteInfo();
    }

    public void DeleteInfo()
    {

        instantiated = false;

        GameObject StatText = GameObject.FindWithTag("FossilBattleHover");
        Destroy(StatText);

    }

    public void ToggleInfo()
    {
        if (instantiated == false)
        {
            instantiatedFossilBattle = Instantiate(fossilBattle, spawnLocation);
            instantiatedFossilBattle.GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2
                (instantiatedFossilBattle.GetComponent<RectTransform>().anchoredPosition.x + 470f, GetComponent<RectTransform>().anchoredPosition.y);

            instantiatedFossilBattle.GetComponent<RectTransform>().rotation = Quaternion.identity;

            flavorText = instantiatedFossilBattle.transform.GetChild(0).gameObject.GetComponent<Text>();

            if (this.gameObject.name.Contains("Skull"))
            {
                switch (WeaponStats.skull)
                {
                    case 1:
                        flavorText.text = "An attack that deals decent damage to all enemies.";
                        break;
                    case 2:
                        flavorText.text = "An attack that drops a metor on the battlefield after 3 turns";
                        break;
                    case 3:
                        flavorText.text = "An attack that deals low damage to all enemies in battle and halves the damage output of all enemies of the 'Cursed' affinity.";
                        break;
                }
            }
            else if (this.gameObject.name.Contains("Neck"))
            {
                switch (WeaponStats.neck)
                {
                    case 1:
                        flavorText.text = "An attack that deals decent damage to all enemies then inverts all enemy affinities.";
                        break;
                    case 2:
                        flavorText.text = "An attack that swaps the player's health with a random enemy's health.";
                        break;
                    case 3:
                        flavorText.text = "An attack that deals massive damage to the middle two enemies.";
                        break;
                }
            }
            else if (this.gameObject.name.Contains("Ribs"))
            {
                switch (WeaponStats.ribs)
                {
                    case 1:
                        flavorText.text = "An attack that burns all enemies in battle 5 times.";
                        break;
                    case 2:
                        flavorText.text = "A special skill that switches all enemy affinities to a random affinity. Disables after one use.";
                        break;
                    case 3:
                        flavorText.text = "An attack that deals decent damage to all enemies in battle then switches any 'Cursed' affinity to 'Blessed'.";
                        break;
                }
            }
            else if (this.gameObject.name.Contains("Arms"))
            {
                switch (WeaponStats.arms)
                {
                    case 1:
                        flavorText.text = "An attack that deals massive damage to the frontmost enemy.";
                        break;
                    case 2:
                        flavorText.text = "An attack that deals massive damage to the last enemy.";
                        break;
                    case 3:
                        flavorText.text = "A special attack that steals half of the frontmost enemy's health and gives it to the player.";
                        break;
                }
            }
            else if (this.gameObject.name.Contains("Legs"))
            {
                switch (WeaponStats.legs)
                {
                    case 1:
                        flavorText.text = "An attack that brings you down to 1 HP, but deals damage depending on how much health is lost to the attack, ignoring enemy affinities.";
                        break;
                    case 2:
                        flavorText.text = "An attack that deals decent damage to the front two enemies.";
                        break;
                    case 3:
                        flavorText.text = "A special skill that heals the player for full health. Disables after one use.";
                        break;
                }
            }
            else if (this.gameObject.name.Contains("Tail"))
            {
                switch (WeaponStats.tail)
                {
                    case 1:
                        flavorText.text = "An attack that uses an RNG to select a random attack to use.";
                        break;
                    case 2:
                        flavorText.text = "An attack that hits all enemies for even damage.";
                        break;
                    case 3:
                        flavorText.text = "An attack that deals poor damage to all enemies.";
                        break;
                }
            }


            instantiated = true;
        }
        else
        {
            GameObject StatText = GameObject.FindWithTag("FossilBattleHover");
            Destroy(StatText);

            instantiated = false;
        }

    }
}
