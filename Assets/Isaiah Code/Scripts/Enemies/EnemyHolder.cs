using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyHolder
{
    public static int enemyID;

    public static int enemyAmount;

    public static int coroutinesRunning;

    public static bool InitialStartup;

    public static GameObject[] enemyDowned = new GameObject[4];

    public static bool isDowned;

    public static bool shakeEnemy;

    public static int bossNumber;

    public static int battleNumber;
    public static int turnCount;

}
