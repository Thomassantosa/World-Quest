using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public TriggerArea triggerArea;
    public int numOfEnemy;

    public void EnemyDie()
    {
        numOfEnemy--;
        GameManager.instance.EnemyDie();

        if (numOfEnemy <= 0)
            triggerArea.AreaDone();
    }
}
