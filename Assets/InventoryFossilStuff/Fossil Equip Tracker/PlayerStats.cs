using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    #region Base and Max Stats

    public static float attack = 0f;
    public static float defense = 0f;
    

    public static float maxAttack = 50f;
    public static float maxDefense = 50f;

    #endregion BaseandMaxStats

    public static float defendButton = 1; //The defense divisor for when the player pressed the defend button
}
