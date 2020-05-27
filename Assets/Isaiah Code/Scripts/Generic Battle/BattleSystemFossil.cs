using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Net;
using System.Numerics;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;


public enum BattleStateFossil { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystemFossil : MonoBehaviour
{
    private const bool V = true;

    //The entire battle and all its components for encounters
    public GameObject battle;
    public Camera mainCamera;
    public GameObject worldPlayer;

    //The player and enemies
    public GameObject playerPrefab;
    public GameObject[] enemies = new GameObject[3];

    //The locations where the enemies spawn
    public Transform[] enemyBattleStations = new Transform[4];

    //The stats on the player and enemy unit (assigned on the prefab)
    public UnitStats playerUnit;
    public UnitStats[] enemyUnit = new UnitStats[4];

    //The player and enemy HUD that controls the health of player and enemy
    public BattleHUD playerHUD;
    public BattleHUD[] enemyHUDs = new BattleHUD[4];

    //Allows the enemy and player to flash red when hit
    public Image playerColor;
    public Image[] enemyColor = new Image[4];

    //The current Battle State
    public BattleStateFossil state;

    //Current enemies the player is facing
    public GameObject[] currentEnemies = new GameObject[4];

    //All of the enemy attack scripts
    Enemy0 enemy0Attack;
    Enemy1 enemy1Attack;
    Enemy2 enemy2Attack;

    //All shaders to be edited (outer glow)
    public GameObject[] enemyLightingEffects = new GameObject[4];

    //Buttons
    public Button attackButton;

    //Bool
    public bool enemyTurnAttack;
    public bool canAttack;
    public bool fossilAttack;

    //Ints
    public int enemiesKilled;
    public int enemyAmount;

    //Enemy Shake Stuff
    public CameraShake cameraShake;

    //A random readonly varaiable
    private static readonly System.Random getrandom = new System.Random();

    //The menu manager pause script
    public PauseScript MenuManager;

    //The central UI containing all buttons
    public GameObject buttons;
    public Animator infoBar;

    //Downed icon
    public GameObject downedIcon;

    public void BattleStart()
    {
        BattleCount.battleCount++;

        MenuManager.enabled = false;

        MusicManager.normalBattleMusic = true;

        System.Random rnd = new System.Random();

        EnemyHolder.enemyAmount = 3;
        //finds out the amount of enemies the player will be fighting


        state = BattleStateFossil.START;

        switch (EnemyHolder.bossNumber)
        {
            case 0:
                StartCoroutine(SetupBattle());
                break;
            case 1:
                StartCoroutine(SetUpBossFight1());
                break;
            case 2:
                StartCoroutine(SetUpBossFight2());
                break;
            case 3:
                StartCoroutine(SetUpBossFight3());
                break;
        }
        
    }//Does an initial setup of all battle things

    void Update()
    {
        Debug.Log(PlayerStats.defendButton);

        if (EnemyHolder.coroutinesRunning == 0 && enemyTurnAttack == false)
        {
            attackButton.enabled = true;
            state = BattleStateFossil.PLAYERTURN;
            PlayerStats.defendButton = 1;
            StartCoroutine(PlayerTurn());
        }//Checks if there are no enemies attacking and re enables attack buttons and player turn

        if (Input.GetKeyDown(KeyCode.H))
        {
            for(int i = 0; i < 4; i++)
            {
                enemyUnit[i].currentHP = 0;
            }

            state = BattleStateFossil.WON;
            EndBattle();
        }

        for(int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if(currentEnemies[i] != null)
            {
                if (enemyUnit[i].isDowned == true)
                {
                    downedIcon = currentEnemies[i].transform.GetChild(2).gameObject;
                    downedIcon.SetActive(true);
                }
                else
                {
                    downedIcon = currentEnemies[i].transform.GetChild(2).gameObject;
                    downedIcon.SetActive(false);
                }
            } 
        }
    }

