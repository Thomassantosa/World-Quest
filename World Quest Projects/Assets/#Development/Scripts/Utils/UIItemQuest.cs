using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIItemQuest : MonoBehaviour
{
    public GameObject itemQuest;
    private void OnEnable()
    {
        if (GameManager.instance.haveQuest == 0)
        {
            itemQuest.gameObject.SetActive(false);
        }
        else if (GameManager.instance.haveQuest == 1)
        {
            itemQuest.gameObject.SetActive(true);
            //textQuest.text = "1. attack all the goblins surrounding the guild";
        }
        else
        {
            itemQuest.gameObject.SetActive(true);
            //textQuest.text = "1. attack all the goblins surrounding the guild (DONE)";
        }
    }
}
