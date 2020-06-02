using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] fossilPickups = new GameObject[18];

    public int fossilGenerated;

    public int[] fossilsGenerated = new int[18];

    public bool[] isTaken = new bool[18];

    public Transform spawnLocation;

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
                    Instantiate(fossilPickups[i], spawnLocation);
                    isGenerated = true;
                    isTaken[i] = true;
                }
                else if (fossilGenerated == fossilsGenerated[i])
                {
                    fossilGenerated = Random.Range(0, 17);

                }
            }
        }
    }
   
}
