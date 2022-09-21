using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon[] listWeapon;
    public Weapon weaponActive;
    private TypeWeapon typeWeapon;

    void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void UpdateRotationWeapon(Vector2 moveDirect)
    {
        weaponActive.transform.up = moveDirect;
    }

    public void Attack()
    {
        weaponActive.Attack();
    }

}

public enum TypeWeapon
{
    MELEE,
    RANGE
}