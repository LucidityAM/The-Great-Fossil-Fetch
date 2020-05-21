using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class FossilAttacks : MonoBehaviour
{
    public BattleSystemFossil BattleSystemFossil;

    public int enemyAmount;

    private bool isDead;

    void Start()
    {
        BattleSystemFossil = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystemFossil>();
    }
    
    public void MeteorStrike()
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        StartCoroutine("KillTimer", 10);
    }

    public void BlazingInferno()
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        StartCoroutine("BurnTimer", 5);
    }

    public void PurifyArena()
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;
        
        StartCoroutine("PurifyTimer", 10);
    }

    public void AncientRelic()
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.playerUnit.currentHP += 100;
        BattleSystemFossil.playerHUD.SetHP(BattleSystemFossil.playerUnit.currentHP);

        BattleSystemFossil.EnemyTurn();
    }



    public IEnumerator KillTimer(int timer)
    {
        while (timer > 0)
        {
            timer--;
            Debug.Log(timer);
            yield return new WaitForSeconds(1.0f);
        } //A timer that starts at 10 and counts down every second and displays the number of seconds left.

        yield return new WaitForSeconds(1.0f);

        BattleSystemFossil.state = BattleStateFossil.WON; //Sets the battle state to a player win.

        BattleSystemFossil.EndBattle(); //Forcibly ends the battle.

        StopCoroutine("KillTimer");
    }

    public IEnumerator BurnTimer(int timer)
    {
        BattleSystemFossil.enemyTurnAttack = true;

        enemyAmount = EnemyHolder.enemyAmount;
        while (timer > 0)
        {
            timer--;

            for (int i = 0; i <= enemyAmount; i++)
            {
                if(BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(4); //Deals damage to every enemy

                    BattleSystemFossil.currentEnemies[i].GetComponent<Image>().color = new Color(1, 0, 0); //Sets color to red for enemy
                }

                yield return new WaitForSeconds(.2f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.currentEnemies[i].GetComponent<Image>().color = new Color(1, 1, 1); //Sets enemy color to normal

                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP); //Updates the battle hud for the enemy

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    } //Checks if the enemy is dead and if so, destroys it
                }
            }
            yield return new WaitForSeconds(1.0f);
        }


        if (BattleSystemFossil.enemiesKilled >= enemyAmount + 1)
        {
            BattleSystemFossil.state = BattleStateFossil.WON;
            BattleSystemFossil.EndBattle();
        }
        else
        {
            BattleSystemFossil.enemyTurnAttack = true;
            BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;
            BattleSystemFossil.EnemyTurn();
        } //If all enemies are not killed, enemy turn starts


        StopCoroutine("BurnTimer");
    }

    public IEnumerator PurifyTimer(int timer)
    {
        while (timer > 0)
        {
            timer--;
            Debug.Log(timer);
            yield return new WaitForSeconds(1.0f);
        } //A timer that starts at 10 and counts down every second and displays the number of seconds left.

        Debug.Log("All enemy affinities have been restored");
        StopCoroutine("PurifyTimer");
    } //Currently non-functional due to unimplemented enemy affinites.
}
