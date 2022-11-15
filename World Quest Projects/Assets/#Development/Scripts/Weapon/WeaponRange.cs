using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRange : Weapon
{
    public TypeRange typeRange;

    public Transform posShot;
    public Bullet bullet;
    public float speedBullet;

    public override void Attack()
    {
        Debug.Log("Attack Range");
        switch (typeRange)
        {
            case TypeRange.BOW:
                break;
            case TypeRange.MAGIC:
                break;
        }

        bullet.SetDamage(damage);
        GameObject newBullet = Instantiate(bullet.gameObject, posShot.position, posShot.rotation);
        Bullet scriptBullet = newBullet.GetComponent<Bullet>();
        scriptBullet.typeUser = typeUser;

        newBullet.GetComponent<Rigidbody2D>().AddForce(posShot.up * speedBullet, ForceMode2D.Impulse);
    }
}
public enum TypeRange
{
    BOW,
    MAGIC
}