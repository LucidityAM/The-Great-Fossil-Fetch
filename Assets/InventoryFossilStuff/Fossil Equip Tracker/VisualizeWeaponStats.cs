using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeWeaponStats : MonoBehaviour
{

    public GameObject fossilInfoText;

    public void Awake()
    {
        fossilInfoText = GameObject.FindGameObjectWithTag("FossilInfoText");

        WeaponStats.fossilDurability[6] = 2;
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
        for(int i = 0; i < WeaponStats.fossilsOutOfSpaces.Length; i++)
        {
            if(WeaponStats.fossilsOutOfSpaces[i] != null)
            {
                Image BG = WeaponStats.fossilsOutOfSpaces[i].transform.GetChild(0).gameObject.GetComponent<Image>();
                Text fossilPart = WeaponStats.fossilsOutOfSpaces[i].transform.GetChild(1).gameObject.GetComponent<Text>();
                Text fossilName = WeaponStats.fossilsOutOfSpaces[i].transform.GetChild(2).gameObject.GetComponent<Text>();
                Text fossilDurability = WeaponStats.fossilsOutOfSpaces[i].transform.GetChild(3).gameObject.GetComponent<Text>();
                //Grabs the Background, fossil part, name, and durability from the specific fossil in the inventory so it can be edited later

                if(WeaponStats.fossilDurability[i] > 0)
                {
                    fossilDurability.text = WeaponStats.fossilDurability[i] + "/XX";

                }//Sets the durability text of the fossil in the inventory
                else
                {
                    BG.color = Color.black;
                    fossilPart.text = "Broken";
                    fossilName.text = "Broken";
                    fossilDurability.text = "Broken";
                    WeaponStats.fossilsOutOfSpaces[i].GetComponent<Button>().enabled = false;

                    if(WeaponStats.fossilsOutOfSpaces[i].tag.Contains("skull"))
                    {
                        WeaponStats.skull = 0;
                    }
                    else if (WeaponStats.fossilsOutOfSpaces[i].tag.Contains("neck"))
                    {
                        WeaponStats.neck = 0;
                    }
                    else if (WeaponStats.fossilsOutOfSpaces[i].tag.Contains("ribs"))
                    {
                        WeaponStats.ribs = 0;
                    }
                    else if (WeaponStats.fossilsOutOfSpaces[i].tag.Contains("arms"))
                    {
                        WeaponStats.arms = 0;
                    }
                    else if (WeaponStats.fossilsOutOfSpaces[i].tag.Contains("legs"))
                    {
                        WeaponStats.legs = 0;
                    }
                    else if (WeaponStats.fossilsOutOfSpaces[i].tag.Contains("tail"))
                    {
                        WeaponStats.tail = 0;
                    }

                }//If the durability of a specific fossil is less than 0, indicate that it's broken
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
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[0] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("skull2"))
        {
            StatString.attack = fossilStats[1, 0];
            StatString.defense = fossilStats[1, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[1] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("skull3"))
        {
            StatString.attack = fossilStats[2, 0];
            StatString.defense = fossilStats[2, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[2] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("neck1"))
        {
            StatString.attack = fossilStats[3, 0];
            StatString.defense = fossilStats[3, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[3] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("neck2"))
        {
            StatString.attack = fossilStats[4, 0];
            StatString.defense = fossilStats[4, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[4] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("neck3"))
        {
            StatString.attack = fossilStats[5, 0];
            StatString.defense = fossilStats[5, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[5] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("ribs1"))
        {
            StatString.attack = fossilStats[6, 0];
            StatString.defense = fossilStats[6, 1];
            StatString.fossilName = "Blazing Inferno";
            StatString.durability = WeaponStats.fossilDurability[6] + "/XX";
            StatString.fossilPart = "Ribs";
            StatString.flavorText = "PlacementPlacementPlacementPlacementPlacementPlacementPlacementPlacementPlacementPlacement";
            StatString.affinity = "cursed";
        }
        else if (this.gameObject.CompareTag("ribs2"))
        {
            StatString.attack = fossilStats[7, 0];
            StatString.defense = fossilStats[7, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[7] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("ribs3"))
        {
            StatString.attack = fossilStats[8, 0];
            StatString.defense = fossilStats[8, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[8] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("arms1"))
        {
            StatString.attack = fossilStats[9, 0];
            StatString.defense = fossilStats[9, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[9] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("arms2"))
        {
            StatString.attack = fossilStats[10, 0];
            StatString.defense = fossilStats[10, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[10] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("arms3"))
        {
            StatString.attack = fossilStats[11, 0];
            StatString.defense = fossilStats[11, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[11] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("legs1"))
        {
            StatString.attack = fossilStats[12, 0];
            StatString.defense = fossilStats[12, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[12] + "/XX";
<<<<<<< HEAD
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
=======
            StatString.fossilPart = "Leg";
            StatString.flavorText = "An attack that brings you down to 1 HP, but deals damage depending on how much health is lost to the attack, ignoring enemy affinities.";
            StatString.affinity = "Cursed";
>>>>>>> parent of 47d4fea... Fixed Weapon descriptions.
        }
        else if (this.gameObject.CompareTag("legs2"))
        {
            StatString.attack = fossilStats[13, 0];
            StatString.defense = fossilStats[13, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[13] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("legs3"))
        {
            StatString.attack = fossilStats[14, 0];
            StatString.defense = fossilStats[14, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[14] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("tail1"))
        {
            StatString.attack = fossilStats[15, 0];
            StatString.defense = fossilStats[15, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[15] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("tail2"))
        {
            StatString.attack = fossilStats[16, 0];
            StatString.defense = fossilStats[16, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[16] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("tail3"))
        {
            StatString.attack = fossilStats[17, 0];
            StatString.defense = fossilStats[17, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = WeaponStats.fossilDurability[17] + "/XX";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
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
