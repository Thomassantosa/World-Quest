using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public SoundSFX sfx;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SoundManager.instance.PlaySFX(sfx);
        });
    }
}
