using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public TypeUser typeUser;
    public int damage;
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (typeUser == TypeUser.PLAYER) return;
            PlayerControl player = collision.gameObject.GetComponent<PlayerControl>();
            player.GetDamage(damage);
        }
        else if (collision.gameObject.tag.Equals("Enemy"))
        {

            if (typeUser == TypeUser.ENEMY) return;
            EnemyControl enemy = collision.gameObject.GetComponent<EnemyControl>();
            if (enemy == null)
            {
                EnemyTower enemyTower = collision.gameObject.GetComponent<EnemyTower>();
                if(enemyTower != null)
                {
                    enemyTower.GetDamage(damage);
                }
                return;
            }
            enemy.GetDamage(damage);
        }
        
        if(!collision.gameObject.tag.Equals("Weapon"))
            Destroy(gameObject);
    }
}
