using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasPlayer : MonoBehaviour
{
    [Header("Health Point")]
    public Slider sliderHP;
    public TextMeshProUGUI textHP;
    [Header("Mana Point")]
    public Slider sliderMP;
    public TextMeshProUGUI textMP;
    [Header("Level")]
    public Slider sliderEXP;
    public TextMeshProUGUI textEXP;
    public TextMeshProUGUI textLevel;
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
    public void SetEXP(int level,int val, int maxLevel)
    {
        textLevel.text = $"LV {level}";
        sliderEXP.maxValue = maxLevel;
        sliderEXP.value = val;
        textEXP.text = $"{val}/{maxLevel}";
    }
}
