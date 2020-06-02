using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{

    public Slider hpSlider;
    public GameObject hp;

    public BattleSystemFossil battleSystemFossil;

    public Image affinity;

    public Sprite cursed;
    public Sprite blessed;
    public Sprite soma;


    public void FixedUpdate()
    {

        for(int i = 0; i < battleSystemFossil.currentEnemies.Length; i++)
        {
            if(this.gameObject.tag == "EnemyHUD" + i)
            {
                if(battleSystemFossil.currentEnemies[i] != null)
                {
                    if (battleSystemFossil.enemyUnit[i].currentHP <= 0)
                    {
                        hp.SetActive(false);
                    }

                    hp.SetActive(true);

                    hp.transform.position = battleSystemFossil.currentEnemies[i].transform.position;

                    hp.transform.position = new Vector3(hp.transform.position.x, hp.transform.position.y + 2, hp.transform.position.z);

                    if (battleSystemFossil.currentEnemies[i].CompareTag("Enemy1"))
                    {
                        hp.transform.position = new Vector3(hp.transform.position.x, hp.transform.position.y + 2.2f, hp.transform.position.z);

                        switch (battleSystemFossil.enemyUnit[i].affinity)
                        {
                            case 0:
                                affinity.sprite = blessed;
                                break;
                            case 1:
                                affinity.sprite = soma;
                                break;
                            case 2:
                                affinity.sprite = cursed;
                                break;
                        }

                    }//Sets the mummy affinity to soma and moves the health bar;
                    else if (battleSystemFossil.currentEnemies[i].CompareTag("Enemy2"))
                    {
                        hp.transform.position = new Vector3(hp.transform.position.x + .2f, hp.transform.position.y, hp.transform.position.z);
                        switch (battleSystemFossil.enemyUnit[i].affinity)
                        {
                            case 0:
                                affinity.sprite = blessed;
                                break;
                            case 1:
                                affinity.sprite = soma;
                                break;
                            case 2:
                                affinity.sprite = cursed;
                                break;
                        }

                    }//Sets the dinosaur affinity to cursed and moves the health bar
                    else if (battleSystemFossil.currentEnemies[i].CompareTag("Enemy0"))
                    {
                        switch (battleSystemFossil.enemyUnit[i].affinity)
                        {
                            case 0:
                                affinity.sprite = blessed;
                                break;
                            case 1:
                                affinity.sprite = soma;
                                break;
                            case 2:
                                affinity.sprite = cursed;
                                break;
                        }

                    }//Sets the scarab affinity to blessed and moves the health bar
                    else if (battleSystemFossil.currentEnemies[i].CompareTag("Boss1"))
                    {
                        hp.transform.position = new Vector3(hp.transform.position.x + 1.3f, hp.transform.position.y + 1f, hp.transform.position.z);
                        switch (battleSystemFossil.enemyUnit[i].affinity)
                        {
                            case 0:
                                affinity.sprite = blessed;
                                break;
                            case 1:
                                affinity.sprite = soma;
                                break;
                            case 2:
                                affinity.sprite = cursed;
                                break;
                        }

                    }//Sets Index's affinity to cursed and moves the health bar
                    else if (battleSystemFossil.currentEnemies[i].CompareTag("Boss2"))
                    {
                        hp.transform.position = new Vector3(hp.transform.position.x + 1f, hp.transform.position.y + 2f, hp.transform.position.z);
                        switch (battleSystemFossil.enemyUnit[i].affinity)
                        {
                            case 0:
                                affinity.sprite = blessed;
                                break;
                            case 1:
                                affinity.sprite = soma;
                                break;
                            case 2:
                                affinity.sprite = cursed;
                                break;
                        }

                    }//Sets Panama's affinity to cursed and moves the health bar
                    else if (battleSystemFossil.currentEnemies[i].CompareTag("Boss3"))
                    {
                        hp.transform.position = new Vector3(hp.transform.position.x - 2f, hp.transform.position.y - 5.5f, hp.transform.position.z);
                        switch (battleSystemFossil.enemyUnit[i].affinity)
                        {
                            case 0:
                                affinity.sprite = blessed;
                                break;
                            case 1:
                                affinity.sprite = soma;
                                break;
                            case 2:
                                affinity.sprite = cursed;
                                break;
                        }

                    }//Sets Dimitrisaurus's affinity to cursed and moves the health bar

                }
                else
                {
                    hp.SetActive(false);
                }
               
                //moves the hp bar ontop of the enemy

            }//checks the tag of the hud so it can move the proper health bar

        }//for all the current enemies, runs the code
    }

    public void SetHUD(UnitStats unit)
    {
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
    }

    public void SetHP(float hp)
    {
        hpSlider.value = hp;
    }

    public void Update()
    {
        if (hpSlider.value <= 0)
        {
            hp.SetActive(false);
        }

        if (this.gameObject.CompareTag("Player"))
        {
            hp.SetActive(true);
        }
        
    }
}
