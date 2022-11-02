using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [Header("Panel")]
    public GameObject panelSetting;
    public GameObject panelLoading;

    public Button buttonDialog;
    public Button buttonAttack;

    [Header("Movement")]
    public ButtonDPad dPadTop;
    public ButtonDPad dPadBottom;
    public ButtonDPad dPadLeft;
    public ButtonDPad dPadRight;


    void Start()
    {
        
    }

    public void SetButtonDialog(NPCControl nPCControl)
    {
        buttonAttack.gameObject.SetActive(false);
        buttonDialog.gameObject.SetActive(true);
        buttonDialog.onClick.AddListener(nPCControl.ShowPanelDialog);
    }
    public void CloseButtonDialog()
    {
        buttonDialog.onClick.RemoveAllListeners();
        buttonDialog.gameObject.SetActive(false);
        buttonAttack.gameObject.SetActive(true);
    }

    public void ChangeSceneMainMenu()
    {
        PanelLoading(true);
        ManagerScene.instance.ChangeSceneDelay("MainMenu");
    }

    public void PanelLoading(bool con)
    {
        panelLoading.SetActive(con);
    }
    public void PanelSetting(bool con)
    {
        panelSetting.SetActive(con);
    }

    public void SetDPad(float valX, float valY)
    {
        if ((valX > -0.1f && valX < 0.1f) && (valY > -0.1f && valY < 0.1f))
        {
            dPadTop.ButtonIsClick(false);
            dPadBottom.ButtonIsClick(false);
            dPadLeft.ButtonIsClick(false);
            dPadRight.ButtonIsClick(false);
            return;
        }

        if (valX > 0)
        {
            dPadLeft.ButtonIsClick(false);
            dPadRight.ButtonIsClick(true);
        }
        else if (valX < 0)
        {
            dPadRight.ButtonIsClick(false);
            dPadLeft.ButtonIsClick(true);
        }
        else
        {
            dPadLeft.ButtonIsClick(false);
            dPadRight.ButtonIsClick(false);
        }

        if (valY > 0)
        {
            dPadBottom.ButtonIsClick(false);
            dPadTop.ButtonIsClick(true);
        }
        else if (valY < 0)
        {
            dPadTop.ButtonIsClick(false);
            dPadBottom.ButtonIsClick(true);
        }
        else
        {
            dPadTop.ButtonIsClick(false);
            dPadBottom.ButtonIsClick(false);
        }
    }
}
