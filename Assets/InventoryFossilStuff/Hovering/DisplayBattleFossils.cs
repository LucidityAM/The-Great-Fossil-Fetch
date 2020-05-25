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
        if(WeaponStats.skull != 0)
        {
            skullNone.enabled = false;

            Text name = skull.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = skull.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = skull.transform.GetChild(3).gameObject.GetComponent<Text>();

            Button btn = skull.GetComponent<Button>();

            skull.SetActive(true);

            switch (WeaponStats.skull)
            {
                case 1:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[0] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[1] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[2] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            skullNone.enabled = true;
            skull.SetActive(false);
        }

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
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[3] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[4] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[5] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
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
                    durability.text = WeaponStats.fossilDurability[6] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[7] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[8] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
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
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[9] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[10] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[11] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
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
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[12] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[13] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[14] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
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
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[15] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[16] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = WeaponStats.fossilDurability[17] + "/XX";
                    btn.onClick.AddListener(delegate { fossilAttacks.BlazingInferno(); });
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
