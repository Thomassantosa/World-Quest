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
            RefreshCoin();
        }
    }


    [Header("Quest")]
    public int haveQuest;
    public bool gameFinish;

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
            canvas.PanelMassage(true, "goblin boss is coming, hurry back to the guild!");
            SpawnBoss();
        }
    }

    public void SpawnBoss()
    {
        SoundManager.instance.PlayMusic(SoundMusic.MUSIC_BOSS);
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
    public void ResetQuest()
    {
        haveQuest = 0;
        PlayerPrefs.SetInt("QUEST", 0);
    }

    public void RefreshCoin()
    {
        canvas.SetTextCoin(Coin);
    }
}
