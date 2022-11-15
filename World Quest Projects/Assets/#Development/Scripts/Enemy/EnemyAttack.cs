using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform posHand;

    public Weapon weaponActive;

    public void UpdateRotationWeapon(Vector3 moveDirect)
    {
        if (!weaponActive)
            return;

        Vector3 rotation = moveDirect - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //weaponActive.transform.eulerAngles = new Vector3(0, 0, rotZ);
        weaponActive.transform.rotation = Quaternion.Euler(0, 0, rotZ);
        //weaponActive.transform.up = moveDirect;
    }

    public void Attack()
    {
        if (!weaponActive)
            return;

        weaponActive.Attack();
    }

    public void SetWeapon(Weapon weapon)
    {
        weapon.gameObject.SetActive(true);

        weapon.transform.position = posHand.position;
        weaponActive = weapon;
    }
}
