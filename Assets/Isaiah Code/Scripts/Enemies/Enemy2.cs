using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Numerics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    public BattleSystemFossil battleSystemFossil;
    public UnitStats playerStats;

    public bool isDead;

    public CameraShake cameraShake;

    public GameObject thisEnemy;

    public GameObject infoBar;

    // Start is called before the first frame update
    void Start()
    {
        battleSystemFossil = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystemFossil>();
        playerStats = GameObject.Find("Player (1)").GetComponent<UnitStats>();
        cameraShake = this.gameObject.GetComponent<CameraShake>();

    }// Grabs the BattleSystem script and assigns it to the empty variable battleSystemFossil, also sets enemy ID

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(EnemyHolder.coroutinesRunning);
    }

    public IEnumerator EnemyTurn2()
    {
        switch (EnemyHolder.coroutinesRunning)
        {
            case 0:
                if (battleSystemFossil.enemyLightingEffects[0] != null)
                {

                    battleSystemFossil.enemyLightingEffects[0].SetActive(true);
                    battleSystemFossil.currentEnemies[0].GetComponent<Image>().enabled = false;

                    thisEnemy = battleSystemFossil.currentEnemies[0];

                    if (EnemyHolder.enemyDowned[0] != null && EnemyHolder.enemyDowned[0].GetComponent<UnitStats>().isDowned == true)
                    {
                        battleSystemFossil.enemyLightingEffects[0].SetActive(false);
                        battleSystemFossil.currentEnemies[0].GetComponent<Image>().enabled = true;
                    }
                }
                if (EnemyHolder.enemyDowned[0] != null)
                {
                    if (EnemyHolder.enemyDowned[0].GetComponent<UnitStats>().isDowned == true)
                    {
                        EnemyHolder.isDowned = true;
                    }
                }
                break;
            case 1:
                yield return new WaitForSeconds(1f);
                if (battleSystemFossil.enemyLightingEffects[1] != null)
                {
                    battleSystemFossil.enemyLightingEffects[1].SetActive(true);
                    battleSystemFossil.currentEnemies[1].GetComponent<Image>().enabled = false;

                    thisEnemy = battleSystemFossil.currentEnemies[1];

                    if (EnemyHolder.enemyDowned[1] != null && EnemyHolder.enemyDowned[1].GetComponent<UnitStats>().isDowned == true)
                    {
                        battleSystemFossil.enemyLightingEffects[1].SetActive(false);
                        battleSystemFossil.currentEnemies[1].GetComponent<Image>().enabled = true;
                    }
                }
                if (EnemyHolder.enemyDowned[1] != null)
                {
                    if (EnemyHolder.enemyDowned[1].GetComponent<UnitStats>().isDowned == true)
                    {
                        EnemyHolder.isDowned = true;
                    }
                }
                break;
            case 2:
                yield return new WaitForSeconds(2f);
                if (battleSystemFossil.enemyLightingEffects[2] != null)
                {
                    battleSystemFossil.enemyLightingEffects[2].SetActive(true);
                    battleSystemFossil.currentEnemies[2].GetComponent<Image>().enabled = false;

                    thisEnemy = battleSystemFossil.currentEnemies[2];

                    if (EnemyHolder.enemyDowned[2] != null && EnemyHolder.enemyDowned[2].GetComponent<UnitStats>().isDowned == true)
                    {
                        battleSystemFossil.enemyLightingEffects[2].SetActive(false);
                        battleSystemFossil.currentEnemies[2].GetComponent<Image>().enabled = true;
                    }
                }
                if (EnemyHolder.enemyDowned[2] != null)
                {
                    if (EnemyHolder.enemyDowned[2].GetComponent<UnitStats>().isDowned == true)
                    {
                        EnemyHolder.isDowned = true;
                    }
                }
                break;
            case 3:
                yield return new WaitForSeconds(3f);
                if (battleSystemFossil.enemyLightingEffects[3] != null)
                {
                    battleSystemFossil.enemyLightingEffects[3].SetActive(true);
                    battleSystemFossil.currentEnemies[3].GetComponent<Image>().enabled = false;

                    thisEnemy = battleSystemFossil.currentEnemies[3];

                    if (EnemyHolder.enemyDowned[3] != null && EnemyHolder.enemyDowned[3].GetComponent<UnitStats>().isDowned == true)
                    {
                        battleSystemFossil.enemyLightingEffects[3].SetActive(false);
                        battleSystemFossil.currentEnemies[3].GetComponent<Image>().enabled = true;
                    }
                }
                if (EnemyHolder.enemyDowned[3] != null)
                {
                    if (EnemyHolder.enemyDowned[3].GetComponent<UnitStats>().isDowned == true)
                    {
                        EnemyHolder.isDowned = true;
                    }
                }
                break;
        }// Delays the coroutines activation depending on how many enemies you are fighting and disables specific lighting effects depending on downed enemies

        if (thisEnemy != null)
        {
            if (EnemyHolder.isDowned == false && thisEnemy.GetComponent<UnitStats>().currentHP > thisEnemy.GetComponent<UnitStats>().maxHP / 2)
            {
                isDead = playerStats.TakeDamage(10 / PlayerStats.defendButton);

                battleSystemFossil.playerColor.color = new Color(1, 0, 0); //Sets the player color to red

                battleSystemFossil.CreatePlayerParticles(); //Generates feedback particles that shooot out of player

                cameraShake.shake = battleSystemFossil.playerPrefab;
                EnemyHolder.shakeEnemy = true;
                //Shakes the player for more feedback

                battleSystemFossil.playerHUD.SetHP(battleSystemFossil.playerUnit.currentHP); //Sets the HP of the player in the HUD

                yield return new WaitForSeconds(.2f);

                battleSystemFossil.playerColor.color = new Color(1, 1, 1);
                EnemyHolder.shakeEnemy = false;
                //Turns color and shaking back to normal

                yield return new WaitForSeconds(.2f);

                for (int j = 0; j <= EnemyHolder.enemyAmount; j++)
                {
                    if (battleSystemFossil.enemyLightingEffects[j] != null)
                    {
                        battleSystemFossil.enemyLightingEffects[j].SetActive(false);
                        battleSystemFossil.currentEnemies[j].GetComponent<Image>().enabled = true;
                    }
                }
                //Depending on how many enemies you are fighting, turns off respecitve lights

                yield return new WaitForSeconds(.55f);

            }
            else if (EnemyHolder.isDowned == false)
            {

                if (thisEnemy.GetComponent<UnitStats>().currentHP <= 25)
                {
                    thisEnemy.GetComponent<UnitStats>().currentHP = 26;
                }

                isDead = playerStats.TakeDamage(25 / PlayerStats.defendButton);
                thisEnemy.GetComponent<UnitStats>().TakeDamage(25);


                battleSystemFossil.playerColor.color = new Color(1, 0, 0); //Sets the player color to red
                thisEnemy.GetComponent<Image>().color = new Color(1, 0, 0); //Sets the enemy to red too

                battleSystemFossil.CreatePlayerParticles(); //Generates feedback particles that shooot out of player
                thisEnemy.transform.GetChild(3).gameObject.GetComponent<ParticleSystem>().Play(); //Generates feedback particles that shooot out of the enemy

                cameraShake.shake = battleSystemFossil.playerPrefab;
                EnemyHolder.shakeEnemy = true;
                //Shakes the player for more feedback

                battleSystemFossil.playerHUD.SetHP(battleSystemFossil.playerUnit.currentHP); //Sets the HP of the player in the HUD
                for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
                {
                    battleSystemFossil.enemyHUDs[i].SetHP(battleSystemFossil.enemyUnit[i].currentHP);
                }//Sets the enemy hp

                infoBar.GetComponent<Animator>().SetBool("isOpen", true);

                infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "The enemy hurt itself with its attack";

                yield return new WaitForSeconds(.7f);

                battleSystemFossil.playerColor.color = new Color(1, 1, 1);
                thisEnemy.GetComponent<Image>().color = new Color(1, 1, 1); //Sets the enemy color to normal
                EnemyHolder.shakeEnemy = false;
                //Turns color and shaking back to normal

                yield return new WaitForSeconds(.7f);

                infoBar.GetComponent<Animator>().SetBool("isOpen", false);

                infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Select an enemy";

                for (int j = 0; j <= EnemyHolder.enemyAmount; j++)
                {
                    if (battleSystemFossil.enemyLightingEffects[j] != null)
                    {
                        battleSystemFossil.enemyLightingEffects[j].SetActive(false);
                        battleSystemFossil.currentEnemies[j].GetComponent<Image>().enabled = true;
                    }
                }
                //Depending on how many enemies you are fighting, turns off respecitve lights
            }
            else if (EnemyHolder.isDowned == true)
            {
                yield return new WaitForSeconds(.95f);

                EnemyHolder.isDowned = false;

                for (int j = 0; j <= EnemyHolder.enemyAmount; j++)
                {
                    if (battleSystemFossil.enemyLightingEffects[j] != null)
                    {
                        battleSystemFossil.enemyLightingEffects[j].SetActive(false);
                        battleSystemFossil.currentEnemies[j].GetComponent<Image>().enabled = true;
                    }
                }
            }
        }
        
        EnemyHolder.coroutinesRunning--;

        if (isDead)
        {
            battleSystemFossil.state = BattleStateFossil.LOST;
            battleSystemFossil.EndBattle();
        }
    } //Basic enemy turn that will look at which enemy the player is fighting, and start seperate scripts depending on the enemy.

}
