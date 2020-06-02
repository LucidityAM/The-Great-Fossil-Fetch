using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] fossilPickups = new GameObject[18];

    public int fossilGenerated;

    public int[] fossilsGenerated = new int[18];

    public bool[] isTaken = new bool[18];

    public Transform spawnLocation;

    public Transform playerSpawn;

    public bool isGenerated = false;

    public void GenerateFossil()
    {
        
        fossilGenerated = Random.Range(0, 17);

        isGenerated = false;

        while(isGenerated == false)
        {
            for (int i = 0; i <= fossilsGenerated.Length; i++)
            {
                if (isTaken[i] == false && fossilsGenerated[i] != fossilGenerated)
                {
                    fossilsGenerated[i] = fossilGenerated;
                    GameObject fossil = Instantiate(fossilPickups[fossilGenerated], playerSpawn);

                    spawnLocation.transform.position = playerSpawn.position;

                    fossil.transform.parent = spawnLocation;

                    isGenerated = true;
                    isTaken[i] = true;
                    break;
                }
                else if (fossilGenerated == fossilsGenerated[i])
                {
                    fossilGenerated = Random.Range(0, 17);

                }
            }
        }
    }
   
}
