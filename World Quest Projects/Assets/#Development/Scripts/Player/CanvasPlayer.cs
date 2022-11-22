using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasPlayer : MonoBehaviour
{
    public Slider sliderHP;
    public TextMeshProUGUI textHP;
    public Slider sliderMP;
    public TextMeshProUGUI textMP;
    public Slider sliderEXP;
    public TextMeshProUGUI textEXP;
    void Start()
    {
        
    }

    public void SetHP(int val)
    {
        sliderHP.value = val;
        textHP.text = $"{val}/100";
    }

    public void SetMP(int val)
    {
        sliderMP.value = val;
        textMP.text = $"{val}/100";
    }
    public void SetEXP(int val, int maxLevel)
    {
        sliderEXP.maxValue = maxLevel;
        sliderEXP.value = val;
        textEXP.text = $"{val}/{maxLevel}";
    }
}
