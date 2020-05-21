using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualizeStats : MonoBehaviour
{
    public GameObject StatText;

    public Transform spawnLocation;
    public GameObject statUI;
    public bool instantiated;

    public void Awake()
    {
        statUI = GameObject.FindWithTag("StatUI");
        if (spawnLocation == null)
        {
            spawnLocation = statUI.transform;
        }

    }

    public void InstantiateInfo()
    {
        if (instantiated == false)
        {
            Vector3 position = new Vector3(gameObject.transform.position.x + 940, gameObject.transform.position.y);
            Instantiate(StatText, position, Quaternion.identity, spawnLocation);
            instantiated = true;
        }

        if(gameObject.tag == "AttackRate")
        {
            Ristatic.stat = "Attack Rate";
        }
        else if (gameObject.tag == "Strength")
        {
            Ristatic.stat = "Strength";
        }
        else if (gameObject.tag == "Speed")
        {
            Ristatic.stat = "Speed";
        }
        else if (gameObject.tag == "Resolve")
        {
            Ristatic.stat = "Resolve";
        }
        else if (gameObject.tag == "Range")
        {
            Ristatic.stat = "Range";
        }

    }
    public void DestroyInfo()
    {

        GameObject StatText = GameObject.FindWithTag("StatText");
        Destroy(StatText);

        instantiated = false;

    }

}
