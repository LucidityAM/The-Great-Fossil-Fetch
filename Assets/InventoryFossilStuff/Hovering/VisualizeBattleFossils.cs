using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeBattleFossils : MonoBehaviour
{
    public GameObject buttons;
    public GameObject fossilBattle;
    public GameObject instantiatedFossilBattle;

    public bool instantiated = false;
    public Transform spawnLocation;

    public BattleSystemFossil battleSystemFossil;
    public void Awake()
    {
        if (spawnLocation == null)
        {
            spawnLocation = fossilBattle.transform;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && instantiated == true)
        {
            instantiatedFossilBattle.GetComponent<Animator>().SetBool("isOpen", false);
            StartCoroutine(DeleteInfo());
            instantiated = false;
        }       

        if(battleSystemFossil.state == BattleStateFossil.ENEMYTURN)
        {
            StartCoroutine(DeleteInfo());
        }

        if (battleSystemFossil.enemyTurnAttack == true)
        {
            if(instantiatedFossilBattle != null)
            {
                instantiatedFossilBattle.GetComponent<Animator>().SetBool("isOpen", false);
                instantiated = false;
            }
        }
    }

    public IEnumerator DeleteInfo()
    {
        battleSystemFossil.canAttack = false;

        instantiated = false;

        yield return new WaitForSeconds(.2f);

        GameObject StatText = GameObject.FindWithTag("FossilBattle");
        Destroy(StatText);

        battleSystemFossil.fossilAttack = false;

    }

    public void ToggleInfo()
    {
        if (instantiated == false)
        {
            for (int i = 0; i <= EnemyHolder.enemyAmount; i++)
            {
                if (EnemyHolder.enemyDowned[i] != null)
                {
                    EnemyHolder.enemyDowned[i].GetComponent<UnitStats>().isDowned = false;
                }
            }

            Array.Clear(EnemyHolder.enemyDowned, 0, EnemyHolder.enemyDowned.Length);

            battleSystemFossil.canAttack = true;

            Vector3 position = new Vector3(spawnLocation.position.x + .75f, spawnLocation.position.y + 2.3f);
            instantiatedFossilBattle = Instantiate(fossilBattle, position, Quaternion.identity, spawnLocation);

            instantiatedFossilBattle.GetComponent<Animator>().SetBool("isOpen", true);

            buttons.SetActive(false);

            instantiated = true;

            battleSystemFossil.fossilAttack = true;
        }
        else
        {
            instantiatedFossilBattle.GetComponent<Animator>().SetBool("isOpen", false);

            GameObject StatText = GameObject.FindWithTag("FossilBattle");
            Destroy(StatText);

            buttons.SetActive(true);

            instantiated = false;

            battleSystemFossil.fossilAttack = false;
        }

    }

}
