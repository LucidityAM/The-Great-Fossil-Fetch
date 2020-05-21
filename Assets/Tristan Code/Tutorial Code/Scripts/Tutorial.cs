using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Tutorial : MonoBehaviour
{
    [TextArea(3, 10)]
    public string[] sentences;
    public string headerText;
}
