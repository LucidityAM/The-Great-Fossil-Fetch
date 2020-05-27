using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHovering : MonoBehaviour
{
    public BattleSystemFossil battleSystemFossil;

    public Image enemyGlow;

    public GameObject enemyGlowObject;

    public Image targetSelect;

    public bool change;

    void Start()
    {
        battleSystemFossil = GameObject.FindGameObjectWithTag("BattleSystem").GetComponent<BattleSystemFossil>();
        enemyGlow = gameObject.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>();
        targetSelect = gameObject.transform.GetChild(1).gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (battleSystemFossil.canAttack == false && battleSystemFossil.enemyTurnAttack == true)
        {
            for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
            {
                if (enemyGlowObject == battleSystemFossil.currentEnemies[i])
                {
                    if(battleSystemFossil.currentEnemies[i].tag != "Boss1")
                    {
                        enemyGlow.material.SetVector("_Color", new Vector4(37, 24, 7, 0));
                    }
                    else
                    {
                        enemyGlow.material.SetVector("_Color", new Vector4(25, 16, 5, 0)); //191,123,39,0, 5.06 intensity
                    }
                    
                    targetSelect.enabled = false;
                }
            }
        }
    }

    public void HoverOn()
    {
       if(battleSystemFossil.canAttack == true && battleSystemFossil.enemyTurnAttack == false && battleSystemFossil.fossilAttack == false)
       {
            for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
            {
                if (enemyGlowObject == battleSystemFossil.currentEnemies[i])
                {
                    battleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = false;
                    battleSystemFossil.enemyLightingEffects[i].SetActive(true);
                    targetSelect.enabled = true;
                }
            }

            enemyGlow.material.SetVector("_Color", new Vector4(28, 13, 3, 0));
        }
    }

    public void HoverOff()
    {
        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (enemyGlowObject == battleSystemFossil.currentEnemies[i])
            {
                if(battleSystemFossil.currentEnemies[i].tag != "Boss1")
                {
                    battleSystemFossil.currentEnemies[i].GetComponent<Image>().enabled = true;
                    enemyGlow.material.SetVector("_Color", new Vector4(37, 24, 7, 0));
                }
                else
                {
                    enemyGlow.material.SetVector("_Color", new Vector4(25, 16, 5, 0)); //191,123,39,0, 5.06 intensity
                }

                battleSystemFossil.enemyLightingEffects[i].SetActive(false);
                
                targetSelect.enabled = false;
            }
        }
    }

}