using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Numerics;
using System.Runtime.Serialization;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1 : MonoBehaviour
{
    public BattleSystemFossil battleSystemFossil;
    public UnitStats playerStats;

    public bool isDead;
    public bool isCharging;

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

    public IEnumerator EnemyTurn1()
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
                isDead = playerStats.TakeDamage(GameObject.FindGameObjectWithTag("Enemy1").GetComponent<UnitStats>().damage / PlayerStats.defendButton);

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
            else if (EnemyHolder.isDowned == false && thisEnemy.GetComponent<UnitStats>().currentHP < thisEnemy.GetComponent<UnitStats>().maxHP / 2)
            {

                if (isCharging == true)
                {
                    isDead = playerStats.TakeDamage((GameObject.FindGameObjectWithTag("Enemy1").GetComponent<UnitStats>().damage * 2) / PlayerStats.defendButton);

                    battleSystemFossil.playerColor.color = new Color(1, 0, 0); //Sets the player color to red

                    battleSystemFossil.CreatePlayerParticles(); //Generates feedback particles that shooot out of player

                    cameraShake.shake = battleSystemFossil.playerPrefab;
                    EnemyHolder.shakeEnemy = true;
                    //Shakes the player for more feedback

                    battleSystemFossil.playerHUD.SetHP(battleSystemFossil.playerUnit.currentHP); //Sets the HP of the player in the HUD

                    yield return new WaitForSeconds(.15f);

                    battleSystemFossil.playerColor.color = new Color(1, 1, 1);
                    EnemyHolder.shakeEnemy = false;
                    //Turns color and shaking back to normal

                    yield return new WaitForSeconds(.15f);

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
                else if (isCharging == false)
                {

                    infoBar.GetComponent<Animator>().SetBool("isOpen", true);

                    infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "The enemy is charging up an attack";

                    yield return new WaitForSeconds(.55f);

                    for (int j = 0; j <= EnemyHolder.enemyAmount; j++)
                    {
                        if (battleSystemFossil.enemyLightingEffects[j] != null)
                        {
                            battleSystemFossil.enemyLightingEffects[j].SetActive(false);
                            battleSystemFossil.currentEnemies[j].GetComponent<Image>().enabled = true;
                        }
                    }

                    infoBar.GetComponent<Animator>().SetBool("isOpen", false);

                    yield return new WaitForSeconds(.2f);

                    infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Select an enemy";

                    isCharging = true;

                }//If it is the first time the enemy is attacking, it will say that the enemy is charging an attack
            }
           

        }//Special attack that only occurs when the enemy has less than half health, attacks the player 5 times in quick succession
        
        if (EnemyHolder.isDowned == true)
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

        EnemyHolder.coroutinesRunning--;

        if (isDead)
        {
            battleSystemFossil.state = BattleStateFossil.LOST;
            battleSystemFossil.EndBattle();
        }
    } //Basic enemy turn that will look at which enemy the player is fighting, and start seperate scripts depending on the enemy.

}
