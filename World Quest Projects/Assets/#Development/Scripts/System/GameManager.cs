using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CanvasManager canvas;
    public PlayerControl player;
    [Header("GamePlay")]
    public bool isGamePlay;
    public int numOfEnemy;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    public void EnemyDie()
    {
        numOfEnemy--;
        if(numOfEnemy <= 0)
        {
            Debug.Log("Game Selesai");
        }
    }

}
