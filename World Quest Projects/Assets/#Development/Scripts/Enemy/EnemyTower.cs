using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : PlayerData
{
    public Camera cam;
    [SerializeField] private float adjustRotation;

    [Header("Profile")]
    public TypeUser typeUser;
    public Bullet objectBullet;
    public Transform posShot;
    [SerializeField] private int speedBullet;

    [Header("Idle")]
    [SerializeField] private float cooldownIdle;
    private float _cooldownIdle;

    [Header("Finding Player")]
    public float radiusFindPlayer;
    public LayerMask layerPlayer;
    [SerializeField] private float cooldownShooting;
    private float _cooldownShooting;
    public Transform targetPlayer;
    void Start()
    {
        
    }

    void Update()
    {
        Collider2D isFoundPlayer = Physics2D.OverlapCircle(transform.position, radiusFindPlayer, layerPlayer);

        if (isFoundPlayer != null)
        {
            if (targetPlayer == null)
            {
                FoundPlayer(isFoundPlayer.gameObject);
            }

            ShootingControl();
        }
        else
        {
            SetTargetRandom();
            targetPlayer = null;
        }
    }

    public void FoundPlayer(GameObject objectPlayer)
    {
        targetPlayer = objectPlayer.transform;
    }


    private void ShootingControl()
    {
        SetToTarget();
        if (_cooldownShooting > 0)
            _cooldownShooting -= Time.deltaTime;
        else
        {
            Shooting();
        }
    }
    private void Shooting()
    {
        _cooldownShooting = cooldownShooting;
        objectBullet.SetDamage((int)GetDamage());
        GameObject newBullet = Instantiate(objectBullet.gameObject, posShot.position, posShot.rotation);
        Bullet scriptBullet = newBullet.GetComponent<Bullet>();
        scriptBullet.typeUser = typeUser;
        newBullet.GetComponent<Rigidbody2D>().AddForce(posShot.up * speedBullet, ForceMode2D.Impulse);
    }
    private float rotZ;
    private void SetToTarget()
    {
        Vector3 rotation = targetPlayer.position - transform.position;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ - adjustRotation);

    }

    private void SetTargetRandom()
    {
        if (_cooldownIdle > 0)
        {
            _cooldownIdle -= Time.deltaTime;
        }
        else
        {
            Debug.Log("change");
            _cooldownIdle = cooldownIdle;
            rotZ = Random.Range(0, 360);
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }
    }
    public void GetDamage(int dmg)
    {
        //Test
        int lastHealth = GetHealthPoint() - dmg;
        if (lastHealth > 0)
        {
            SetHealthPoint(lastHealth);
        }
        else
        {
            PlayerControl.Instance.GetExp(5);
            SetHealthPoint(0);
            Destroy(gameObject);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusFindPlayer);
    }

}
