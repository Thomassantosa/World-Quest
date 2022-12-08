using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public GameObject area;
    public GameObject objectLocked;
    public bool isActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (isActive) return;

            isActive = true;
            area.SetActive(true);
            objectLocked.SetActive(true);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void AreaDone()
    {
        objectLocked.SetActive(false);
    }
}
