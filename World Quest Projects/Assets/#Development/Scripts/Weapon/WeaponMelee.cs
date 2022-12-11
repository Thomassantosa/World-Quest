using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon
{
    public TypeMelee typeMelee;
    [SerializeField] private float durationAttack;
    //private bool isAttacking;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public override void Attack(int dmgPlayer)
    {
        audioSource.PlayOneShot(sfxAttack);

        damagePlayer = dmgPlayer;

        colliderWeapon.enabled = true;
        Invoke(nameof(TurnOffCollider), durationAttack);
        //Invoke(nameof(CooldownDone), cooldownAttack);

        switch (typeMelee)
        {
            case TypeMelee.SWORD:
                anim.Play("Attack_Sword");
                break;
            case TypeMelee.AXE:
                anim.Play("Attack_Axe");
                break;
            case TypeMelee.SPEAR:
                anim.Play("Attack_Spear");
                break;
        }

    }

/*    public void CooldownDone()
    {
        isAttacking = false;
    }*/

    private void TurnOffCollider()
    {
        colliderWeapon.enabled = false;
    }
}

public enum TypeMelee
{
    SWORD,
    AXE,
    SPEAR
}
