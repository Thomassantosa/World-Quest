using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private int healthPoint;
    [SerializeField] private int manaPoint;
    [SerializeField] private int damage;
    [SerializeReference] private float movementSpeed;

    public bool isFaceRight;
    public bool isIdle;
    public void SetHealthPoint(int healthPoint)
    {
        this.healthPoint = healthPoint;
    }

    public void SetManaPoint(int manaPoint)
    {
        this.manaPoint = manaPoint;
    }
    public void SetMovementSpeed(int movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public float GetDamage()
    {
        return damage;
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
