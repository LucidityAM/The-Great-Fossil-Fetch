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
        if (WeaponStats.skull == 1) { fossilDurabilitySkull.text = WeaponStats.fossilDurability[0] + "/" + fossilDurabilitys[0]; }

        if (WeaponStats.skull == 2) { fossilDurabilitySkull.text = WeaponStats.fossilDurability[1] + "/" + fossilDurabilitys[1]; }

        if (WeaponStats.skull == 3) { fossilDurabilitySkull.text = WeaponStats.fossilDurability[2] + "/" + fossilDurabilitys[2]; }

        if (WeaponStats.neck == 1) { fossilDurabilityNeck.text = WeaponStats.fossilDurability[3] + "/" + fossilDurabilitys[3]; }

        if (WeaponStats.neck == 2) { fossilDurabilityNeck.text = WeaponStats.fossilDurability[4] + "/" + fossilDurabilitys[4]; }

        if (WeaponStats.neck == 3) { fossilDurabilityNeck.text = WeaponStats.fossilDurability[5] + "/" + fossilDurabilitys[5]; }

        if (WeaponStats.ribs == 1) { fossilDurabilityRibs.text = WeaponStats.fossilDurability[6] + "/" + fossilDurabilitys[6]; }

        if (WeaponStats.ribs == 2) { fossilDurabilityRibs.text = WeaponStats.fossilDurability[7] + "/" + fossilDurabilitys[7]; }

        if (WeaponStats.ribs == 3) { fossilDurabilityRibs.text = WeaponStats.fossilDurability[8] + "/" + fossilDurabilitys[8]; }

        if (WeaponStats.arms == 1) { fossilDurabilityArms.text = WeaponStats.fossilDurability[9] + "/" + fossilDurabilitys[9]; }

        if (WeaponStats.arms == 2) { fossilDurabilityArms.text = WeaponStats.fossilDurability[10] + "/" + fossilDurabilitys[10]; }

        if (WeaponStats.arms == 3) { fossilDurabilityArms.text = WeaponStats.fossilDurability[11] + "/" + fossilDurabilitys[11]; }

        if (WeaponStats.legs == 1) { fossilDurabilityLegs.text = WeaponStats.fossilDurability[12] + "/" + fossilDurabilitys[12]; }

        if (WeaponStats.legs == 2) { fossilDurabilityLegs.text = WeaponStats.fossilDurability[13] + "/" + fossilDurabilitys[13]; }

        if (WeaponStats.legs == 3) { fossilDurabilityLegs.text = WeaponStats.fossilDurability[14] + "/" + fossilDurabilitys[14]; }

        if (WeaponStats.tail == 1) { fossilDurabilityTail.text = WeaponStats.fossilDurability[15] + "/" + fossilDurabilitys[15]; }

        if (WeaponStats.tail == 2) { fossilDurabilityTail.text = WeaponStats.fossilDurability[16] + "/" + fossilDurabilitys[16]; }

        if (WeaponStats.tail == 3) { fossilDurabilityTail.text = WeaponStats.fossilDurability[17] + "/" + fossilDurabilitys[17]; }
    }
}
