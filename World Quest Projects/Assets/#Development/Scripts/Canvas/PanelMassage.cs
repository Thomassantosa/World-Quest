using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelMassage : MonoBehaviour
{
    public TextMeshProUGUI textMassage;

    public void SetText(string val)
    {
        textMassage.text = val;
    }

    public void ClosePanel()
    {
        textMassage.text = "";
        gameObject.SetActive(false);
    }
}