    IEnumerator SetupBattle()
    {
        float animSpeed = .4f;

        System.Random rnd = new System.Random();

        switch (EnemyHolder.enemyAmount)
        {
            case 0:
                enemyBattleStations[0].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(-46, -175);
                break;
            case 1:
                enemyBattleStations[0].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(47, -175);
                enemyBattleStations[1].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(400, -175);
                break;
            case 2:
                enemyBattleStations[0].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(-46, -175);
                enemyBattleStations[1].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(200, -175);
                enemyBattleStations[2].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(446, -175);
                break;
            case 3:
                enemyBattleStations[0].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(-46, -175);
                enemyBattleStations[1].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(137, -175);
                enemyBattleStations[2].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(332, -175);
                enemyBattleStations[3].GetComponent<RectTransform>().anchoredPosition = new UnityEngine.Vector2(551, -175);
                break;
        }//Places the enemies in their respective positions based on the amount of enemies that there are

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            int enemyInSpace = rnd.Next(0, 3);

            if (enemyInSpace == 2 && (i == 1 || i == 2 || i == 3))
            {
                enemyInSpace = rnd.Next(0, 2);
            }
            else if(i == 1 || i == 2 || i == 3)
            {
                enemyInSpace = rnd.Next(0,2);
            }
            else
            {
                enemyInSpace = 2;

            }//Forces the Ambersaur to spawn only in the first spot every time

            GameObject enemyGO  = Instantiate(enemies[enemyInSpace], enemyBattleStations[i]); //Instantiates enemy

            enemyGO.name = "enemy" + i; //Gives it a name and number

            currentEnemies[i] = enemyGO; //Assigns the enemy to a place on the array of all current enemies

            enemyUnit[i] = enemyGO.GetComponent<UnitStats>(); //Grabs the enemy's stats

            switch(enemyInSpace)
            {
                case 0:
                    enemyUnit[i].affinity = 0;
                    break;
                case 1:
                    enemyUnit[i].affinity = 1;
                    break;
                case 2:
                    enemyUnit[i].affinity = 2;
                    break;
            }
            //Checks if the enemy is numbered 0, 1, or 2, and sets affinity accordingly
                    //affinity 0 = blessed (scarab)
                    //affinity 1 = soma (mummy)
                    //affinity 2 = cursed (dinosaur)

            animSpeed += .05f;

            enemyColor[i] = enemyGO.GetComponent<Image>(); // Grabs the color of the enemy so it can be changed

            enemyHUDs[i].SetHUD(enemyUnit[i]); //Sets the hud with the enemy stats

            enemyLightingEffects[i] = enemyGO.transform.GetChild(0).gameObject; //Assigns the lighting effects from the enemy

            currentEnemies[i].GetComponent<Animator>().speed = animSpeed;

            enemyLightingEffects[i].transform.GetChild(1).gameObject.GetComponent<Animator>().speed = animSpeed;

            enemyLightingEffects[i].SetActive(false); //Turns off the lighting effects

        }//Assigns random enemies in the battle based on how many there are dictated by the randomly generated enemy amount

        #region InitialSetup

        playerUnit = playerPrefab.GetComponent<UnitStats>();
        playerColor = playerPrefab.GetComponent<Image>();

        playerHUD.SetHUD(playerUnit);

        buttons.SetActive(true);

        if (GameObject.FindGameObjectsWithTag("Enemy0").Length > 0)
        {
            enemy0Attack = GameObject.FindGameObjectWithTag("Enemy0").GetComponent<Enemy0>();
        }
        if (GameObject.FindGameObjectsWithTag("Enemy1").Length > 0)
        {
            enemy1Attack = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<Enemy1>();
        }
        if (GameObject.FindGameObjectsWithTag("Enemy2").Length > 0)
        {
            enemy2Attack = GameObject.FindGameObjectWithTag("Enemy2").GetComponent<Enemy2>();
        }
        //Assigns all the attack scripts to their respective enemies


        #endregion InitialSetup

        yield return new WaitForSeconds(.5f);

        state = BattleStateFossil.PLAYERTURN;
        PlayerTurn();
    }//Does an initial setup of the battle

    IEnumerator SetUpBossFight1()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator SetUpBossFight2()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator SetUpBossFight3()
    {
        yield return new WaitForSeconds(1f);
    }

    public void OnAttackButton()
    {
        if (state != BattleStateFossil.PLAYERTURN)
            return;
        canAttack = true;
        infoBar.SetBool("isOpen", true);
        buttons.SetActive(false);

    }//Attacks when the player presses a button
    public void OnDefendButton()
    {
        if (state != BattleStateFossil.PLAYERTURN)
            return;

        PlayerStats.defendButton = 1.5f;

        state = BattleStateFossil.ENEMYTURN;
        EnemyTurn();

    }//Sets a devisor so when the enemy attacks, it divides the damage

