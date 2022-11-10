using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : EnemyControl
{
    public EnemyTower enemyTower;

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

        enemyTower.enabled = targetPlayer != null;
    }

    public override void UpdateMovementTarget()
    {
        /*if (Vector3.Distance(transform.position, targetPlayer.position) < minDistance)
        {
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
                    }*/

        if (Vector3.Distance(transform.position, targetPlayer.position) > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            IdleIsTrue();
            //enemyAttack.Attack();
        }

        

    }
}
