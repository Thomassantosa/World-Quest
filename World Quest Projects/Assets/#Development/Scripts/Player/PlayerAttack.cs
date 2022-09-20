using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon weapon;
    private TypeWeapon typeWeapon;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Attack()
    {
        switch (typeWeapon)
        {
            case TypeWeapon.MELEE:
                AttackMelee();
                break;
            case TypeWeapon.RANGE:
                AttackRange();
                break;
            default:
                break;
        }
    }

    private void AttackMelee()
    {
        Debug.Log("Damage : " + weapon.GetDamage());
    }

    private void AttackRange()
    {

    }
}

public enum TypeWeapon
{
    MELEE,
    RANGE
}