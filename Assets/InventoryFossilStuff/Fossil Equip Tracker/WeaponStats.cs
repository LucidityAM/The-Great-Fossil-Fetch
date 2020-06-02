using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WeaponStats
{
    public static int skull = 0;
    public static int neck = 0;
    public static int ribs = 0;
    public static int arms = 0;
    public static int legs = 0;
    public static int tail = 0;
    //Whether fossils 1, 2, or 3 of each fossil type is equipped, 0 means no fossil is equipped for that type

    public static int[] fossilsInSpaces = new int[18]; //The number of the fossil in specific spaces

    public static GameObject[] objectsInSpaces = new GameObject[18]; //The specific fossils in the first, second, and so on spaces

    public static int[] fossilDurability = new int [18]; //The durability of all 18 fossils

    public static GameObject[] fossilsOutOfSpaces = new GameObject[18]; //The instantiated fossils so that components can be grabbed from specific fossils

    public static bool isSet;

    public static int fossilGenerated;
}

