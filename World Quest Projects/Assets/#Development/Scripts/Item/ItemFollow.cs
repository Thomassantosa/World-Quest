using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollow : Item
{
    public LayerMask layer;
    public float radius;
    public float speed;

    private bool isDone;
    private GameObject playerObject;

    void Update()
    {
        MoveToTargetDrop();

        if (!canClaim) return;
        if (!isDone)
        {
            CheckPlayer();
        }
        else
        {
            GoToPlayer();
        }
    }
    private void CheckPlayer()
    {
        Collider2D raycastPlayer = Physics2D.OverlapCircle(transform.position, radius, layer);
        if (raycastPlayer != null)
        {
            isDone = true;
            playerObject = raycastPlayer.gameObject;
        }
    }

    private void GoToPlayer()
    {
        if (playerObject == null)
        {
            return;
        }

        Vector2 direction = playerObject.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, speed*Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
