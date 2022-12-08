using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyControl
{
    public float cooldownAttack;
    private bool waitingForAttack;
    private float distance;
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
        distance = Vector3.Distance(transform.position, targetPlayer.position);
        /*        Vector2 direction = targetPlayer.position - transform.position;
                direction.Normalize();
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        */
        if (waitingForAttack) return;

        if (distance > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
            //transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }else
        {
            waitingForAttack = true;
            Invoke(nameof(ReadyForAttack), Random.Range(cooldownAttack, cooldownAttack * 2));
        }

    }

    private void ReadyForAttack()
    {
        enemyAttack.Attack();
        IdleIsTrue();
        waitingForAttack = false;
    }

}
