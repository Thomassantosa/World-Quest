using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public bool isCanvasMainMenu;

    [Header("Panel")]
    public GameObject panelSetting;
    public GameObject panelLoading;
    public PanelMassage panelMassage;
    public GameObject panelLose;
    public GameObject panelWin;

    public Button buttonDialog;
    public ButtonCooldown buttonAttack;
    public Button buttonChange;
    public ButtonCooldown buttonDash;
    public ButtonCooldown buttonSkill;

    [Header("Player")]
    public CanvasPlayer canvasPlayer;
    public ButtonDPad dPadTop;
    public ButtonDPad dPadBottom;
    public ButtonDPad dPadLeft;
    public ButtonDPad dPadRight;

    private void Start()
    {
        if (isCanvasMainMenu) return;

        buttonChange.onClick.AddListener(PlayerControl.Instance.playerAttack.ChangeWeapon);

        buttonAttack.onCooldownStart.AddListener(PlayerControl.Instance.playerAttack.Attack);
        buttonAttack.timeCooldown = GameManager.instance.player.playerData.attackCooldown;

        buttonDash.onCooldownStart.AddListener(PlayerControl.Instance.playerData.PlayerDashTrue);
        buttonDash.timeCooldown = GameManager.instance.player.playerData.dashCooldown;


        buttonSkill.onCooldownStart.AddListener(PlayerControl.Instance.playerData.PlayerSkillTrue);
        buttonSkill.timeCooldown = GameManager.instance.player.playerData.skillCooldown;
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

    public void PanelLoading(bool con)
    {
        panelLoading.SetActive(con);
    }
    public void PanelSetting(bool con)
    {
        panelSetting.SetActive(con);
    }
    public void PanelLose(bool con)
    {
        panelLose.SetActive(con);
    }
    public void PanelWin(bool con)
    {
        panelWin.SetActive(con);
    }
    public void PanelMassage(bool con, string stringMassage = "")
    {
        panelMassage.gameObject.SetActive(con);
        if(con) panelMassage.SetText(stringMassage);
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


    public void UpdateHUDPlayer(PlayerControl player)
    {
        //if (player.playerData.IsDash())
        //buttonDash.GetComponent<Image>().fillAmount = player.playerData.getd
/*
        if (isDash)
        {
            isDash = false;
            if (_dashCooldown <= 0 && _dashTime <= 0)
            {
                Debug.LogWarning("Note: Tambahin Biar Imun Waktu Dash");

                player.playerData.SetPlayerDash(true);
            }
        }

        if (_dashTime > 0)
        {
            _dashTime -= Time.deltaTime;

            if (_dashTime <= 0)
            {
                player.playerData.SetPlayerDash(false);
            }
        }

        if (_dashCooldown > 0)
        {
            _dashCooldown -= Time.deltaTime;
        }*/
    }
}
