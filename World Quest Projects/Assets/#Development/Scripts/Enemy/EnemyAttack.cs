using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform handLeft;
    public Transform handRight;

    public Weapon weaponActive;

    void Start()
    {

    }

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

    public void ChangePosHandGrap(GrabHand hand)
    {
        if (!weaponActive)
            return;

        switch (hand)
        {
            case GrabHand.LEFT:
                weaponActive.transform.parent = handLeft;
                weaponActive.transform.position = handLeft.position;
                break;
            case GrabHand.RIGHT:
                weaponActive.transform.parent = handRight;
                weaponActive.transform.position = handRight.position;
                break;
            default:
                break;
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        weapon.gameObject.SetActive(true);

        weapon.transform.position = handRight.position;
        weaponActive = weapon;
    }
}
