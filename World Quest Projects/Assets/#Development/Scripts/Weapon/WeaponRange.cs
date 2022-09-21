using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : Weapon
{
    public Transform posShot;
    public Bullet bullet;
    public float speedBullet;

    public override void Attack()
    {
        Debug.Log("Attack Range");

        bullet.SetDamage(damage);
        GameObject newBullet = Instantiate(bullet.gameObject, posShot.position, posShot.rotation);
        newBullet.GetComponent<Rigidbody2D>().AddForce(posShot.up * speedBullet, ForceMode2D.Impulse);
    }
}
