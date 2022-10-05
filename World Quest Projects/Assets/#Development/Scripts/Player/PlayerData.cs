using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int healthPoint;
    [SerializeField] private int manaPoint;

    [SerializeReference] private float movementSpeed;

    public void SetHealthPoint(int healthPoint)
    {
        this.healthPoint = healthPoint;
    }

    public void SetManaPoint(int manaPoint)
    {
        this.manaPoint = manaPoint;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public int GetHealthPoint()
    {
        return healthPoint;
    }

    public int GetManaPoint()
    {
        return manaPoint;
    }
}