    public IEnumerator PlayerAttack(GameObject enemy)
    {
        state = BattleStateFossil.ENEMYTURN;

        enemyTurnAttack = true;

        float damage;

        Affinities.attackAffinity = 2; //sets the affinity of the attack to cursed

        // 0 = blessed
        // 1 = soma
        // 2 = cursed

        if(enemy.GetComponent<UnitStats>().isDowned == true)
        {
            damage = playerUnit.damage * 1.35f;
        }
        else
        {
            damage = playerUnit.damage;
        }//Checks if the enemy the player is attacking is downed and multiplies the damage accordingly

        if (enemy.GetComponent<UnitStats>().affinity == 0)
        {
            enemy.GetComponent<UnitStats>().TakeDamage(damage * 1.35f);

            for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
            { 

                if (enemy == currentEnemies[i] && enemy.GetComponent<UnitStats>().isDowned == false)
                {
                    EnemyHolder.enemyDowned[i] = enemy;
                    EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = true;

                }

            }//Assigns the enemy to be downed
           
        }
        else if(enemy.GetComponent<UnitStats>().affinity == 1)
        {
            enemy.GetComponent<UnitStats>().TakeDamage(damage * .75f);
        }
        else
        {
            enemy.GetComponent<UnitStats>().TakeDamage(damage);
        }//checks what the enemy affinity is and does more/less damage accod

        for(int i = 0; i < enemyHUDs.Length; i++)
        {
            if (enemyUnit[i] != null)
            {
                enemyHUDs[i].SetHP(enemyUnit[i].currentHP);
            }
        }//Sets the health of all the huds

        enemy.transform.GetChild(0).gameObject.SetActive(false); //Set the lighting to false

        yield return new WaitForSeconds(.2f);

        if (enemy != null)
        {
            cameraShake.shake = enemy;
            EnemyHolder.shakeEnemy = true;

            enemy.transform.GetChild(0).gameObject.SetActive(true);
            enemy.GetComponent<Image>().enabled = false;
            enemy.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 0, 0);
        }//Set lighting to active, flash red

        yield return new WaitForSeconds(.3f);

        if (enemy != null)
        {
            EnemyHolder.shakeEnemy = false;

            enemy.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            enemy.transform.GetChild(0).gameObject.SetActive(false);
            enemy.GetComponent<Image>().enabled = true;
        }//Turn enemy color normal and disable lighting

        yield return new WaitForSeconds(.2f);

