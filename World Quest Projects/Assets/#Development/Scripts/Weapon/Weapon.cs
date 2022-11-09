using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    public TypeUser typeUser;
    public TypeAttack typeWeapon;
    public int damage;

    public Animator anim;
    public BoxCollider2D colliderWeapon;


    public bool isActive;

    public int GetDamage()
    {
        return damage;
    }

    public void SetIsActive(bool con)
    {
        isActive = con;
    }

    public void UseWeapon()
    {
        colliderWeapon.enabled = false;
    }

    abstract public void Attack();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                collision.GetComponent<PlayerAttack>().GetWeapon(this);
                UseWeapon();
            }
        }
        else
        {

            if (typeUser == TypeUser.PLAYER)
            {
                if (collision.gameObject.tag.Equals("Enemy"))
                {
                    collision.GetComponent<EnemyControl>().GetDamage(damage);
                }
            }
            else if (typeUser == TypeUser.ENEMY)
            {
                if (collision.gameObject.tag.Equals("Player"))
                {
                    collision.GetComponent<PlayerControl>().GetDamage(damage);
                }
            }
        }
    }

}

