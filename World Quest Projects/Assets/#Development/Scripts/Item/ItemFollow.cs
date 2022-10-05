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
    void Start()
    {
        
    }

    void Update()
    {

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
        transform.position = Vector3.MoveTowards(transform.position, playerObject.transform.position, speed*Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
