using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeMode : MonoBehaviour
{
    public static bool safeMode;

  
    public void SafeOn()
    {
        safeMode = true;
    }

    public void SafeOff()
    {
        safeMode = false;
    }
}
