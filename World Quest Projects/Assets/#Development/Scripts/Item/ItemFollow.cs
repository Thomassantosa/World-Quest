using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFollow : Item
{
    public float radius;

    void Start()
    {
        
    }

    void Update()
    {

/*        Collider2D isGround = Physics2D.OverlapCircle(footPos.position, rangeRaycast, layerGround);
        if (isGround != null)*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
