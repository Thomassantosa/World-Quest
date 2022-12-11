using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBack : MonoBehaviour
{
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenPanelQuit();
            return;
        }
#else
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                OpenPanelQuit();
                return;
            }
        }
#endif
    }
    public void OpenPanelQuit()
    {
        GameManager.instance.canvas.ShowPanelQuit();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
