using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeWeaponStats : MonoBehaviour
{

    public GameObject fossilInfoText;

    public int[] fossilDurabilitys = new int[18];

    public Image BG;
    public Text fossilPart;
    public Text fossilName;
    public Text fossilDurability;

    public void Start()
    {
        fossilInfoText = GameObject.FindGameObjectWithTag("FossilInfoText");

        if(WeaponStats.isSet == false)
        {
            WeaponStats.fossilDurability[0] = 15;
            WeaponStats.fossilDurability[1] = 3;
            WeaponStats.fossilDurability[2] = 10;
            WeaponStats.fossilDurability[3] = 7;
            WeaponStats.fossilDurability[4] = 5;
            WeaponStats.fossilDurability[5] = 3;
            WeaponStats.fossilDurability[6] = 20;
            WeaponStats.fossilDurability[7] = 7;
            WeaponStats.fossilDurability[8] = 12;
            WeaponStats.fossilDurability[9] = 10;
            WeaponStats.fossilDurability[10] = 10;
            WeaponStats.fossilDurability[11] = 7;
            WeaponStats.fossilDurability[12] = 5;
            WeaponStats.fossilDurability[13] = 7;
            WeaponStats.fossilDurability[14] = 5;
            WeaponStats.fossilDurability[15] = 20;
            WeaponStats.fossilDurability[16] = 15;
            WeaponStats.fossilDurability[17] = 15;

            WeaponStats.isSet = true;
        }
        else
        {
            WeaponStats.isSet = true;
        }

        
        fossilDurabilitys[0] = 15;
        fossilDurabilitys[1] = 3;
        fossilDurabilitys[2] = 10;
        fossilDurabilitys[3] = 7;
        fossilDurabilitys[4] = 5;
        fossilDurabilitys[5] = 3;
        fossilDurabilitys[6] = 20;
        fossilDurabilitys[7] = 7;
        fossilDurabilitys[8] = 12;
        fossilDurabilitys[9] = 10;
        fossilDurabilitys[10] = 10;
        fossilDurabilitys[11] = 7;
        fossilDurabilitys[12] = 5;
        fossilDurabilitys[13] = 7;
        fossilDurabilitys[14] = 5;
        fossilDurabilitys[15] = 20;
        fossilDurabilitys[16] = 15;
        fossilDurabilitys[17] = 15;
    }

    void FixedUpdate()
    {
        if(fossilInfoText == null)
        {
            fossilInfoText = GameObject.FindGameObjectWithTag("FossilInfoText");
        }
    }

    public float[,] fossilStats = new float[18, 2]
    {
        //Skulls
        {10f, .5f,}, //Skull 1
        {10f, .5f,}, //Skull 2
        {10f, .5f,}, //Skull 3

         //Necks
        {10f, .5f,}, //Neck 1
        {10f, .5f,}, //Neck 2
        {10f, .5f,}, //Neck 3

         //Ribs
        {10f, .5f,}, //Rib 1
        {10f, .5f,}, //Rib 2
        {10f, .5f,}, //Rib 3

         //Arms
        {10f, .5f,}, //Arm 1
        {10f, .5f,}, //Arm 2
        {10f, .5f,}, //Arm 3

         //Legs
        {10f, .5f,}, //Leg 1
        {10f, .5f,}, //Leg 2
        {10f, .5f,}, //Leg 3

         //Tails
        {10f, .5f,}, //Tail 1
        {10f, .5f,}, //Tail 2
        {10f, .5f,}, //Tail 3
        
   };//Simply a 2D array that holds the attack and defense stats for each fossil

    public void Update()
    {
        if (gameObject.name.Contains("Base"))
        {
            if(BG == null)
            {
                BG = gameObject.transform.GetChild(0).gameObject.GetComponent<Image>();
            }
            
            if(fossilPart == null)
            {
                fossilPart = gameObject.transform.GetChild(1).gameObject.GetComponent<Text>();
            }

            if(fossilName == null)
            {
                fossilName = gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();
            }

            if(fossilDurability == null)
            {
                fossilDurability = gameObject.transform.GetChild(3).gameObject.GetComponent<Text>();
            }
            
            //Grabs the Background, fossil part, name, and durability from the specific fossil in the inventory so it can be edited later

            for (int i = 0; i < WeaponStats.fossilsOutOfSpaces.Length; i++)
            {

                if (WeaponStats.fossilsOutOfSpaces[i] != null)
                {
                    for(int j = 0; j < WeaponStats.fossilsOutOfSpaces.Length; j++)
                    {
                        if (gameObject.tag.ToString() == WeaponStats.fossilsOutOfSpaces[j])
                        {

                            if (WeaponStats.fossilDurability[j] > 0)
                            {
                                fossilDurability.text = WeaponStats.fossilDurability[j] + "/" + fossilDurabilitys[j];
                            }//Sets the durability text of the fossil in the inventory
                            else
                            {
                                BG.color = Color.black;
                                fossilPart.text = "Broken";
                                fossilName.text = "Broken";
                                fossilDurability.text = "Broken";

                                for (int k = 0; k < WeaponStats.objectsInSpaces.Length; k++)
                                {
                                    if(WeaponStats.objectsInSpaces[k] != null && WeaponStats.fossilsOutOfSpaces[k] != null)
                                    {
                                        if (WeaponStats.fossilsOutOfSpaces[k] == WeaponStats.objectsInSpaces[k].tag)
                                        {
                                            if(WeaponStats.fossilDurability[k] < 0)
                                            {
                                                WeaponStats.objectsInSpaces[k].GetComponent<Button>().enabled = false;
                                            }
                                        }
                                    }
                                }

                                if (WeaponStats.fossilsOutOfSpaces[j].Contains("skull"))
                                {
                                    WeaponStats.skull = 0;
                                }
                                else if (WeaponStats.fossilsOutOfSpaces[j].Contains("neck"))
                                {
                                    WeaponStats.neck = 0;
                                }
                                else if (WeaponStats.fossilsOutOfSpaces[j].Contains("ribs"))
                                {
                                    WeaponStats.ribs = 0;
                                }
                                else if (WeaponStats.fossilsOutOfSpaces[j].Contains("arms"))
                                {
                                    WeaponStats.arms = 0;
                                }
                                else if (WeaponStats.fossilsOutOfSpaces[j].Contains("legs"))
                                {
                                    WeaponStats.legs = 0;
                                }
                                else if (WeaponStats.fossilsOutOfSpaces[j].Contains("tail"))
                                {
                                    WeaponStats.tail = 0;
                                }
                                //If the durability of a specific fossil is less than 0, indicate that it's broken
                            }
                        }
                    } 
                } 
            }
        }
    }
    public void InstantiateInfo()
    {
        fossilInfoText.SetActive(true);

        if (this.gameObject.CompareTag("skull1"))
        {
            StatString.attack = fossilStats[0, 0];
            StatString.defense = fossilStats[0, 1];
            StatString.fossilName = "Pitch Black Darkness";
            StatString.durability = WeaponStats.fossilDurability[0] + "/15";
            StatString.fossilPart = "Skull";
            StatString.flavorText = "An attack that deals decent damage to all enemies.";
            StatString.affinity = "cursed";
        }
        else if (this.gameObject.CompareTag("skull2"))
        {
            StatString.attack = fossilStats[1, 0];
            StatString.defense = fossilStats[1, 1];
            StatString.fossilName = "Meteor Strike";
            StatString.durability = WeaponStats.fossilDurability[1] + "/3";
            StatString.fossilPart = "Skull";
            StatString.flavorText = "An attack that drops a metor on the battlefield after 3 turns";
            StatString.affinity = "soma";
        }
        else if (this.gameObject.CompareTag("skull3"))
        {
            StatString.attack = fossilStats[2, 0];
            StatString.defense = fossilStats[2, 1];
            StatString.fossilName = "Albino Skull";
            StatString.durability = WeaponStats.fossilDurability[2] + "/10";
            StatString.fossilPart = "Skull";
            StatString.flavorText = "An attack that deals low damage to all enemies in battle and halves the damage output of all enemies of the 'Cursed' affinity.";
            StatString.affinity = "blessed";
        }
        else if (this.gameObject.CompareTag("neck1"))
        {
            StatString.attack = fossilStats[3, 0];
            StatString.defense = fossilStats[3, 1];
            StatString.fossilName = "Dark Pulse";
            StatString.durability = WeaponStats.fossilDurability[3] + "/7";
            StatString.fossilPart = "Neck";
            StatString.flavorText = "An attack that deals decent damage to all enemies then inverts all enemy affinities.";
            StatString.affinity = "cursed";
        }
        else if (this.gameObject.CompareTag("neck2"))
        {
            StatString.attack = fossilStats[4, 0];
            StatString.defense = fossilStats[4, 1];
            StatString.fossilName = "Vitality Swap";
            StatString.durability = WeaponStats.fossilDurability[4] + "/5";
            StatString.fossilPart = "Neck";
            StatString.flavorText = "An attack that swaps the player's health with a random enemy's health.";
            StatString.affinity = "soma";
        }
        else if (this.gameObject.CompareTag("neck3"))
        {
            StatString.attack = fossilStats[5, 0];
            StatString.defense = fossilStats[5, 1];
            StatString.fossilName = "Ephemeral Essence";
            StatString.durability = WeaponStats.fossilDurability[5] + "/3";
            StatString.fossilPart = "Neck";
            StatString.flavorText = "An attack that deals massive damage to the middle two enemies.";
            StatString.affinity = "blessed";
        }
        else if (this.gameObject.CompareTag("ribs1"))
        {
            StatString.attack = fossilStats[6, 0];
            StatString.defense = fossilStats[6, 1];
            StatString.fossilName = "Blazing Inferno";
            StatString.durability = WeaponStats.fossilDurability[6] + "/20";
            StatString.fossilPart = "Rib";
            StatString.flavorText = "An attack that burns all enemies in battle 5 times.";
            StatString.affinity = "cursed";
        }
        else if (this.gameObject.CompareTag("ribs2"))
        {
            StatString.attack = fossilStats[7, 0];
            StatString.defense = fossilStats[7, 1];
            StatString.fossilName = "Purify Arena";
            StatString.durability = WeaponStats.fossilDurability[7] + "/7";
            StatString.fossilPart = "Rib";
            StatString.flavorText = "A special skill that switches all enemy affinities to a random affinity. Disables after one use.";
            StatString.affinity = "soma";
        }
        else if (this.gameObject.CompareTag("ribs3"))
        {
            StatString.attack = fossilStats[8, 0];
            StatString.defense = fossilStats[8, 1];
            StatString.fossilName = "Cleansing Vapor";
            StatString.durability = WeaponStats.fossilDurability[8] + "/12";
            StatString.fossilPart = "Rib";
            StatString.flavorText = "An attack that deals decent damage to all enemies in battle then switches any 'Cursed' affinity to 'Blessed'.";
            StatString.affinity = "blessed";
        }
        else if (this.gameObject.CompareTag("arms1"))
        {
            StatString.attack = fossilStats[9, 0];
            StatString.defense = fossilStats[9, 1];
            StatString.fossilName = "Phantom Talons";
            StatString.durability = WeaponStats.fossilDurability[9] + "/10";
            StatString.fossilPart = "Arm";
            StatString.flavorText = "An attack that deals massive damage to the frontmost enemy.";
            StatString.affinity = "cursed";
        }
        else if (this.gameObject.CompareTag("arms2"))
        {
            StatString.attack = fossilStats[10, 0];
            StatString.defense = fossilStats[10, 1];
            StatString.fossilName = "Reverse Strike";
            StatString.durability = WeaponStats.fossilDurability[10] + "/10";
            StatString.fossilPart = "Arm";
            StatString.flavorText = "An attack that deals massive damage to the last enemy.";
            StatString.affinity = "soma";
        }
        else if (this.gameObject.CompareTag("arms3"))
        {
            StatString.attack = fossilStats[11, 0];
            StatString.defense = fossilStats[11, 1];
            StatString.fossilName = "Vampiric Fang";
            StatString.durability = WeaponStats.fossilDurability[11] + "/7";
            StatString.fossilPart = "Arm";
            StatString.flavorText = "A special attack that steals half of the frontmost enemy's health and gives it to the player.";
            StatString.affinity = "blessed";
        }
        else if (this.gameObject.CompareTag("legs1"))
        {
            StatString.attack = fossilStats[12, 0];
            StatString.defense = fossilStats[12, 1];
            StatString.fossilName = "All Out Attack";
            StatString.durability = WeaponStats.fossilDurability[12] + "/5";
            StatString.fossilPart = "Leg";
            StatString.flavorText = "An attack that brings you down to 1 HP, but deals damage depending on how much health is lost to the attack, ignoring enemy affinities.";
            StatString.affinity = "cursed";

        }
        else if (this.gameObject.CompareTag("legs2"))
        {
            StatString.attack = fossilStats[13, 0];
            StatString.defense = fossilStats[13, 1];
            StatString.fossilName = "Low Kick";
            StatString.durability = WeaponStats.fossilDurability[13] + "/7";
            StatString.fossilPart = "Leg";
            StatString.flavorText = "An attack that deals decent damage to the front two enemies.";
            StatString.affinity = "soma";
        }
        else if (this.gameObject.CompareTag("legs3"))
        {
            StatString.attack = fossilStats[14, 0];
            StatString.defense = fossilStats[14, 1];
            StatString.fossilName = "Ancient Relic";
            StatString.durability = WeaponStats.fossilDurability[14] + "/5";
            StatString.fossilPart = "Leg";
            StatString.flavorText = "A special skill that heals the player for full health. Disables after one use.";
            StatString.affinity = "blessed";
        }
        else if (this.gameObject.CompareTag("tail1"))
        {
            StatString.attack = fossilStats[15, 0];
            StatString.defense = fossilStats[15, 1];
            StatString.fossilName = "Secret Power";
            StatString.durability = WeaponStats.fossilDurability[15] + "/20";
            StatString.fossilPart = "Tail";
            StatString.flavorText = "An attack that uses an RNG to select a random attack to use.";
            StatString.affinity = "cursed";
        }
        else if (this.gameObject.CompareTag("tail2"))
        {
            StatString.attack = fossilStats[16, 0];
            StatString.defense = fossilStats[16, 1];
            StatString.fossilName = "Tail Stab";
            StatString.durability = WeaponStats.fossilDurability[16] + "/15";
            StatString.fossilPart = "Tail";
            StatString.flavorText = "An attack that hits all enemies for even damage.";
            StatString.affinity = "soma";
        }
        else if (this.gameObject.CompareTag("tail3"))
        {
            StatString.attack = fossilStats[17, 0];
            StatString.defense = fossilStats[17, 1];
            StatString.fossilName = "Holy Bone Spear";
            StatString.durability = WeaponStats.fossilDurability[17] + "/15";
            StatString.fossilPart = "Tail";
            StatString.flavorText = "An attack that deals poor damage to all enemies.";
            StatString.affinity = "blessed";
        }

    }//If you hover over a specific fossil in the inventory, check the tag of it and then display the appropriate text;

    public void DestroyInfo()
    {
        fossilInfoText.SetActive(false);

        StatString.fossilName = null;
        StatString.durability = null;
        StatString.fossilPart = null;
        StatString.flavorText = null;
        StatString.affinity = null;

    }//When you stop hovering over a fossil, sets all the text to null and turns off the object that holds all the text
}
