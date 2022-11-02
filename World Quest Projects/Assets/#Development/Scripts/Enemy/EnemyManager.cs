using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public EnemyPath[] enemyPaths;

    private void Awake()
    {
        instance = this;   
    }

    void Start()
    {
        
    }

}
