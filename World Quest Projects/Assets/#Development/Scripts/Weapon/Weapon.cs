using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    public TypeWeapon typeWeapon;
    public int damage;

    public Animator anim;


    private bool isActive;

    public int GetDamage()
    {
        return damage;
    }

    public void SetIsActive(bool con)
    {
        isActive = con;
    }

    abstract public void Attack();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (!isActive)
            {
                collision.GetComponent<PlayerAttack>().GetWeapon(this);
            }
        }
    }

}

