using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    public TypeWeapon typeWeapon;
    public int damage;

    public int GetDamage()
    {
        return damage;
    }


    abstract public void Attack();
}

