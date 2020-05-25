using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponWatcher : MonoBehaviour
{
    public bool[] isFilled = new bool[18];

    public InventoryWeapons inventoryWeapons;

    public GameObject[] fossils = new GameObject[18];

    public AudioSource pickup;

    private void Start()
    {

        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Level2" || scene.name == "Level3" || scene.name == "FloorClearScreen")
        {
            for(int i = 0; i < 18; i++)
            {
                if (WeaponStats.objectsInSpaces[i] != null)
                {
                    if (WeaponStats.objectsInSpaces[i].tag == "skull1")
                    {
                        Instantiate(fossils[0], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "skull2")
                    {
                        Instantiate(fossils[1], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "skull3")
                    {
                        Instantiate(fossils[2], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "neck1")
                    {
                        Instantiate(fossils[3], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "neck2")
                    {
                        Instantiate(fossils[4], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "neck3")
                    {
                        Instantiate(fossils[5], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "ribs1")
                    {
                        Instantiate(fossils[6], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "ribs2")
                    {
                        Instantiate(fossils[7], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "ribs3")
                    {
                        Instantiate(fossils[8], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "arms1")
                    {
                        Instantiate(fossils[9], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "arms2")
                    {
                        Instantiate(fossils[10], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "arms3")
                    {
                        Instantiate(fossils[11], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "legs1")
                    {
                        Instantiate(fossils[12], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "legs2")
                    {
                        Instantiate(fossils[13], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "legs3")
                    {
                        Instantiate(fossils[14], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "tail1")
                    {
                        Instantiate(fossils[15], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "tail2")
                    {
                        Instantiate(fossils[16], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                    else if (WeaponStats.objectsInSpaces[i].tag == "tail3")
                    {
                        Instantiate(fossils[17], inventoryWeapons.inventorySpace[i], instantiateInWorldSpace: false);
                        isFilled[i] = true;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "skull1")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[0], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 0;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    WeaponStats.fossilsOutOfSpaces[0] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "skull2")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[1], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 1;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    WeaponStats.fossilsOutOfSpaces[1] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "skull3")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[2], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 2;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    WeaponStats.fossilsOutOfSpaces[2] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "neck1")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[3], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 3;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    WeaponStats.fossilsOutOfSpaces[3] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "neck2")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[4], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 4;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    WeaponStats.fossilsOutOfSpaces[4] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "neck3")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[5], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 5;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    WeaponStats.fossilsOutOfSpaces[5] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "ribs1")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[6], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 6;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    WeaponStats.fossilsOutOfSpaces[6] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "ribs2")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[7], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 7;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "ribs3")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[8], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 8;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "arms1")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[9], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 9;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "arms2")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[10], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 10;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
        }
        if (collision.gameObject.tag == "arms3")
        {
            collision.gameObject.SetActive(false);
            for (int i = 0; i < isFilled.Length; i++)
            {
                if (isFilled[i] == false)
                {
                    //pickup.Play();
                    GameObject FossilInstantiate = Instantiate(fossils[11], inventoryWeapons.inventorySpace[i]);
                    FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                    WeaponStats.fossilsInSpaces[i] = 11;
                    WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                    isFilled[i] = true;
                    break;
                }
            }
            if (collision.gameObject.tag == "legs1")
            {
                collision.gameObject.SetActive(false);
                for (int i = 0; i < isFilled.Length; i++)
                {
                    if (isFilled[i] == false)
                    {
                        //pickup.Play();
                        GameObject FossilInstantiate = Instantiate(fossils[12], inventoryWeapons.inventorySpace[i]);
                        FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                        WeaponStats.fossilsInSpaces[i] = 12;
                        WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                        isFilled[i] = true;
                        break;
                    }
                }
            }
            if (collision.gameObject.tag == "legs2")
            {
                collision.gameObject.SetActive(false);
                for (int i = 0; i < isFilled.Length; i++)
                {
                    if (isFilled[i] == false)
                    {
                        //pickup.Play();
                        GameObject FossilInstantiate = Instantiate(fossils[13], inventoryWeapons.inventorySpace[i]);
                        FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                        WeaponStats.fossilsInSpaces[i] = 13;
                        WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                        isFilled[i] = true;
                        break;
                    }
                }
            }
            if (collision.gameObject.tag == "legs3")
            {
                collision.gameObject.SetActive(false);
                for (int i = 0; i < isFilled.Length; i++)
                {
                    if (isFilled[i] == false)
                    {
                        //pickup.Play();
                        GameObject FossilInstantiate = Instantiate(fossils[14], inventoryWeapons.inventorySpace[i]);
                        FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                        WeaponStats.fossilsInSpaces[i] = 14;
                        WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                        isFilled[i] = true;
                        break;
                    }
                }
            }
            if (collision.gameObject.tag == "tail1")
            {
                collision.gameObject.SetActive(false);
                for (int i = 0; i < isFilled.Length; i++)
                {
                    if (isFilled[i] == false)
                    {
                        //pickup.Play();
                        GameObject FossilInstantiate = Instantiate(fossils[15], inventoryWeapons.inventorySpace[i]);
                        FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                        WeaponStats.fossilsInSpaces[i] = 15;
                        WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                        isFilled[i] = true;
                        break;
                    }
                }
            }
            if (collision.gameObject.tag == "tail2")
            {
                collision.gameObject.SetActive(false);
                for (int i = 0; i < isFilled.Length; i++)
                {
                    if (isFilled[i] == false)
                    {
                        //pickup.Play();
                        GameObject FossilInstantiate = Instantiate(fossils[16], inventoryWeapons.inventorySpace[i]);
                        FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                        WeaponStats.fossilsInSpaces[i] = 16;
                        WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                        isFilled[i] = true;
                        break;
                    }
                }
            }
            if (collision.gameObject.tag == "tail3")
            {
                collision.gameObject.SetActive(false);
                for (int i = 0; i < isFilled.Length; i++)
                {
                    if (isFilled[i] == false)
                    {
                        //pickup.Play();
                        GameObject FossilInstantiate = Instantiate(fossils[17], inventoryWeapons.inventorySpace[i]);
                        FossilInstantiate.GetComponent<RectTransform>().anchoredPosition = new Vector2(FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.x + 444f, FossilInstantiate.GetComponent<RectTransform>().anchoredPosition.y);

                        WeaponStats.fossilsInSpaces[i] = 17;
                        WeaponStats.objectsInSpaces[i] = FossilInstantiate;
                        isFilled[i] = true;
                        break;
                    }
                }
            }
        }
    }

}
