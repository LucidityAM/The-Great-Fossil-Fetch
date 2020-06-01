using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecker : MonoBehaviour
{
    void Start()
    {
        WeaponStats.skull = 0;
        WeaponStats.neck = 0;
        WeaponStats.ribs = 0;
        WeaponStats.arms = 0;
        WeaponStats.legs = 0;
        WeaponStats.tail = 0;

        for (int j = 0; j <= WeaponStats.fossilsInSpaces.Length; j++)
        {
            WeaponStats.fossilsInSpaces[j] = 0;
        }
        for (int k = 0; k <= WeaponStats.objectsInSpaces.Length; k++)
        {
            WeaponStats.objectsInSpaces[k] = null;
        }
        for (int k = 0; k <= WeaponStats.fossilsOutOfSpaces.Length; k++)
        {
            WeaponStats.fossilsOutOfSpaces[k] = null;
        }
        for (int k = 0; k <= EnemyHolder.enemyDowned.Length; k++)
        {
            EnemyHolder.enemyDowned[k] = null;
        }

        WeaponStats.isSet = false;

        PlayerStats.attack = 1;
        PlayerStats.defendButton = 1;
        PlayerStats.defense = 1;

    }
}
