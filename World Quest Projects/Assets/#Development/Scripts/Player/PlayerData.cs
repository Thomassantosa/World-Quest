using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private int healthPoint;
    [SerializeField] private int manaPoint;
    [SerializeField] private int damage;
    [Header("Movement")]
    [SerializeField] private float normalSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashSpeed;
    public float dashTime;
    public float dashCooldown;
    private float _dashTime;
    private bool isDash;

    public float attackCooldown;

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
    public void SetMovementSpeed(float movementSpeed)
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
    public float GetNormalSpeed()
    {
        return normalSpeed;
    }

    public int GetHealthPoint()
    {
        return healthPoint;
    }

    public int GetManaPoint()
    {
        return manaPoint;
    }

    private void Update()
    {
        if (isDash)
        {
            if (_dashTime > 0)
            {
                _dashTime -= Time.deltaTime;

                if (_dashTime <= 0)
                {
                    PlayerDashFalse();
                }
            }
        }
    }

   
    public void PlayerDashTrue()
    {
        _dashTime = dashTime;
        movementSpeed = dashSpeed;
        isDash = true;
    }
    public void PlayerDashFalse()
    {
        _dashTime = 0;
        movementSpeed = normalSpeed;
        isDash = false;
    }
}
