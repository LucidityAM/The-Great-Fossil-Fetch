using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class UnitStats : MonoBehaviour 
{
    public string unitName;

	public float maxHP;
    public float currentHP;

    public float damage;

    public int affinity;

    public bool isDowned;
    public bool TakeDamage(float dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }
}

