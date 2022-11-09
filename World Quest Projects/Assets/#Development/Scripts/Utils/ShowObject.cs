using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    public float timeShow;
    public GameObject theObject;

    void Start()
    {
        Invoke(nameof(ShowObject), timeShow);
    }

    public void ShowGameObject()
    {
        theObject.SetActive(true);
    }
}
