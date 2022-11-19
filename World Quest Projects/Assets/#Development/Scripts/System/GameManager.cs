using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CanvasManager canvas;


    public PlayerControl player;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

}
