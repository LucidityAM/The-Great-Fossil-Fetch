using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHovering : MonoBehaviour
{
    public Text text;
    public Text text2;

    public GameObject bg;
    public Shadow shadow;

    public byte[] rgbaOpen = new byte[4];
    public byte[] rgba2Open = new byte[4];
    public byte[] rgbaClose = new byte[4];
    public byte[] rgba2Close = new byte[4];

    // Start is called before the first frame update
    void Start()
    {
        bg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        if (text != null) { text.color = new Color32(rgbaOpen[0], rgbaOpen[1], rgbaOpen[2], rgbaOpen[3]); }

        if (text2 != null) { text2.color = new Color32(rgba2Open[0], rgba2Open[1], rgba2Open[2], rgba2Open[3]); }

        bg.SetActive(true);

        if (shadow != null) { shadow.enabled = false; }
    }

    public void Close()
    {
        if (text != null) { text.color = new Color32(rgbaClose[0], rgbaClose[1], rgbaClose[2], rgbaClose[3]); }

        if (text2 != null) { text2.color = new Color32(rgba2Close[0], rgba2Close[1], rgba2Close[2], rgba2Close[3]); }

        bg.SetActive(false);

        if (shadow != null) { shadow.enabled = true; }
    }

}
