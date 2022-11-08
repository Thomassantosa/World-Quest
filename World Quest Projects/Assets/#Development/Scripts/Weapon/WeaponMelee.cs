using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon
{
    public TypeMelee typeMelee;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public override void Attack()
    {
        switch (typeMelee)
        {
            case TypeMelee.SWORD:
                anim.Play("Attack_Sword");
                break;
            case TypeMelee.AXE:
                anim.Play("Attack_Axe");
                break;
        }
    }
}

public enum TypeMelee
{
    SWORD,
    AXE
}
