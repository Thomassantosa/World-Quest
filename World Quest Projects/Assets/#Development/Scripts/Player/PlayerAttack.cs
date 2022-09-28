using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform handLeft;
    public Transform handRight;

    public Weapon[] listWeapon;
    public Weapon weaponActive;
    private TypeWeapon typeWeapon;

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
        weaponActive.transform.up = moveDirect;
    }

    public void Attack()
    {
        weaponActive.Attack();
    }

    public void ChangePosHandGrap(GrabHand hand)
    {
        switch (hand)
        {
            case GrabHand.LEFT:
                weaponActive.transform.position = handLeft.position;
                break;
            case GrabHand.RIGHT:
                weaponActive.transform.position = handRight.position;
                break;
            default:
                break;
        }
    }

}

public enum TypeWeapon
{
    MELEE,
    RANGE
}

public enum GrabHand
{
    LEFT,
    RIGHT
}