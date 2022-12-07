using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIItemQuest : MonoBehaviour
{
    public TextMeshProUGUI textQuest;
    private void OnEnable()
    {
        if (GameManager.instance.haveQuest == 0)
        {
            textQuest.gameObject.SetActive(false);
        }
        else if (GameManager.instance.haveQuest == 1)
        {
            textQuest.gameObject.SetActive(true);
            textQuest.text = "1. attack all the goblins surrounding the guild";
        }
        else
        {
            textQuest.gameObject.SetActive(true);
            textQuest.text = "1. attack all the goblins surrounding the guild (DONE)";
        }
    }
}
