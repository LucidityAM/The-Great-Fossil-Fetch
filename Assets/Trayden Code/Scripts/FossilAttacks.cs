using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class FossilAttacks : MonoBehaviour
{
    public BattleSystemFossil BattleSystemFossil;

    private int chosenAffinity;
    private int chosenAttack;
    private int chosenEnemy;

    private bool purifyUsed = false;
    private bool skullUsed = false;
    private bool healUsed = false;

    public GameObject infoBar;

    void Start()
    {
        BattleSystemFossil = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystemFossil>();

    }
    
    public void MeteorStrike() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        WeaponStats.fossilDurability[1]--;

        StartCoroutine("KillTimer", 10);
    } //An attack that drops a metor on the battlefield after a specified number of turns. (NOTE: Turn counting has not been implemented yet. Sticking to counting seconds until implemented.)

    public IEnumerator LowKick() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[13]--;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if(i == 0 || i == 1)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(40);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downed
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(30);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(20);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                }

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.shakeEnemy = true;

                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    }
                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }//Set lighting to active, flash red

                if (BattleSystemFossil.enemyParticles[i] != null)
                {
                    BattleSystemFossil.enemyParticles[i].Play();
                }

                yield return new WaitForSeconds(.3f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    EnemyHolder.shakeEnemy = false;

                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    }

                }//Turn enemy color normal and disable lighting

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
                }
            }
            else
            {
                break;
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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
    } //An attack that deals decent damage to the front two enemies in a battle.

    public IEnumerator TailStab() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[16]--;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(35);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                    {
                        EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                    }
                    //Assigns the enemy to be downed

                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(23);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(10);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.shakeEnemy = true;

                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    }
                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }//Set lighting to active, flash red

                if (BattleSystemFossil.enemyParticles[i] != null)
                {
                    BattleSystemFossil.enemyParticles[i].Play();
                }

                yield return new WaitForSeconds(.3f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    EnemyHolder.shakeEnemy = false;

                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    }

                }//Turn enemy color normal and disable lighting

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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
    } //An attack that hits all enemies for even damage.

    public IEnumerator ReverseStrike() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[9]--;

        if (EnemyHolder.enemyAmount == 3)
        {
            for (int i = 3; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(64);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downed
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(45);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(23);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.shakeEnemy = true;

                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                        }
                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                    }//Set lighting to active, flash red

                    if (BattleSystemFossil.enemyParticles[i] != null)
                    {
                        BattleSystemFossil.enemyParticles[i].Play();
                    }

                    yield return new WaitForSeconds(.3f);

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        EnemyHolder.shakeEnemy = false;

                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                        }

                    }//Turn enemy color normal and disable lighting

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                        {
                            BattleSystemFossil.enemiesKilled++;
                            Destroy(BattleSystemFossil.currentEnemies[i]);
                        }
                    }
                }
            }
        }
        else if (EnemyHolder.enemyAmount == 2)
        {
            for (int i = 2; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(64);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downed
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(45);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(23);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.shakeEnemy = true;

                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                        }
                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                    }//Set lighting to active, flash red

                    if (BattleSystemFossil.enemyParticles[i] != null)
                    {
                        BattleSystemFossil.enemyParticles[i].Play();
                    }

                    yield return new WaitForSeconds(.3f);

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        EnemyHolder.shakeEnemy = false;

                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                        }

                    }//Turn enemy color normal and disable lighting

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                        {
                            BattleSystemFossil.enemiesKilled++;
                            Destroy(BattleSystemFossil.currentEnemies[i]);
                        }
                    }
                }
            }
        }
        else if (EnemyHolder.enemyAmount == 1)
        {
            for (int i = 1; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(64);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downed
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(45);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(23);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.shakeEnemy = true;

                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                        }
                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                    }//Set lighting to active, flash red

                    if (BattleSystemFossil.enemyParticles[i] != null)
                    {
                        BattleSystemFossil.enemyParticles[i].Play();
                    }

                    yield return new WaitForSeconds(.3f);

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        EnemyHolder.shakeEnemy = false;

                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                        }

                    }//Turn enemy color normal and disable lighting

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                        {
                            BattleSystemFossil.enemiesKilled++;
                            Destroy(BattleSystemFossil.currentEnemies[i]);
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(64);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downed
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(45);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(23);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.shakeEnemy = true;

                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                        }
                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                    }//Set lighting to active, flash red

                    if (BattleSystemFossil.enemyParticles[i] != null)
                    {
                        BattleSystemFossil.enemyParticles[i].Play();
                    }

                    yield return new WaitForSeconds(.3f);

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        EnemyHolder.shakeEnemy = false;

                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                        }

                    }//Turn enemy color normal and disable lighting

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                        {
                            BattleSystemFossil.enemiesKilled++;
                            Destroy(BattleSystemFossil.currentEnemies[i]);
                        }
                    }
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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
    } //An attack that deals massive damage to the last enemy.

    public void BlazingInferno() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        WeaponStats.fossilDurability[6]--;

        StartCoroutine("BurnTimer", 5);
    } //An attack that burns all enemies in battle for a specified number of passovers. Uses KillTimer.

    public IEnumerator PhantomTalons() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[9]--;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if(i == 0)
            {
                if (BattleSystemFossil.currentEnemies[i] != null && i == 0)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(32);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(85);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downed
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(55);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.shakeEnemy = true;

                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                        }
                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                    }//Set lighting to active, flash red

                    if (BattleSystemFossil.enemyParticles[i] != null)
                    {
                        BattleSystemFossil.enemyParticles[i].Play();
                    }

                    yield return new WaitForSeconds(.3f);

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        EnemyHolder.shakeEnemy = false;

                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                        }

                    }//Turn enemy color normal and disable lighting

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                        {
                            BattleSystemFossil.enemiesKilled++;
                            Destroy(BattleSystemFossil.currentEnemies[i]);
                        }
                    }
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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

    } //An attack that deals massive damage to the frontmost enemy.

    public IEnumerator DarkPulse() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[3]--;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(12);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    BattleSystemFossil.enemyUnit[i].affinity = 1;
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(45);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    BattleSystemFossil.enemyUnit[i].affinity = 2;

                    if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                    {
                        EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                    }
                    //Assigns the enemy to be downed
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(27);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    BattleSystemFossil.enemyUnit[i].affinity = 0;
                }

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.shakeEnemy = true;

                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    }
                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }//Set lighting to active, flash red

                if (BattleSystemFossil.enemyParticles[i] != null)
                {
                    BattleSystemFossil.enemyParticles[i].Play();
                }

                yield return new WaitForSeconds(.3f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    EnemyHolder.shakeEnemy = false;

                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    }

                }//Turn enemy color normal and disable lighting

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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

    } //An attack that deals decent damage to all enemies then inverts all enemy affinities.

    public IEnumerator PitchBlackDarkness() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
           yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[0]--;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(20);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(45);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                    {
                        EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;
                    }
                    //Assigns the enemy to be downeds
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(32);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.shakeEnemy = true;

                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    }
                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }//Set lighting to active, flash red

                if (BattleSystemFossil.enemyParticles[i] != null)
                {
                    BattleSystemFossil.enemyParticles[i].Play();
                }

                yield return new WaitForSeconds(.3f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    EnemyHolder.shakeEnemy = false;

                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    }

                }//Turn enemy color normal and disable lighting

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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
    } //An attack that deals decent damage to all enemies.

    public IEnumerator CleansingVapors() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
           yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[8]--;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(15);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(5);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(35);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    BattleSystemFossil.enemyUnit[i].affinity = 0;

                    if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                    {
                        EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                    }
                    //Assigns the enemy to be downed
                }

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.shakeEnemy = true;

                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    }
                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }//Set lighting to active, flash red

                if (BattleSystemFossil.enemyParticles[i] != null)
                {
                    BattleSystemFossil.enemyParticles[i].Play();
                }

                yield return new WaitForSeconds(.3f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    EnemyHolder.shakeEnemy = false;

                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    }

                }//Turn enemy color normal and disable lighting

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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

    } //An attack that deals decent damage to all enemies in battle then switches any "Cursed" affinity to "Blessed".

    public IEnumerator AlbinoSkull() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
           yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[2]--;

        if (skullUsed == false)
        {
            for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(5);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(1);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(10);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                        BattleSystemFossil.enemyUnit[i].damage = BattleSystemFossil.enemyUnit[i].damage / 2;

                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downed
                    }

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.shakeEnemy = true;

                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                        }
                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                    }//Set lighting to active, flash red

                    if (BattleSystemFossil.enemyParticles[i] != null)
                    {
                        BattleSystemFossil.enemyParticles[i].Play();
                    }

                    yield return new WaitForSeconds(.3f);

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        EnemyHolder.shakeEnemy = false;

                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                        }

                    }//Turn enemy color normal and disable lighting

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                        {
                            BattleSystemFossil.enemiesKilled++;
                            Destroy(BattleSystemFossil.currentEnemies[i]);
                        }
                    }
                }
            }
            skullUsed = true;
            BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;
        }
        else
        {
            infoBar.GetComponent<Animator>().SetBool("isOpen", true);

            infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "You cannot use that again this battle";


            yield return new WaitForSeconds(1.5f);

            infoBar.GetComponent<Animator>().SetBool("isOpen", false);

            infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Select an enemy";

            BattleSystemFossil.enemyTurnAttack = false;
            BattleSystemFossil.state = BattleStateFossil.PLAYERTURN;
            yield break;
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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

    } //An attack that deals low damage to all enemies in battle and halves the damage output of all enemies of the "Cursed" affinity.
      //Debug messages will be removed in the final build.

    public IEnumerator EphemeralEssence() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[5]--;

        if (EnemyHolder.enemyAmount == 3)
        {
            for (int i = 1; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null && i != 3)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(37);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(18);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(75);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downeds
                    }

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.shakeEnemy = true;

                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                        }
                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                    }//Set lighting to active, flash red

                    if (BattleSystemFossil.enemyParticles[i] != null)
                    {
                        BattleSystemFossil.enemyParticles[i].Play();
                    }

                    yield return new WaitForSeconds(.3f);

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        EnemyHolder.shakeEnemy = false;

                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                        }

                    }//Turn enemy color normal and disable lighting

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                        {
                            BattleSystemFossil.enemiesKilled++;
                            Destroy(BattleSystemFossil.currentEnemies[i]);
                        }
                    }
                }
            }
        }
        else if (EnemyHolder.enemyAmount == 2)
        {
            for (int i = 1; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null && i == 1)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(37);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(18);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(75);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downed
                    }

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.shakeEnemy = true;

                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                        }
                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                    }//Set lighting to active, flash red

                    if (BattleSystemFossil.enemyParticles[i] != null)
                    {
                        BattleSystemFossil.enemyParticles[i].Play();
                    }

                    yield return new WaitForSeconds(.3f);

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        EnemyHolder.shakeEnemy = false;

                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                        }

                    }//Turn enemy color normal and disable lighting

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                        {
                            BattleSystemFossil.enemiesKilled++;
                            Destroy(BattleSystemFossil.currentEnemies[i]);
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(37);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(18);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(75);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                        //Assigns the enemy to be downed
                    }


                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.shakeEnemy = true;

                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                        }
                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                    }//Set lighting to active, flash red

                    if (BattleSystemFossil.enemyParticles[i] != null)
                    {
                        BattleSystemFossil.enemyParticles[i].Play();
                    }

                    yield return new WaitForSeconds(.3f);

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        EnemyHolder.shakeEnemy = false;

                        BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                        if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                        {
                            BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                            BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                        }

                    }//Turn enemy color normal and disable lighting

                    if (BattleSystemFossil.currentEnemies[i] != null)
                    {
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                        if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                        {
                            BattleSystemFossil.enemiesKilled++;
                            Destroy(BattleSystemFossil.currentEnemies[i]);
                        }
                    }
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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

    } //An attack that deals massive damage to the middle two enemies.

    public IEnumerator HolyBoneSpear() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[17]--;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(10);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(5);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(20);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                    {
                        EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                        EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;
                    }
                    //Assigns the enemy to be downed
                }

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.shakeEnemy = true;

                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    }
                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }//Set lighting to active, flash red

                if (BattleSystemFossil.enemyParticles[i] != null)
                {
                    BattleSystemFossil.enemyParticles[i].Play();
                }

                yield return new WaitForSeconds(.3f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    EnemyHolder.shakeEnemy = false;

                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    }

                }//Turn enemy color normal and disable lighting

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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

    } //An attack that deals poor damage to all enemies.

    public IEnumerator PurifyArena() //Affinity: Support
    {
        if (purifyUsed == false)
        {
            if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
                yield break;

            BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

            BattleSystemFossil.enemyTurnAttack = true;

            WeaponStats.fossilDurability[7]--;

            ChooseAffinity();
            for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyUnit[i].affinity = chosenAffinity;
                    Debug.Log(BattleSystemFossil.enemyUnit[i].affinity);
                }
            }
            purifyUsed = true;
        }
        else
        {
            infoBar.GetComponent<Animator>().SetBool("isOpen", true);

            infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "You cannot use that again this battle";


            yield return new WaitForSeconds(1.5f);

            infoBar.GetComponent<Animator>().SetBool("isOpen", false);

            infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Select an enemy";

            BattleSystemFossil.enemyTurnAttack = false;
            BattleSystemFossil.state = BattleStateFossil.PLAYERTURN;
            yield break;
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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
    } //A special skill that runs an RNG (froms 0-2) then switches all enemy affinities to the number picked. Disables after one use.
      //Debug messages will be removed in the final build.

    public IEnumerator AncientRelic() //Affinity: Support
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[14]--;

        if (healUsed == false)
        {
            BattleSystemFossil.playerUnit.currentHP = BattleSystemFossil.playerUnit.maxHP;
            BattleSystemFossil.playerHUD.SetHP(BattleSystemFossil.playerUnit.currentHP);
            healUsed = true;
        }
        else
        {
            infoBar.GetComponent<Animator>().SetBool("isOpen", true);

            infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "You cannot use that again this battle";

            yield return new WaitForSeconds(1.5f);

            infoBar.GetComponent<Animator>().SetBool("isOpen", false);

            infoBar.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Select an enemy";

            BattleSystemFossil.enemyTurnAttack = false;
            BattleSystemFossil.state = BattleStateFossil.PLAYERTURN;
            yield break;
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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

    } //A special skill that heals the player for full health. Disables after one use.

    public IEnumerator VampiricFang() //Affinity: Support
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[11]--;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null && i == 0)
            {
                BattleSystemFossil.enemyUnit[i].TakeDamage(BattleSystemFossil.enemyUnit[i].currentHP / 2);
                BattleSystemFossil.playerUnit.currentHP += BattleSystemFossil.enemyUnit[i].currentHP;
                BattleSystemFossil.playerHUD.SetHP(BattleSystemFossil.playerUnit.currentHP);
                BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.shakeEnemy = true;

                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    }
                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }//Set lighting to active, flash red

                if (BattleSystemFossil.enemyParticles[i] != null)
                {
                    BattleSystemFossil.enemyParticles[i].Play();
                }

                yield return new WaitForSeconds(.3f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    EnemyHolder.shakeEnemy = false;

                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    }

                }//Turn enemy color normal and disable lighting

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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
    } //A special attack that steals half of the frontmost enemy's health and gives it to the player. The amount of health gained will diminish due to the nature of the attack, preventing attack spam.

    public void VitalitySwap() //Affinity: Support
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[4]--;

        ChooseEnemy();
        if (chosenEnemy > EnemyHolder.enemyAmount)
        {
            ChooseEnemy();
        }
        else
        {
            float plrHealth = BattleSystemFossil.playerUnit.currentHP;
            float enemyHealth = BattleSystemFossil.enemyUnit[chosenEnemy].currentHP;

            BattleSystemFossil.playerUnit.currentHP = enemyHealth;
            BattleSystemFossil.playerHUD.SetHP(BattleSystemFossil.playerUnit.currentHP);
            BattleSystemFossil.enemyUnit[chosenEnemy].currentHP = plrHealth;
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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
    } //An attack that swaps the player's health with a random enemy's health.

    public void SecretPower() //Affinity: Special
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[15]--;

        ChooseAttack();

        switch (chosenAttack)
        {
            case 0:
                MeteorStrike();
                break;
            case 1:
                StartCoroutine(LowKick());
                break;
            case 2:
                StartCoroutine(TailStab());
                break;
            case 3:
                StartCoroutine(ReverseStrike());
                break;
            case 4:
                BlazingInferno();
                break;
            case 5:
                StartCoroutine(PhantomTalons());
                break;
            case 6:
                StartCoroutine(DarkPulse());
                break;
            case 7:
                StartCoroutine(PitchBlackDarkness());
                break;
            case 8:
                StartCoroutine(CleansingVapors());
                break;
            case 9:
                StartCoroutine(AlbinoSkull());
                break;
            case 10:
                StartCoroutine(EphemeralEssence());
                break;
            case 11:
                StartCoroutine(HolyBoneSpear());
                break;
            case 12:
                PurifyArena();
                break;
            case 13:
                AncientRelic();
                break;
            case 14:
                VampiricFang();
                break;
        }
    } //An attack that uses an RNG to select a random attack or skill from the FossilAttacks script to use. If this code can be simplified and not look like shit, please tell me how :3
      //Debug text will be removed in final build.

    public IEnumerator AllOutAttack()
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        WeaponStats.fossilDurability[12]--;

        float plrHealth = BattleSystemFossil.playerUnit.currentHP;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if(BattleSystemFossil.currentEnemies[i] != null)
            {
                if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(plrHealth - 1);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(plrHealth - 1);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(plrHealth - 1);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.shakeEnemy = true;

                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    }
                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }//Set lighting to active, flash red

                if (BattleSystemFossil.enemyParticles[i] != null)
                {
                    BattleSystemFossil.enemyParticles[i].Play();
                }

                yield return new WaitForSeconds(.3f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    EnemyHolder.shakeEnemy = false;

                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    }

                }//Turn enemy color normal and disable lighting

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
                }
            }
        }

        BattleSystemFossil.playerUnit.currentHP = 1;
        BattleSystemFossil.playerHUD.SetHP(BattleSystemFossil.playerUnit.currentHP);

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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

    } //An attack that brings you down to 1 HP, but deals damage depending on how much health is lost to the attack, ignoring enemy affinities. 
    public IEnumerator KillTimer(int timer)
    {
        while (timer > 0)
        {
            timer--;
            Debug.Log(timer);
            yield return new WaitForSeconds(1.0f);
        }

        yield return new WaitForSeconds(1.0f);

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.enemyUnit[i].affinity == 0)
            {
                BattleSystemFossil.enemyUnit[i].TakeDamage(75);

                if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                {
                    EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                }
                //Assigns the enemy to be downed
            }
            else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
            {
                BattleSystemFossil.enemyUnit[i].TakeDamage(50);
            }
            else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
            {
                BattleSystemFossil.enemyUnit[i].TakeDamage(30);
            }

            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                EnemyHolder.shakeEnemy = true;

                if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                {
                    BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                    BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                }
                BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
            }//Set lighting to active, flash red

            if (BattleSystemFossil.enemyParticles[i] != null)
            {
                BattleSystemFossil.enemyParticles[i].Play();
            }

            yield return new WaitForSeconds(.3f);

            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                EnemyHolder.shakeEnemy = false;

                BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                {
                    BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                    BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                }

            }//Turn enemy color normal and disable lighting

            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                {
                    BattleSystemFossil.enemiesKilled++;
                    Destroy(BattleSystemFossil.currentEnemies[i]);
                }
            }
        }

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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

        StopCoroutine("KillTimer");
    } //The kill timer for MetorStrike.

    public IEnumerator BurnTimer(int timer)
    {
        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        BattleSystemFossil.enemyTurnAttack = true;

        while (timer > 0)
        {
            timer--;

            for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
            {
                if(BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(2);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(10);
                        if (BattleSystemFossil.currentEnemies[i].GetComponent<UnitStats>().isDowned == false)
                        {
                            EnemyHolder.enemyDowned[i] = BattleSystemFossil.currentEnemies[i];
                            EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                        }
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(5);
                    }
                }

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.cameraShake.shake = BattleSystemFossil.currentEnemies[i];
                    EnemyHolder.shakeEnemy = true;

                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(true);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    }
                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
                }

                if (BattleSystemFossil.enemyParticles[i] != null)
                {
                    BattleSystemFossil.enemyParticles[i].Play();
                }

                yield return new WaitForSeconds(.3f);

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    EnemyHolder.shakeEnemy = false;

                    BattleSystemFossil.enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
                    if (BattleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        BattleSystemFossil.enemyLightingEffects[i].SetActive(false);
                        BattleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    }

                }

                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);

                    if (BattleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        BattleSystemFossil.enemiesKilled++;
                        Destroy(BattleSystemFossil.currentEnemies[i]);
                    }
                }
            }
        }

        yield return new WaitForSeconds(0f);

        if (BattleSystemFossil.enemiesKilled >= EnemyHolder.enemyAmount + 1)
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
        chosenAttack = Random.Range(0, 15);
    } //The RNG that SecretPower uses to select an attack or skill.

    public void ChooseEnemy()
    {
        chosenEnemy = Random.Range(0, 4);
    } //The RNG that VitalitySwap uses to select an enemy.
}
