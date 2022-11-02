using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyControl
{
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
        if (Vector3.Distance(transform.position, targetPlayer.position) > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
        }
        {
            IdleIsTrue();
            Debug.LogError("Stop");
            enemyAttack.Attack();
        }

    }

}
