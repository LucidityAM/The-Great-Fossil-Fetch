using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizeSpecificFossils : MonoBehaviour
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

        if (battleSystemFossil.state == BattleStateFossil.ENEMYTURN)
        {
            StartCoroutine(DeleteInfo());
        }

        if (battleSystemFossil.enemyTurnAttack == true)
        {
            if (instantiatedFossilBattle != null)
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

    }

    public void ToggleInfo()
    {
        if (instantiated == false)
        {
            battleSystemFossil.canAttack = true;

            Vector3 position = new Vector3(spawnLocation.position.x + .75f, spawnLocation.position.y + 2.3f);
            instantiatedFossilBattle = Instantiate(fossilBattle, position, Quaternion.identity, spawnLocation);

            instantiatedFossilBattle.GetComponent<Animator>().SetBool("isOpen", true);

            buttons.SetActive(false);

            instantiated = true;
        }
        else
        {
            instantiatedFossilBattle.GetComponent<Animator>().SetBool("isOpen", false);

            GameObject StatText = GameObject.FindWithTag("FossilBattle");
            Destroy(StatText);

            buttons.SetActive(true);

            instantiated = false;
        }

    }
}
