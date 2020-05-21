using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponinInventory : MonoBehaviour
{
    public Image skull;
    public Image neck;
    public Image ribs;
    public Image arms;
    public Image legs;
    public Image tail;

    public void Awake()
    {
        if (this.gameObject.tag.Contains("skull"))
        {
            skull = gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.tag.Contains("neck"))
        {
            neck = gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.tag.Contains("ribs"))
        {
            ribs = gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.tag.Contains("arms"))
        {
            arms = gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.tag.Contains("legs"))
        {
            legs = gameObject.GetComponent<Image>();
        }
        else if (this.gameObject.tag.Contains("tail"))
        {
            tail = gameObject.GetComponent<Image>();
        }

    }
    public void Update()
    {
        if (gameObject.tag == ("skull" + WeaponStats.skull))
        {
            skull.enabled = true;
        }
        else if (gameObject.tag == ("neck" + WeaponStats.skull))
        {
            neck.enabled = true;
        }
        else if (gameObject.tag == ("ribs" + WeaponStats.skull))
        {
            ribs.enabled = true;
        }
        else if (gameObject.tag == ("arms" + WeaponStats.skull))
        {
            arms.enabled = true;
        }
        else if (gameObject.tag == ("legs" + WeaponStats.skull))
        {
            legs.enabled = true;
        }
        else if (gameObject.tag == ("tail" + WeaponStats.skull))
        {
            tail.enabled = true;
        }

    }
}
