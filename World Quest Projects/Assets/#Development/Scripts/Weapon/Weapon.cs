using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    public TypeUser typeUser;
    public TypeAttack typeWeapon;
    public int damage;
    //[SerializeField] protected float cooldownAttack;

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

    public void WeaponActive()
    {
        colliderWeapon.enabled = true;
    }

    public void WeaponDeactive()
    {
        Debug.Log("Matiin colider");
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
                WeaponDeactive();
            }
        }
        else
        {


            if (collision.gameObject.tag.Equals("Enemy"))
            {
                if (typeUser == TypeUser.ENEMY) return;

                /*EnemyControl enemy = collision.GetComponent<EnemyControl>();
                if (enemy == null) return;

                enemy.GetDamage(damage);*/
                Debug.Log("Hit " + collision.name);

                EnemyControl enemy = collision.gameObject.GetComponent<EnemyControl>();
                if (enemy == null)
                {
                    EnemyTower enemyTower = collision.gameObject.GetComponent<EnemyTower>();
                    if (enemyTower != null)
                    {
                        enemyTower.GetDamage(damage);
                    }
                    return;
                }
                enemy.GetDamage(damage);
            }
            if (collision.gameObject.tag.Equals("Player"))
            {
                if (typeUser == TypeUser.PLAYER) return;

                collision.GetComponent<PlayerControl>().GetDamage(damage);

            }
        }
    }

}

