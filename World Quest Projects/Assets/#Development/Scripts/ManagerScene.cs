using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerScene : MonoBehaviour
{
    public static ManagerScene instance;

    [SerializeField] private float timeDelay;
    private string nameScene;
    public void Awake()
    {
        instance = this;
    }


    public void ChangeSceneDelay(string nameScene)
    {
        this.nameScene = nameScene;
        Invoke(nameof(ChangeScene), timeDelay);
    }


    public void ChangeScene()
    {
        SceneManager.LoadScene(nameScene);
    }


}
