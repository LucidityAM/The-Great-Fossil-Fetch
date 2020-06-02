using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDurability : MonoBehaviour
{
    public int[] fossilDurabilitys = new int[18];

    public Text fossilDurabilitySkull;
    public Text fossilDurabilityNeck;
    public Text fossilDurabilityRibs;
    public Text fossilDurabilityArms;
    public Text fossilDurabilityLegs;
    public Text fossilDurabilityTail;

    public void Start()
    {
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

    void Update()
    {
        for (int i = 0; i < WeaponStats.fossilsOutOfSpaces.Length; i++)
        {
            if (gameObject.tag.Contains("skull"))
            {
                fossilDurabilitySkull.text = WeaponStats.fossilDurability[i] + "/" + fossilDurabilitys[i];

                //Sets the durability text of the fossil in the inventory
            }
        }
    }
}
