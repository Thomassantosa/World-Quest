using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCControl : MonoBehaviour
{
    public GameObject canvasDialog;
    public TMP_Text textDialog;
    public string dialogNPC;

    [SerializeField] private float timeDisplay;
    private float timeCounter;
    void Start()
    {
        
    }
    private void Update()
    {
        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
            canvasDialog.SetActive(true);
        }
        else
        {
            canvasDialog.SetActive(false);
        }
    }

    public void ShowPanelDialog()
    {
        textDialog.text = dialogNPC;
        timeCounter = timeDisplay;
    }
}
