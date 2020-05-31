using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBattleFossils : MonoBehaviour
{
    public GameObject skull;
    public GameObject neck;
    public GameObject ribs;
    public GameObject arms;
    public GameObject legs;
    public GameObject tail;

    public Text skullNone;
    public Text neckNone;
    public Text ribsNone;
    public Text armsNone;
    public Text legsNone;
    public Text tailNone;

    public Sprite cursed;
    public Sprite blessed;
    public Sprite soma;

    public FossilAttacks fossilAttacks;
   
    // Update is called once per frame
    void Update()
    {
        fossilAttacks = GameObject.FindGameObjectWithTag("Player").GetComponent<FossilAttacks>();

        if(WeaponStats.skull != 0)
        {
            skullNone.enabled = false;

            Text name = skull.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = skull.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = skull.transform.GetChild(3).gameObject.GetComponent<Text>();

            //Grabs the name, affinity, and durability of the fossil in the battle so it can be edited later

            Button btn = skull.GetComponent<Button>(); //Gets the button component from the battle fossil

            skull.SetActive(true); //Sets the specific fossil type to active

            switch (WeaponStats.skull)
            {
                case 1:
                    name.text = "Pitch Black Darkness";
                    affinity.sprite = cursed;
                    durability.text = WeaponStats.fossilDurability[0] + "/15";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("PitchBlackDarkness"); });
                    if(WeaponStats.fossilDurability[0] <= 0)
                    {
                        WeaponStats.skull = 0;
                        return;
                    }
                    break;
                case 2:
                    name.text = "Meteor Strike";
                    affinity.sprite = soma;
                    durability.text = WeaponStats.fossilDurability[1] + "/3";
                    btn.onClick.AddListener(delegate { fossilAttacks.MeteorStrike(); });
                    if (WeaponStats.fossilDurability[1] <= 0)
                    {
                        WeaponStats.skull = 0;
                        return;
                    }
                    break;
                case 3:
                    name.text = "Albino Skull";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[2] + "/10";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("AlbinoSkull"); });
                    if (WeaponStats.fossilDurability[2] <= 0)
                    {
                        WeaponStats.skull = 0;
                        return;
                    }
                    break;

            }//Sets the text of the specific fossil attack as well as the affinity, durability, and adds the specific fossil attack method to the onclick method of the button
        }
        else
        {
            skullNone.enabled = true;
            skull.SetActive(false);

        }//If the WeaponStats part is equal to 0, makes text that says "none" appear, turns the fossil type off

        if (WeaponStats.neck != 0)
        {
            neckNone.enabled = false;

            Text name = neck.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = neck.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = neck.transform.GetChild(3).gameObject.GetComponent<Text>();

            Button btn = neck.GetComponent<Button>();

            neck.SetActive(true);

            switch (WeaponStats.neck)
            {
                case 1:
                    name.text = "Dark Pulse";
                    affinity.sprite = cursed;
                    durability.text = WeaponStats.fossilDurability[3] + "/7";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("DarkPulse"); });
                    if (WeaponStats.fossilDurability[3] <= 0)
                    {
                        WeaponStats.neck = 0;
                        return;
                    }
                    break;
                case 2:
                    name.text = "Vitality Swap";
                    affinity.sprite = soma;
                    durability.text = WeaponStats.fossilDurability[4] + "/5";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("VitalitySwap"); });
                    if (WeaponStats.fossilDurability[4] <= 0)
                    {
                        WeaponStats.neck = 0;
                        return;
                    }
                    break;
                case 3:
                    name.text = "Ephemeral Essence";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[5] + "/3";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("EphemeralEssence"); });
                    if (WeaponStats.fossilDurability[5] <= 0)
                    {
                        WeaponStats.neck = 0;
                        return;
                    }
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            neck.SetActive(false);
            neckNone.enabled = true;
        }

        if (WeaponStats.ribs != 0)
        {
            ribsNone.enabled = false;

            Text name = ribs.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = ribs.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = ribs.transform.GetChild(3).gameObject.GetComponent<Text>();

            Button btn = ribs.GetComponent<Button>();

            ribs.SetActive(true);

            switch (WeaponStats.ribs)
            {
                case 1:
                    name.text = "Blazing Inferno";
                    affinity.sprite = cursed;
                    durability.text = WeaponStats.fossilDurability[6] + "/20";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    if (WeaponStats.fossilDurability[6] <= 0)
                    {
                        WeaponStats.ribs = 0;
                        return;
                    }
                    break;
                case 2:
                    name.text = "Purify Arena";
                    affinity.sprite = soma;
                    durability.text = WeaponStats.fossilDurability[7] + "/7";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("PurifyArena"); });
                    if (WeaponStats.fossilDurability[7] <= 0)
                    {
                        WeaponStats.ribs = 0;
                        return;
                    }
                    break;
                case 3:
                    name.text = "Cleansing Vapors";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[8] + "/12";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("CleansingVapors"); });
                    if (WeaponStats.fossilDurability[8] <= 0)
                    {
                        WeaponStats.ribs = 0;
                        return;
                    }
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            ribsNone.enabled = true;
            ribs.SetActive(false);
        }

        if (WeaponStats.arms != 0)
        {
            armsNone.enabled = false;

            Text name = arms.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = arms.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = arms.transform.GetChild(3).gameObject.GetComponent<Text>();

            Button btn = arms.GetComponent<Button>();

            arms.SetActive(true);

            switch (WeaponStats.arms)
            {
                case 1:
                    name.text = "Phantom Talons";
                    affinity.sprite = cursed;
                    durability.text = WeaponStats.fossilDurability[9] + "/10";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("PhantomTalons"); });
                    if (WeaponStats.fossilDurability[9] <= 0)
                    {
                        WeaponStats.arms = 0;
                        return;
                    }
                    break;
                case 2:
                    name.text = "Reverse Strike";
                    affinity.sprite = soma;
                    durability.text = WeaponStats.fossilDurability[10] + "/10";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("ReverseStrike"); });
                    if (WeaponStats.fossilDurability[10] <= 0)
                    {
                        WeaponStats.arms = 0;
                        return;
                    }
                    break;
                case 3:
                    name.text = "Vampiric Fang";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[11] + "/7";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("VampiricFang"); });
                    if (WeaponStats.fossilDurability[11] <= 0)
                    {
                        WeaponStats.arms = 0;
                        return;
                    }
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            armsNone.enabled = true;
            arms.SetActive(false);
        }

        if (WeaponStats.legs != 0)
        {
            legsNone.enabled = false;

            Text name = legs.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = legs.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = legs.transform.GetChild(3).gameObject.GetComponent<Text>();

            Button btn = legs.GetComponent<Button>();

            legs.SetActive(true);

            switch (WeaponStats.legs)
            {
                case 1:
                    name.text = "All Out Attack";
                    affinity.sprite = cursed;
                    durability.text = WeaponStats.fossilDurability[12] + "/5";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("AllOutAttack"); });
                    if (WeaponStats.fossilDurability[12] <= 0)
                    {
                        WeaponStats.legs = 0;
                        return;
                    }
                    break;
                case 2:
                    name.text = "Low Kick";
                    affinity.sprite = soma;
                    durability.text = WeaponStats.fossilDurability[13] + "/7";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("LowKick"); });
                    if (WeaponStats.fossilDurability[13] <= 0)
                    {
                        WeaponStats.legs = 0;
                        return;
                    }
                    break;
                case 3:
                    name.text = "Ancient Relic";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[14] + "/5";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("AncientRelic"); });
                    if (WeaponStats.fossilDurability[14] <= 0)
                    {
                        WeaponStats.legs = 0;
                        return;
                    }
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            legsNone.enabled = true;
            legs.SetActive(false);
        }

        if (WeaponStats.tail != 0)
        {
            tailNone.enabled = false;

            Text name = tail.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = tail.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = tail.transform.GetChild(3).gameObject.GetComponent<Text>();

            Button btn = tail.GetComponent<Button>();

            tail.SetActive(true);

            switch (WeaponStats.tail)
            {
                case 1:
                    name.text = "Secret Power";
                    affinity.sprite = cursed;
                    durability.text = WeaponStats.fossilDurability[15] + "/20";
                    btn.onClick.AddListener(delegate { fossilAttacks.SecretPower(); });
                    if (WeaponStats.fossilDurability[15] <= 0)
                    {
                        WeaponStats.tail = 0;
                        return;
                    }
                    break;
                case 2:
                    name.text = "Tail Stab";
                    affinity.sprite = soma;
                    durability.text = WeaponStats.fossilDurability[16] + "/15";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("TailStab"); });
                    if (WeaponStats.fossilDurability[16] <= 0)
                    {
                        WeaponStats.tail = 0;
                        return;
                    }
                    break;
                case 3:
                    name.text = "Holy Bone Spear";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[17] + "/15";
                    btn.onClick.AddListener(delegate { fossilAttacks.StartCoroutine("HolyBoneSpear"); });
                    if (WeaponStats.fossilDurability[17] <= 0)
                    {
                        WeaponStats.tail = 0;
                        return;
                    }
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            tailNone.enabled = true;
            tail.SetActive(false);
        }


    }
}
