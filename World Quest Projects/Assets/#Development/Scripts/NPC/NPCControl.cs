using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCControl : MonoBehaviour
{
    public GameObject canvasDialog;
    public TMP_Text textDialog;
    public string dialogNPC;

    void Start()
    {
        
    }

    public void ShowPanelDialog()
    {
        canvasDialog.SetActive(true);
        textDialog.text = dialogNPC;
    }
}
