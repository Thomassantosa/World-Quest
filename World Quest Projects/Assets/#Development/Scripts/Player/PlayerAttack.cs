using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform posHand;

    public Weapon[] listWeapon;
    public Weapon weaponActive;
    private int weaponCount;


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

        weaponActive = weapon;
        weaponActive.transform.position = posHand.position;
        weaponActive.transform.parent = posHand;
    }

    public void GetWeapon(Weapon weapon)
    {
        if (weaponCount < 2)
        {
            if (listWeapon[0] == null)
            {
                listWeapon[0] = weapon;
                weaponActive = weapon;
                SetWeapon(weapon);
            }
            else if (listWeapon[1] == null)
            {
                listWeapon[1] = weapon;
                weapon.gameObject.SetActive(false);
            }

            weapon.SetIsActive(true);
            weaponCount++;
        }
    }

    public void DropWeapon(Weapon weapon)
    {
        if(weaponCount > 0)
        {
            for (int i = 0; i < 2; i++)
            {
                if (listWeapon[i] == null)
                    continue;

                if(listWeapon[i] == weapon)
                {
                    listWeapon[i].SetIsActive(true);
                    listWeapon[i] = null;
                    weaponCount--;
                    break;
                }
            }
        }
    }

    public void ChangeWeapon()
    {
        if (weaponCount >= 2)
        {
            if (listWeapon[0] == weaponActive)
            {
                listWeapon[0].SetIsActive(false);
                listWeapon[0].gameObject.SetActive(false);

                SetWeapon(listWeapon[1]);
            }
            else
            {
                listWeapon[1].SetIsActive(false);
                listWeapon[1].gameObject.SetActive(false);

                SetWeapon(listWeapon[0]);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Dash();
    }
    public void Dash()
    {
        PlayerControl.Instance.playerData.SetDash(true);
    }
}

