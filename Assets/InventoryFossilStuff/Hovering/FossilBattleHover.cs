using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FossilBattleHover : MonoBehaviour
{
    public GameObject fossilBattle;
    public GameObject instantiatedFossilBattle;

    public bool instantiated = false;
    public Transform spawnLocation;

    public void Awake()
    {
        if (spawnLocation == null)
        {
            spawnLocation = fossilBattle.transform;
        }
    }

    public IEnumerator DeleteInfo()
    {

        instantiated = false;

        yield return new WaitForSeconds(.2f);

        GameObject StatText = GameObject.FindWithTag("FossilBattleHover");
        Destroy(StatText);

    }

    public void ToggleInfo()
    {
        if (instantiated == false)
        {

            Vector3 position = new Vector3(spawnLocation.position.x + .8f, spawnLocation.position.y + 2.35f);
            instantiatedFossilBattle = Instantiate(fossilBattle, position, Quaternion.identity, spawnLocation);

            instantiatedFossilBattle.GetComponent<Animator>().SetBool("isOpen", true);

        }
        else
        {
            instantiatedFossilBattle.GetComponent<Animator>().SetBool("isOpen", false);

            GameObject StatText = GameObject.FindWithTag("FossilBattleHover");
            Destroy(StatText);

            instantiated = false;
        }

    }
}
