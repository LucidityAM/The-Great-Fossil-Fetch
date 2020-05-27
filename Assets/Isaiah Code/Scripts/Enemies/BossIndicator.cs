using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIndicator : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss1"))
        {
            EnemyHolder.bossNumber = 1;
        }
        else if (collision.gameObject.CompareTag("Boss2"))
        {
            EnemyHolder.bossNumber = 2;
        }
        else if (collision.gameObject.CompareTag("Boss3"))
        {
            EnemyHolder.bossNumber = 3;
        }
    }
}
