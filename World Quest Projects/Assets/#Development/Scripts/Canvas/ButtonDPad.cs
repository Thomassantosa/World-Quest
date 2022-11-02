using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDPad : MonoBehaviour
{
    public Image imageButton;
    public Sprite spriteDefault;
    public Sprite spriteOnClick;

    public void ButtonIsClick(bool con)
    {
        if (con)
            imageButton.sprite = spriteOnClick;
        else
            imageButton.sprite = spriteDefault;
    }
}
