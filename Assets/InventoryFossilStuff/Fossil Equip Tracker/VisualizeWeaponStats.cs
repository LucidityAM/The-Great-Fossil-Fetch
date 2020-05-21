using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeWeaponStats : MonoBehaviour
{

    public GameObject fossilInfoText;

    public void Awake()
    {
        fossilInfoText = GameObject.FindGameObjectWithTag("FossilInfoText");
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
        
   };

    public void InstantiateInfo()
    {
        fossilInfoText.SetActive(true);

        if (this.gameObject.CompareTag("skull1"))
        {
            StatString.attack = fossilStats[0, 0];
            StatString.defense = fossilStats[0, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("skull2"))
        {
            StatString.attack = fossilStats[1, 0];
            StatString.defense = fossilStats[1, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("skull3"))
        {
            StatString.attack = fossilStats[2, 0];
            StatString.defense = fossilStats[2, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("neck1"))
        {
            StatString.attack = fossilStats[3, 0];
            StatString.defense = fossilStats[3, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("neck2"))
        {
            StatString.attack = fossilStats[4, 0];
            StatString.defense = fossilStats[4, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("neck3"))
        {
            StatString.attack = fossilStats[5, 0];
            StatString.defense = fossilStats[5, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("ribs1"))
        {
            StatString.attack = fossilStats[6, 0];
            StatString.defense = fossilStats[6, 1];
            StatString.fossilName = "Blazing Inferno";
            StatString.durability = "Durability: XX/XX";
            StatString.fossilPart = "Ribs";
            StatString.flavorText = "PlacementPlacementPlacementPlacementPlacementPlacementPlacementPlacementPlacementPlacement";
            StatString.affinity = "cursed";
        }
        else if (this.gameObject.CompareTag("ribs2"))
        {
            StatString.attack = fossilStats[7, 0];
            StatString.defense = fossilStats[7, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("ribs3"))
        {
            StatString.attack = fossilStats[8, 0];
            StatString.defense = fossilStats[8, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("arms1"))
        {
            StatString.attack = fossilStats[9, 0];
            StatString.defense = fossilStats[9, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("arms2"))
        {
            StatString.attack = fossilStats[10, 0];
            StatString.defense = fossilStats[10, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("arms3"))
        {
            StatString.attack = fossilStats[11, 0];
            StatString.defense = fossilStats[11, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("legs1"))
        {
            StatString.attack = fossilStats[12, 0];
            StatString.defense = fossilStats[12, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("legs2"))
        {
            StatString.attack = fossilStats[13, 0];
            StatString.defense = fossilStats[13, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("legs3"))
        {
            StatString.attack = fossilStats[14, 0];
            StatString.defense = fossilStats[14, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("tail1"))
        {
            StatString.attack = fossilStats[15, 0];
            StatString.defense = fossilStats[15, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("tail2"))
        {
            StatString.attack = fossilStats[16, 0];
            StatString.defense = fossilStats[16, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }
        else if (this.gameObject.CompareTag("tail3"))
        {
            StatString.attack = fossilStats[17, 0];
            StatString.defense = fossilStats[17, 1];
            StatString.fossilName = "PlacementPlacement";
            StatString.durability = "PlacementPlacement";
            StatString.fossilPart = "PlacementPlacement";
            StatString.flavorText = "PlacementPlacement";
            StatString.affinity = "PlacementPlacement";
        }


    }

    public void DestroyInfo()
    {
        fossilInfoText.SetActive(false);

        StatString.fossilName = null;
        StatString.durability = null;
        StatString.fossilPart = null;
        StatString.flavorText = null;
        StatString.affinity = null;
    }
}
