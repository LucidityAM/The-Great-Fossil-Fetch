using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] fossilPickups = new GameObject[18];

    public int[] fossilsGenerated = new int[18];

    public bool[] isTaken = new bool[18];

    public Transform spawnLocation;

    public Transform playerSpawn;

    public bool isGenerated = false;

    public void GenerateFossil()
    {
        
        WeaponStats.fossilGenerated = Random.Range(0, 17);

        isGenerated = false;

        while(isGenerated == false)
        {
            for (int i = 0; i <= fossilsGenerated.Length; i++)
            {
                if (isTaken[i] == false && fossilsGenerated[i] != WeaponStats.fossilGenerated)
                {
                    fossilsGenerated[i] = WeaponStats.fossilGenerated;
                    GameObject fossil = Instantiate(fossilPickups[WeaponStats.fossilGenerated], playerSpawn);

                    spawnLocation.transform.position = playerSpawn.position;

                    fossil.transform.parent = spawnLocation;

                    isGenerated = true;
                    isTaken[i] = true;
                    break;
                }
                else if (WeaponStats.fossilGenerated == fossilsGenerated[i])
                {
                    WeaponStats.fossilGenerated = Random.Range(0, 17);

                }
            }
        }
    }
   
}
