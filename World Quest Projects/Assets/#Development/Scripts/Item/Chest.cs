using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public SpriteRenderer spRender;
    public Sprite spOpen;
    public bool isOpen;
    public GameObject[] spawnItems;
    public GameObject effectOpen;

    public void OpenChest()
    {
        if (isOpen) return;

        isOpen = true;
        spRender.sprite = spOpen;
        SpawnItems();
        Instantiate(
            effectOpen,
            transform.position,
            Quaternion.identity);
    }
    public void SpawnItems()
    {
        for (int i = 0; i < spawnItems.Length; i++)
        {
            Instantiate(
                spawnItems[i].gameObject,
                transform.position,
                Quaternion.identity);
        }
    }
}
