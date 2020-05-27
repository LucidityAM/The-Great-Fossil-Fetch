﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class FossilAttacks : MonoBehaviour
{
    public BattleSystemFossil BattleSystemFossil;

    public int enemyAmount;
    private int chosenAffinity;
    private int chosenAttack;

    private bool purifyUsed = false;
    private bool skullUsed = false;
    private bool healUsed = false;

    void Start()
    {
        BattleSystemFossil = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystemFossil>();
    }
    
    public void MeteorStrike() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        StartCoroutine("KillTimer", 10);
    } //An attack that drops a metor on the battlefield after a specified number of turns. (NOTE: Turn counting has not been implemented yet. Sticking to counting seconds until implemented.)

    public void LowKick() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        if (enemyAmount == 0)
        {
            BattleSystemFossil.enemyUnit[0].TakeDamage(32);
        }
        else
        {
            for (int i = 0; i <= enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (i == 2)
                    {
                        return;
                    }
                    BattleSystemFossil.enemyUnit[i].TakeDamage(20);
                }
            }
        }
    } //An attack that deals decent damage to the front two enemies in a battle.

    public void TailStab() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        for (int i = 0; i <= enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                BattleSystemFossil.enemyUnit[i].TakeDamage(15);
            }
        }
    } //An attack that hits all enemies for even damage.

    public void BlazingInferno() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        StartCoroutine("BurnTimer", 5);
    } //An attack that burns all enemies in battle for a specified number of passovers. Uses KillTimer.

    public void PhantomTalons() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        if (enemyAmount == 0)
        {
            BattleSystemFossil.enemyUnit[0].TakeDamage(32);
        }
        else
        {
            for (int i = 0; i <= enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null && i == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(32);
                    return;
                }
            }
        }
    } //An attack that deals massive damage to the frontmost enemy.

    public void CleansingVapors() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        for (int i = 0; i <= enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                BattleSystemFossil.enemyUnit[i].TakeDamage(15);
                if (BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(5);
                    BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().affinity = 0;
                }
            }
        }
    } //An attack that deals decent damage to all enemies in battle, deals extra damage to enemies of the "Cursed" affinity, then switches any "Cursed" affinity to "Blessed".

    public void AlbinoSkull() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;
        if (skullUsed == false)
        {
            for (int i = 0; i <= enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(5);
                    if (BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().damage = BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().damage / 2;
                    }
                }
            }
            skullUsed = true;
            BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;
        }
        else
        {
            Debug.Log("Enemy attack power cannot be lowered anymore. You cannot use this fossil.");
        }
    } //An attack that deals low damage to all enemies in battle and halves the damage output of all enemies of the "Cursed" affinity.

    public void PurifyArena() //Affinity: Support
    {
        if (purifyUsed == false)
        {
            if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
                return;

            BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

            ChooseAffinity();
            for (int i = 0; i <= enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().affinity = chosenAffinity;
                    Debug.Log(BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().affinity); //DEBUG: Displays new affinities inside console
                }
            }
            purifyUsed = true;
        }
        else
        {
            Debug.Log("You have already purified this arena. You may not do so again."); //DEBUG: Displays a message that explains that Purify Arena cannot be used
        }
    } //A special skill that runs an RNG (froms 0-2) then switches all enemy affinities to the number picked. Disables after one use.

    public void AncientRelic() //Affinity: Support
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        if (healUsed == false)
        {
            BattleSystemFossil.playerUnit.currentHP += 100;
            BattleSystemFossil.playerHUD.SetHP(BattleSystemFossil.playerUnit.currentHP);
            healUsed = true;
        }
        else
        {
            Debug.Log("You can only heal to full health once per battle.");
        }
    } //A special skill that heals the player for full health. Disables after one use.

    public void VampiricFang() //Affinity: Support
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        for (int i = 0; i <= enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null && i == 0)
            {
                BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().TakeDamage(BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().currentHP / 2);
                BattleSystemFossil.playerUnit.currentHP += BattleSystemFossil.enemyUnit[i].GetComponent<UnitStats>().currentHP;
                BattleSystemFossil.playerHUD.SetHP(BattleSystemFossil.playerUnit.currentHP);
                return;
            }
        }
    } //An attack that steals half of the frontmost enemy's health and gives it to the player. The amount of health gained will diminish due to the nature of the attack, preventing attack spam.

    public void SecretPower() //Affinity: Variable
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        ChooseAttack();
        if (chosenAttack == 0)
        {
            MeteorStrike();
            Debug.Log("Chosen Attack: Metor Strike");
        }
        else if (chosenAttack == 1)
        {
            LowKick();
            Debug.Log("Chosen Attack: Low Kick");
        }
        else if (chosenAttack == 2)
        {
            BlazingInferno();
            Debug.Log("Chosen Attack: Blazing Inferno");
        }
        else if (chosenAttack == 3)
        {
            PhantomTalons();
            Debug.Log("Chosen Attack: Phantom Talons");
        }
        else if (chosenAttack == 4)
        {
            CleansingVapors();
            Debug.Log("Chosen Attack: Cleansing Vapors");
        }
        else if (chosenAttack == 5)
        {
            AlbinoSkull();
            Debug.Log("Chosen Attack: Albino Skull");
        }
        else if (chosenAttack == 6)
        {
            PurifyArena();
            Debug.Log("Chosen Attack: Purify Arena");
        }
        else if (chosenAttack == 7)
        {
            AncientRelic();
            Debug.Log("Chosen Attack: Ancient Relic");
        }
        else if (chosenAttack == 8)
        {
            TailStab();
            Debug.Log("Chosen Attack: Tail Stab");
        }
        else if (chosenAttack == 9)
        {
            VampiricFang();
            Debug.Log("Chosen Attack: Vampiric Fang");
        }
    } //An attack that uses an RNG to select a random attack or skill from the FossilAttacks script to use. If this code can be simplified and not look like shit, please tell me how :3
      //Debug text will be removed in final build.

    public IEnumerator KillTimer(int timer)
    {
        while (timer > 0)
        {
            timer--;
            Debug.Log(timer);
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i <= enemyAmount; i++)
        {
            BattleSystemFossil.enemyUnit[i].TakeDamage(45);
        }

        StopCoroutine("KillTimer");
    } //The kill timer for MetorStrike.

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
                    BattleSystemFossil.enemyUnit[i].TakeDamage(4);

                    BattleSystemFossil.currentEnemies[i].GetComponent<Image>().color = new Color(1, 0, 0);
                }

                yield return new WaitForSeconds(.2f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.currentEnemies[i].GetComponent<Image>().color = new Color(1, 1, 1);

                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
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
        }

        StopCoroutine("BurnTimer");
    } //The burn timer for BlazingInferno.

    public void ChooseAffinity()
    {
        chosenAffinity = Random.Range(0, 3);
    } //The RNG that PurifyArena uses to select an affinity.

    public void ChooseAttack()
    {
        chosenAttack = Random.Range(0, 10);
    } //The RNG that SecretPower uses to select an attack or skill.
}
