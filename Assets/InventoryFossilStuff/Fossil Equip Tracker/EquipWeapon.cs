using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipWeapon : MonoBehaviour
{
    public GameObject[] Weapon = new GameObject[1];

    public void Equip()
    {
        for (int i = 0; i < 3; i++)
        {
            if (gameObject.tag == "skull" + (i + 1))
            {
                WeaponStats.skull = i + 1;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (gameObject.tag == "neck" + (i + 1))
            {
                WeaponStats.neck = i + 1;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (gameObject.tag == "ribs" + (i + 1))
            {
                WeaponStats.ribs = i + 1;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (gameObject.tag == "arms" + (i + 1))
            {
                WeaponStats.arms = i + 1;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (gameObject.tag == "legs" + (i + 1))
            {
                WeaponStats.legs = i + 1;
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (gameObject.tag == "tail" + (i + 1))
            {
                WeaponStats.tail = i + 1;
            }
        }

    }//Checks the specific tag of the fossil that is clicked on and sets the int corresponding with that fossil type to whichever fossil needs to be equipped
}
