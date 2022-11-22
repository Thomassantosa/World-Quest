using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool isPlayer;
    [Header("Main Data")]
    [SerializeField] private int healthPoint;
    [SerializeField] private int manaPoint;
    [SerializeField] private int exPoint;
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

    [Header("Level")]
    [SerializeField] private int level;
    [SerializeField] private int maxExp;
    [SerializeField] private int incrementExp;

    public void SetHealthPoint(int healthPoint)
    {
        Debug.Log("Get HP");
        if (healthPoint >= 100) healthPoint = 100;
        this.healthPoint = healthPoint;

        if(isPlayer) GameManager.instance.canvas.canvasPlayer.SetHP(healthPoint);
    }

    public void SetManaPoint(int manaPoint)
    {
        if (manaPoint >= 100) manaPoint = 100;
        this.manaPoint = manaPoint;
        if (isPlayer) GameManager.instance.canvas.canvasPlayer.SetMP(manaPoint);
    }
    public void SetExp(int exPoint)
    {
        if (exPoint >= maxExp)
        {
            exPoint = 0;
            maxExp += incrementExp;
            level++;
        }
        this.exPoint = exPoint;
        if (isPlayer) GameManager.instance.canvas.canvasPlayer.SetEXP(level,exPoint, maxExp);
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
    public int GetExPoint()
    {
        return exPoint;
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
