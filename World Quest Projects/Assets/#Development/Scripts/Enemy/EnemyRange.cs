using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyControl
{
    bool run;
    float counterRun;
    private void Start()
    {
        Init();
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateMovement();
        UpdateRotationWeapon();
    }

    public override void UpdateMovementTarget()
    {
        if (Vector3.Distance(transform.position, targetPlayer.position) < minDistance)
        {
            Debug.Log("Cek Move");
            if (run)
            {
                counterRun += Time.deltaTime;
                if(counterRun >= 1)
                {
                    run = false;
                    counterRun = 3;
                }

                transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * -1 * Time.deltaTime);
            }
            else
            {
                counterRun -= Time.deltaTime;
                if(counterRun <= 0)
                {
                    run = true;
                    counterRun = 0;
                }
            }


/*            if(!enemyData.isIdle)
            {
                IdleIsTrue();
            }*/
        }
/*        else
        {
            IdleIsTrue();
        }*/
    }
}
