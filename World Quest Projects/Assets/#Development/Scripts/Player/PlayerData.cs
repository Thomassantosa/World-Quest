using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private int healthPoint;
    [SerializeField] private int manaPoint;
    [SerializeField] private int damage;
    [SerializeReference] private float normalSpeed;
    [SerializeReference] private float movementSpeed;


    [SerializeReference] private float dashSpeed;
    [SerializeReference] private float dashTime;
     private float _dashTime;
    [SerializeReference] private float dashCooldown;
    private float _dashCooldown;
    private bool isDash;

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

    public void SetDash(bool con)
    {
        isDash = con;
    }



    private void Update()
    {
        
        if(isDash)
        {
            isDash = false;
            if (_dashCooldown <= 0 && _dashTime <= 0)
            {
                Debug.LogWarning("Note: Tambahin Biar Imun Waktu Dash");
                movementSpeed = dashSpeed;
                _dashTime = dashTime;
            }
        }

        if(_dashTime > 0)
        {
            _dashTime -= Time.deltaTime;

            if(_dashTime <= 0)
            {
                movementSpeed = normalSpeed;
                _dashCooldown = dashCooldown;
            }
        }

        if(_dashCooldown > 0)
        {
            _dashCooldown -= Time.deltaTime;
        }

    }
}
