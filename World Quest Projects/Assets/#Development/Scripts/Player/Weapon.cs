using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public TypeWeapon typeWeapon;
    public int damage;

    public int GetDamage()
    {
        return damage;
    }
}

