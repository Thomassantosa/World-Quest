using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCControl : MonoBehaviour
{
    public TypeNPC type;
    public GameObject canvasPanel;
    [Header("Change Scene")]
    public string nameScene;
    [Header("NPC Dialog")]
    public TMP_Text textDialog;
    public string dialogNPC;

    [SerializeField] private float timeDisplay;
    private float timeCounter;
    private bool isDialogNPC;
    void Start()
    {
        
    }
    private void Update()
    {
        if (!isDialogNPC) return;

        if (timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
            canvasPanel.SetActive(true);
        }
        else
        {
            canvasPanel.SetActive(false);
        }
    }

    public void ShowPanelDialog()
    {
        switch (type)
        {
            case TypeNPC.DIALOG:
                textDialog.text = dialogNPC;
                timeCounter = timeDisplay;
                isDialogNPC = true;
                break;
            case TypeNPC.PANEL:
                canvasPanel.SetActive(true);
                break;
            case TypeNPC.DOOR:
                if (GameManager.instance.haveQuest == 0)
                {
                    GameManager.instance.canvas.PanelMassage(true, "you don't have a quest");
                }
                else
                {
                    ManagerScene.instance.ChangeSceneDelay(nameScene);
                }
                break;
            default:
                break;
        }

        
        
    }
}

public enum TypeNPC
{
    DIALOG,
    PANEL,
    DOOR
}
