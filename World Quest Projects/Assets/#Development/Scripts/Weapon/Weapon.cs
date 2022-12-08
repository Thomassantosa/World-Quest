using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    public TypeUser typeUser;
    public TypeAttack typeWeapon;
    public int damage;
    public int damagePlayer;
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

    abstract public void Attack(int dmgPlayer);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Weapon")) return;

        if (!isActive)
        {
            Debug.Log("No Active - Hit " + collision.name);
            if (collision.gameObject.tag.Equals("Player"))
            {
                collision.GetComponent<PlayerAttack>().GetWeapon(this);
                WeaponDeactive();
            }
        }
        else
        {

            Debug.Log("Hit " + collision.name);

            if (collision.gameObject.tag.Equals("Enemy"))
            {
                Debug.Log("Hit Enemy");

                /*EnemyControl enemy = collision.GetComponent<EnemyControl>();
                if (enemy == null) return;

                enemy.GetDamage(damage);*/

                EnemyControl enemy = collision.gameObject.GetComponent<EnemyControl>();
                if (enemy == null)
                {
                    EnemyTower enemyTower = collision.gameObject.GetComponent<EnemyTower>();
                    if (enemyTower != null)
                    {
                        enemyTower.GetDamage(damage + damagePlayer);
                    }
                    else
                    {
                        BossControl bossControl = collision.gameObject.GetComponent<BossControl>();
                        if (bossControl != null)
                        {
                            Debug.Log("Dmg Bos");
                            bossControl.GetDamage(damage);
                        }
                    }
                    return;
                }
                enemy.GetDamage(damage + damagePlayer);
            }
            if (collision.gameObject.tag.Equals("Player"))
            {
                if (typeUser == TypeUser.PLAYER) return;

                collision.GetComponent<PlayerControl>().GetDamage(damage + damagePlayer);

            }
        }
    }

}

