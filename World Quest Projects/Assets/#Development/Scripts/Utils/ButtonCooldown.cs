using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonCooldown : MonoBehaviour
{
    public Button button;
    public Image image;

    public float timeCooldown;
    private float _timeCooldown;
    private bool isCooldown;

    public UnityEvent onCooldownStart;
   // public UnityEvent onCooldownDone;

    private void Start()
    {
        button.onClick.AddListener(StartCooldown);
    }
    public void StartCooldown()
    {
        onCooldownStart?.Invoke();
        isCooldown = true;
        _timeCooldown = 0;
        button.interactable = false;
    }

    void Update()
    {
        if (isCooldown)
        {
            if (_timeCooldown < timeCooldown)
            {
                _timeCooldown += Time.deltaTime;
                image.fillAmount = _timeCooldown / timeCooldown;
            }
            else
            {
                //onCooldownDone?.Invoke();
                isCooldown = false;
                image.fillAmount = 1;
            }
        }
        else
            button.interactable = true;
    }
}
