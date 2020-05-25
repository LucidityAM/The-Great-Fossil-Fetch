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

    public Sprite cursed;
    public Sprite blessed;
    public Sprite soma;
   
    // Update is called once per frame
    void Update()
    {
        if(WeaponStats.skull != 0)
        {
            Text name = skull.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = skull.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = skull.transform.GetChild(3).gameObject.GetComponent<Text>();

            skull.SetActive(true);

            switch (WeaponStats.skull)
            {
                case 1:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            skull.SetActive(false);
        }

        if (WeaponStats.neck != 0)
        {

            Text name = neck.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = neck.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = neck.transform.GetChild(3).gameObject.GetComponent<Text>();

            neck.SetActive(true);

            switch (WeaponStats.neck)
            {
                case 1:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            neck.SetActive(false);
        }

        if (WeaponStats.ribs != 0)
        {

            Text name = ribs.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = ribs.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = ribs.transform.GetChild(3).gameObject.GetComponent<Text>();

            ribs.SetActive(true);

            switch (WeaponStats.ribs)
            {
                case 1:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            ribs.SetActive(false);
        }

        if (WeaponStats.arms != 0)
        {

            Text name = arms.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = arms.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = arms.transform.GetChild(3).gameObject.GetComponent<Text>();

            arms.SetActive(true);

            switch (WeaponStats.arms)
            {
                case 1:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            arms.SetActive(false);
        }

        if (WeaponStats.legs != 0)
        {

            Text name = legs.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = legs.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = legs.transform.GetChild(3).gameObject.GetComponent<Text>();

            legs.SetActive(true);

            switch (WeaponStats.legs)
            {
                case 1:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            legs.SetActive(false);
        }

        if (WeaponStats.tail != 0)
        {

            Text name = tail.transform.GetChild(1).gameObject.GetComponent<Text>();
            Image affinity = tail.transform.GetChild(2).gameObject.GetComponent<Image>();
            Text durability = tail.transform.GetChild(3).gameObject.GetComponent<Text>();

            tail.SetActive(true);

            switch (WeaponStats.tail)
            {
                case 1:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 2:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;
                case 3:
                    name.text = "Placement Placement";
                    affinity.sprite = blessed;
                    durability.text = "XX/XX";
                    break;

            }//Sets the text of the specific fossil attack
        }
        else
        {
            tail.SetActive(false);
        }


    }
}
