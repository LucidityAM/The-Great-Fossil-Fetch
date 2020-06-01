using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryWeapons : MonoBehaviour
{
    public RectTransform[] inventorySpace = new RectTransform[18];
    public GameObject[] InventoryBlocks = new GameObject[18];

    public RectTransform[] librarySpaces = new RectTransform[18];

    void Awake()
    {
        for (int i = 0; i < inventorySpace.Length; i++)
        {
            inventorySpace[i] = InventoryBlocks[i].GetComponent<RectTransform>();

        }//Gets a specific game object in an array and grabs its RectTransform to assign it to another array where inventory fossils will be assigned
    }
}
