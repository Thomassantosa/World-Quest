using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform posHand;

    public Weapon weaponActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            Attack();
    }

    public void UpdateRotationWeapon(Vector2 moveDirect)
    {
        if (!weaponActive)
            return;

        weaponActive.transform.up = moveDirect;
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
