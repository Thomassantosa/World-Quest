using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMelee : Weapon
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public override void Attack()
    {
        Debug.Log("Attack Melee");
        PlayAnimHit();
    }

    private void PlayAnimHit()
    {
        if(PlayerControl.Instance.isFaceRight)
            anim.Play("weapon_melee_attack_right");
        else
            anim.Play("weapon_melee_attack_left");
    }
}
