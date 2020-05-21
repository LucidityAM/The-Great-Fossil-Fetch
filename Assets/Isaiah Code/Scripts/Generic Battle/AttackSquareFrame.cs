using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackSquareFrame : MonoBehaviour
{
    public Image attackBorder;
    public Image fossilBorder;
    public Image defendBorder;

    public void AttackHover()
    {
        fossilBorder.enabled = false;
        defendBorder.enabled = false;
        attackBorder.enabled = true;
    }

    public void FossilHover()
    {
        fossilBorder.enabled = true;
        defendBorder.enabled = false;
        attackBorder.enabled = false;
    }

    public void DefendHover()
    {
        fossilBorder.enabled = false;
        defendBorder.enabled = true;
        attackBorder.enabled = false;
    }

    public void HoverExit()
    {
        fossilBorder.enabled = false;
        defendBorder.enabled = false;
        attackBorder.enabled = false;
    }
}
