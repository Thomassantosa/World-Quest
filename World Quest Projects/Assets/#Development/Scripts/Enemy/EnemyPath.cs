using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private Transform[] listPath;
    [SerializeField] private float extraRangeX;
    [SerializeField] private float extraRangeY;


    public Vector3 GetRandomPath()
    {
        int idx = Random.Range(0, listPath.Length);
        Vector3 newPos = new Vector3(
            listPath[idx].position.x + Random.Range(-extraRangeX,extraRangeX),
            listPath[idx].position.y + Random.Range(-extraRangeY, extraRangeY));
        return newPos;
    }
}
