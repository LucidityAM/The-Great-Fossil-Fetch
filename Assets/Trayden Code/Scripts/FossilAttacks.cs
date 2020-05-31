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

    public IEnumerator LowKick() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;


        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if(i == 0 || i == 1)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(64);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(32);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(15);
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


    } //An attack that deals decent damage to the front two enemies in a battle.

    public IEnumerator TailStab() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(30);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(15);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(7);
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
    } //An attack that hits all enemies for even damage.

    public IEnumerator ReverseStrike() //Affinity: Soma
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        if (EnemyHolder.enemyAmount == 3)
        {
            for (int i = 3; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(75);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(33);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(18);
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
                        BattleSystemFossil.enemyUnit[i].TakeDamage(75);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(33);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(18);
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
                        BattleSystemFossil.enemyUnit[i].TakeDamage(75);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(33);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(18);
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
                        BattleSystemFossil.enemyUnit[i].TakeDamage(75);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(33);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(18);
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
    } //An attack that deals massive damage to the last enemy.

    public void BlazingInferno() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        StartCoroutine("BurnTimer", 5);
    } //An attack that burns all enemies in battle for a specified number of passovers. Uses KillTimer.

    public IEnumerator PhantomTalons() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if(i == 0)
            {
                if (BattleSystemFossil.currentEnemies[i] != null && i == 0)
                {
                    if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(12);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(64);
                        BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
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

                    yield break;

                }
            }
        }
    } //An attack that deals massive damage to the frontmost enemy.

    public IEnumerator DarkPulse() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(10);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    BattleSystemFossil.enemyUnit[i].affinity = 1;
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(40);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    BattleSystemFossil.enemyUnit[i].affinity = 2;
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(20);
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

    } //An attack that deals decent damage to all enemies then inverts all enemy affinities.

    public IEnumerator PitchBlackDarkness() //Affinity: Cursed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
           yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (BattleSystemFossil.currentEnemies[i] != null)
            {
                if (BattleSystemFossil.enemyUnit[i].affinity == 0)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(5);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    BattleSystemFossil.enemyUnit[i].affinity = 1;
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(35);
                    BattleSystemFossil.enemyHUDs[i].SetHP(BattleSystemFossil.enemyUnit[i].currentHP);
                    BattleSystemFossil.enemyUnit[i].affinity = 2;
                }
                else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                {
                    BattleSystemFossil.enemyUnit[i].TakeDamage(15);
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
    } //An attack that deals decent damage to all enemies.

    public IEnumerator CleansingVapors() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
           yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

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
    } //An attack that deals decent damage to all enemies in battle then switches any "Cursed" affinity to "Blessed".

    public IEnumerator AlbinoSkull() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
           yield break;

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
            Debug.Log("Enemy attack power cannot be lowered anymore. You cannot use this fossil.");
            yield break;
        }
    } //An attack that deals low damage to all enemies in battle and halves the damage output of all enemies of the "Cursed" affinity.
      //Debug messages will be removed in the final build.

    public IEnumerator EphemeralEssence() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;
        if (EnemyHolder.enemyAmount == 3)
        {
            for (int i = 1; i <= EnemyHolder.enemyAmount; i++)
            {
                if (BattleSystemFossil.currentEnemies[i] != null && i != 2)
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
                else if (i == 2)
                {
                    yield break;
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
                    yield break;
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
    } //An attack that deals massive damage to the middle two enemies.

    public IEnumerator HolyBoneSpear() //Affinity: Blessed
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

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

    } //An attack that deals poor damage to all enemies.

    public void PurifyArena() //Affinity: Support
    {
        if (purifyUsed == false)
        {
            if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
                return;

            BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

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
            Debug.Log("You have already purified this arena. You may not do so again.");
        }
    } //A special skill that runs an RNG (froms 0-2) then switches all enemy affinities to the number picked. Disables after one use.
      //Debug messages will be removed in the final build.

    public void AncientRelic() //Affinity: Support
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

        if (healUsed == false)
        {
            BattleSystemFossil.playerUnit.currentHP = BattleSystemFossil.playerUnit.maxHP;
            BattleSystemFossil.playerHUD.SetHP(BattleSystemFossil.playerUnit.currentHP);
            healUsed = true;
        }
        else
        {
            Debug.Log("You can only heal to full health once per battle.");
        }
    } //A special skill that heals the player for full health. Disables after one use.

    public IEnumerator VampiricFang() //Affinity: Support
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            yield break;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

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
    } //A special attack that steals half of the frontmost enemy's health and gives it to the player. The amount of health gained will diminish due to the nature of the attack, preventing attack spam.

    public void VitalitySwap() //Affinity: Support
    {
        if (BattleSystemFossil.state != BattleStateFossil.PLAYERTURN)
            return;

        BattleSystemFossil.state = BattleStateFossil.ENEMYTURN;

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
    } //An attack that swaps the player's health with a random enemy's health

    public void SecretPower() //Affinity: Special
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
            TailStab();
            Debug.Log("Chosen Attack: Tail Stab");
        }
        else if (chosenAttack == 3)
        {
            ReverseStrike();
            Debug.Log("Chosen Attack: Reverse Strike");
        }
        else if (chosenAttack == 4)
        {
            BlazingInferno();
            Debug.Log("Chosen Attack: Blazing Inferno");
        }
        else if (chosenAttack == 5)
        {
            PhantomTalons();
            Debug.Log("Chosen Attack: Phantom Talons");
        }
        else if (chosenAttack == 6)
        {
            DarkPulse();
            Debug.Log("Chosen Attack: Dark Pulse");
        }
        else if (chosenAttack == 7)
        {
            PitchBlackDarkness();
            Debug.Log("Chosen Attack: Pitch Black Darkness");
        }
        else if (chosenAttack == 8)
        {
            CleansingVapors();
            Debug.Log("Chosen Attack: Cleansing Vapors");
        }
        else if (chosenAttack == 9)
        {
            AlbinoSkull();
            Debug.Log("Chosen Attack: Albino Skull");
        }
        else if (chosenAttack == 10)
        {
            EphemeralEssence();
            Debug.Log("Chosen Attack: Ephemeral Essence");
        }
        else if (chosenAttack == 11)
        {
            HolyBoneSpear();
            Debug.Log("Chosen Attack: Holy Bone Spear");
        }
        else if (chosenAttack == 12)
        {
            PurifyArena();
            Debug.Log("Chosen Attack: Purify Arena");
        }
        else if (chosenAttack == 13)
        {
            AncientRelic();
            Debug.Log("Chosen Attack: Ancient Relic");
        }
        else if (chosenAttack == 14)
        {
            VampiricFang();
            Debug.Log("Chosen Attack: Vampiric Fang");
        }
    } //An attack that uses an RNG to select a random attack or skill from the FossilAttacks script to use. If this code can be simplified and not look like shit, please tell me how :3
      //Debug text will be removed in final build.

    public IEnumerator AllOutAttack()
    {
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
                BattleSystemFossil.enemyUnit[i].TakeDamage(45);
            }
            else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
            {
                BattleSystemFossil.enemyUnit[i].TakeDamage(22);
            }
            else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
            {
                BattleSystemFossil.enemyUnit[i].TakeDamage(11);
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

        StopCoroutine("KillTimer");
    } //The kill timer for MetorStrike.

    public IEnumerator BurnTimer(int timer)
    {

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
                        BattleSystemFossil.enemyUnit[i].TakeDamage(8);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 1)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(4);
                    }
                    else if (BattleSystemFossil.enemyUnit[i].affinity == 2)
                    {
                        BattleSystemFossil.enemyUnit[i].TakeDamage(2);
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
