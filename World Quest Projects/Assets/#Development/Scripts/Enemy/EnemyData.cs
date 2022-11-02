using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : PlayerData
{
    [Header("Data Enemy")]
    [SerializeField] private float timeIdle;
    private TypeEnemy typeEnemy;
    private LevelEnemy levelEnemy;

    public float GetTimeIdle()
    {
        return timeIdle;
    }

    public void SetTypeEnemy(TypeEnemy typeEnemy)
    {
        this.typeEnemy = typeEnemy;
    }
    public TypeEnemy GetTypeEnemy()
    {
        return typeEnemy;
    }

    public void SetLevelEnemy(LevelEnemy levelEnemy)
    {
        this.levelEnemy = levelEnemy;
    }
    public LevelEnemy GetLevelEnemy()
    {
        return levelEnemy;
    }
}

public enum TypeEnemy
{
    MELEE,
    RANGE
}

public enum LevelEnemy
{ 
    EASY,
    MEDIUM,
    HARD
}