        if (enemy.GetComponent<UnitStats>().currentHP <= 0)
        {
            Destroy(enemy);

            yield return new WaitForSeconds(.1f);

            enemiesKilled++;

            state = BattleStateFossil.ENEMYTURN;
            EnemyTurn();

            if (enemiesKilled >= EnemyHolder.enemyAmount + 1)
            {
                state = BattleStateFossil.WON;
                EndBattle();
            }
        }//Checks if all enemies are killed and then ends the battle
        else
        {
            state = BattleStateFossil.ENEMYTURN;
            EnemyTurn();
        }
        //Change state based on what happened

    }//The basic player attack

    public void EnemySelect(GameObject enemyToAttack)
    {
        if(canAttack == true && fossilAttack == false)
        {
            canAttack = false;
            infoBar.SetBool("isOpen", false);
            StartCoroutine(PlayerAttack(enemyToAttack));
        }
    }//Selects the enemy to attack

    public void EnemyTurn()
    {

        buttons.SetActive(false);

        enemyTurnAttack = true;

        #region ResetEnemyAttacks
        bool enemy0Taken = false;
        bool enemy1Taken = false;
        bool enemy2Taken = false;
        bool enemy3Taken = false;

        //Clears the lighting effects and enemies so it can reassign them
        Array.Clear(enemyLightingEffects, 0, enemyLightingEffects.Length);
        Array.Clear(currentEnemies, 0, currentEnemies.Length);

        
        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (GameObject.Find("enemy0") != null && enemy0Taken == false)
            {
                enemy0Taken = true;
                currentEnemies[i] = GameObject.Find("enemy0");
                enemyUnit[i] = currentEnemies[i].GetComponent<UnitStats>();
                enemyColor[i] = currentEnemies[i].GetComponent<Image>();
                enemyHUDs[i].SetHUD(enemyUnit[i]);
            }
            else if (GameObject.Find("enemy1") != null && enemy1Taken == false)
            {
                enemy1Taken = true;
                currentEnemies[i] = GameObject.Find("enemy1");
                enemyUnit[i] = currentEnemies[i].GetComponent<UnitStats>();
                enemyColor[i] = currentEnemies[i].GetComponent<Image>();
                enemyHUDs[i].SetHUD(enemyUnit[i]);
            }
            else if (GameObject.Find("enemy2") != null && enemy2Taken == false)
            {
                enemy2Taken = true;
                currentEnemies[i] = GameObject.Find("enemy2");
                enemyUnit[i] = currentEnemies[i].GetComponent<UnitStats>();
                enemyColor[i] = currentEnemies[i].GetComponent<Image>();
                enemyHUDs[i].SetHUD(enemyUnit[i]);
            }
            else if (GameObject.Find("enemy3") != null && enemy3Taken == false)
            {
                enemy3Taken = true;
                currentEnemies[i] = GameObject.Find("enemy3");
                enemyUnit[i] = currentEnemies[i].GetComponent<UnitStats>();
                enemyColor[i] = currentEnemies[i].GetComponent<Image>();
                enemyHUDs[i].SetHUD(enemyUnit[i]);
            }
        }//Reassigns all of the enemies to make sure they are always taking up the first spaces in the array 

        for (int j = 0; j <= EnemyHolder.enemyAmount; j++)
        {
            if(currentEnemies[j] != null)
            {
                enemyLightingEffects[j] = currentEnemies[j].transform.GetChild(0).gameObject;
            }
        }//Assigns the lighting effects for all current enemies
        
        if (GameObject.FindGameObjectsWithTag("Enemy0").Length > 0)
        {
            enemy0Attack = GameObject.FindGameObjectWithTag("EnemyStuff").GetComponent<Enemy0>();
        }
        if (GameObject.FindGameObjectsWithTag("Enemy1").Length > 0)
        {
            enemy1Attack = GameObject.FindGameObjectWithTag("EnemyStuff").GetComponent<Enemy1>();
        }
        if (GameObject.FindGameObjectsWithTag("Enemy2").Length > 0)
        {
            enemy2Attack = GameObject.FindGameObjectWithTag("EnemyStuff").GetComponent<Enemy2>();
        }
        //Resets all the enemy attack scripts to make sure there are still scripts to load attacks from

        #endregion ResetEnemyAttacks

        for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
        {
            if (currentEnemies[i] != null)
            {
                if (currentEnemies[i].CompareTag("Enemy0") && currentEnemies[i] != null && enemy0Attack != null)
                {
                    enemy0Attack.StartCoroutine("EnemyTurn0");
                    EnemyHolder.coroutinesRunning++;
                }
                else if (currentEnemies[i].CompareTag("Enemy1") && currentEnemies[i] != null && enemy1Attack != null)
                {
                    enemy1Attack.StartCoroutine("EnemyTurn1");
                    EnemyHolder.coroutinesRunning++;
                }
                else if (currentEnemies[i].CompareTag("Enemy2") && currentEnemies[i] != null && enemy2Attack != null)
                {
                    enemy2Attack.StartCoroutine("EnemyTurn2");
                    EnemyHolder.coroutinesRunning++;
                }
            }
            
        }//Runs all enemy coroutines with delays and then sets the coroutines running to 0

        if (playerUnit.currentHP <= 0)
        {
            state = BattleStateFossil.LOST;
            EndBattle();
        }
        enemyTurnAttack = false;
    } //Basic enemy turn that will look at which enemy the player is fighting, and start seperate scripts depending on the enemy.

    public void EndBattle()
    {
        if (state == BattleStateFossil.WON)
        {
            for (int i = 0; i < currentEnemies.Length; i++)
            {
                Destroy(currentEnemies[i]);
            }
            buttons.SetActive(true);
            enemyTurnAttack = false;
            Array.Clear(currentEnemies,0,currentEnemies.Length);
            worldPlayer.SetActive(true);
            worldPlayer.GetComponent<SpriteRenderer>().enabled = true;
            mainCamera.orthographicSize = 12;
            worldPlayer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            MenuManager.enabled = true;
            enemiesKilled = 0;
            MusicManager.normalBattleMusic = false;
            battle.SetActive(false);
        }//Turns on the world player, disabled the battle, destroys all the enemies, and clears the current enemy array to reset all values
        else if (state == BattleStateFossil.LOST)
        {
            for (int i = 0; i < currentEnemies.Length; i++)
            {
                Destroy(currentEnemies[i]);
            }
            buttons.SetActive(true);
            enemyTurnAttack = false;
            Array.Clear(currentEnemies, 0, currentEnemies.Length);
            worldPlayer.SetActive(true);
            worldPlayer.GetComponent<SpriteRenderer>().enabled = true;
            mainCamera.orthographicSize = 12;
            worldPlayer.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            MenuManager.enabled = true;
            enemiesKilled = 0;
            MusicManager.normalBattleMusic = false;
            battle.SetActive(false);
        }//Turns on the world player, disabled the battle, destroys all the enemies, and clears the current enemy array to reset all values

    }//Reads if the player killed the enemy and responds accordingly

    public IEnumerator PlayerTurn()
    {
        if(canAttack == true && Input.GetKeyDown(KeyCode.Escape))
        {
            canAttack = false;
            infoBar.SetBool("isOpen", false);
            buttons.SetActive(true);
        }

        for (int k = 0; k <= EnemyHolder.enemyAmount; k++)
        {
            if (EnemyHolder.enemyDowned[k] != null)
            {
                EnemyHolder.enemyDowned[k].GetComponent<UnitStats>().isDowned = false;
            }
        }//Sets all enemy downed bools to false

        Array.Clear(EnemyHolder.enemyDowned, 0, EnemyHolder.enemyDowned.Length); //Clears the enemy downed array

        if (canAttack == true)
        {
            buttons.SetActive(false);
        }
        else
        {
            buttons.SetActive(true);
        }

        if (playerUnit.currentHP <= 0)
        {
            state = BattleStateFossil.LOST;
            EndBattle();
        }
        yield return new WaitForSeconds(.0f);
    } // Basic player turn that holds the state "PlayerTurn" indefinately


}


