using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int coin;
    public int Coin
    {
        get { return coin; }
        set
        {
            coin = value;
        }
    }


    [Header("Quest")]
    public int haveQuest;

    [Header("Main")]
    public CanvasManager canvas;
    public PlayerControl player;
    [Header("GamePlay")]
    public bool isGamePlay;
    public int numOfEnemy;
    public GameObject areaBoss;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        haveQuest = 0;
        if (PlayerPrefs.HasKey("QUEST"))
        {
            haveQuest = PlayerPrefs.GetInt("QUEST");
        }
    }

    public void EnemyDie()
    {
        numOfEnemy--;
        if(numOfEnemy <= 0)
        {
            Debug.Log("Game Selesai");//Spawn Boss
            canvas.PanelMassage(true, "Wow!! Good Job, You killing all goblin.");
            SpawnBoss();
        }
    }

    public void SpawnBoss()
    {
        areaBoss.SetActive(true);
    }

    public void GetQuest()
    {
        haveQuest = 1;
        PlayerPrefs.SetInt("QUEST", haveQuest);
    }
    public void FinishQuest()
    {
        haveQuest = 2;
        PlayerPrefs.SetInt("QUEST", haveQuest);
    }
}
