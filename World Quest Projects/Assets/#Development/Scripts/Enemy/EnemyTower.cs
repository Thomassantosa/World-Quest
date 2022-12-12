using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : PlayerData
{
    [Header("Tower")]
    public TypeUser typeUser;
    public Bullet objectBullet;
    public Transform posShot;
    [SerializeField] private int speedBullet;
    [SerializeField] private float adjustRotation;

    [Header("Main Variable")]
    public bool isImmune;

    [Header("Effect")]
    public SpriteRenderer sprite;
    public float durationGetHit;
    private float _durationGetHit; 
    public GameObject effectDie;
    public GameObject spriteDie;

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
        _cooldownShooting = Random.Range(cooldownShooting, cooldownShooting * 2);
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
            //SetTargetRandom();
            targetPlayer = null;
        }

        UpdateEffectHit();
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
        _cooldownShooting = Random.Range(cooldownShooting, cooldownShooting*2);
        objectBullet.SetDamage(GetDamage());
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

        posShot.transform.rotation = Quaternion.Euler(0, 0, rotZ - adjustRotation);

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
        if (isImmune) return;
        EffectHitActive();

        SoundManager.instance.PlaySFX(SoundSFX.SFX_ENEMY_GET_HIT);

        int lastHealth = GetHealthPoint() - dmg;
        if (lastHealth > 0)
        {
            SetHealthPoint(lastHealth);
        }
        else
        {
            Instantiate(effectDie, transform.position, Quaternion.identity);
            Instantiate(spriteDie, transform.position, Quaternion.identity);
            PlayerControl.Instance.GetExp(30);
            SetHealthPoint(0);
            Destroy(gameObject);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusFindPlayer);
    }
    public void UpdateEffectHit()
    {
        if (!isImmune) return;

        if (_durationGetHit > 0)
        {
            _durationGetHit -= Time.deltaTime;
        }
        else
        {
            EffectHitEnd();
        }
    }
    //Effect
    public void EffectHitActive()
    {
        _durationGetHit = durationGetHit;
        sprite.color = new Color(255, 0, 0);
        isImmune = true;
    }
    public void EffectHitEnd()
    {
        sprite.color = Color.white;
        isImmune = false;
    }
}
