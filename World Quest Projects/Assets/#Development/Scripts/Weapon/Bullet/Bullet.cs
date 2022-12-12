using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public TypeUser typeUser;
    public int damage;

    public GameObject effectDestroy;
    private void Start()
    {
        Invoke(nameof(DestroyBullet), 3);
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (typeUser == TypeUser.PLAYER) return;
            PlayerControl player = collision.gameObject.GetComponent<PlayerControl>();
            player.GetDamage(damage);
            DestroyBullet();
        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {

            if (typeUser == TypeUser.ENEMY) return;
            Debug.Log("Enemy");
            EnemyControl enemy = collision.gameObject.GetComponent<EnemyControl>();
            if (enemy == null)
            {
                EnemyTower enemyTower = collision.gameObject.GetComponent<EnemyTower>();
                if(enemyTower != null)
                {
                    Debug.Log("Dmg Tower");
                    enemyTower.GetDamage(damage);
                    DestroyBullet();
                }
                else
                {
                    BossControl bossControl = collision.gameObject.GetComponent<BossControl>();
                    if(bossControl != null)
                    {
                        Debug.Log("Dmg Bos");
                        bossControl.GetDamage(damage);
                        DestroyBullet();
                    }
                }
                return;
            }
            Debug.Log("Dmg Enemy");
            enemy.GetDamage(damage);
            DestroyBullet();
            return;
        }
        if (collision.gameObject.tag.Equals("Chest"))
        {
            Chest chest = collision.gameObject.GetComponent<Chest>();
            chest.OpenChest();
        }
        if (!collision.gameObject.tag.Equals("Weapon"))
            DestroyBullet();
    }

    public void DestroyBullet()
    {
        Instantiate(effectDestroy, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }    
}
