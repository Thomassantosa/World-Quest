using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossControl : MonoBehaviour
{
    public Transform objectPlayer;
    public LayerMask layerPlayer;

    public int health;
    public Slider sliderHealth;

    public GameObject objectTower;
    public Transform spawnPosOrigin;
    public float spawnRangeX;
    public float spawnRangeY;
    public int numOfTower;

    public bool isIdle;
    public float timeIdle;
    private float _timeIdle;

    private bool isAttacking;
    private float _timeAttack1;
    private float _timeAttack2;

    public int pathAttack;


    [Header("Main Variable")]
    public bool isImmune;

    [Header("Effect")]
    public SpriteRenderer sprite;
    public float durationGetHit;
    private float _durationGetHit;
    void Start()
    {
        pathAttack = 0;
        sliderHealth.maxValue = health;
        IdleAttack();
    }

    void Update()
    {
        UpdateEffectHit();


        if (isAttacking)
        {
            if (_timeAttack1 > 0)
            {
                _timeAttack1 -= Time.deltaTime;
                Attack1B();
            }
            else
            {
                isAttacking = false;
                Invoke(nameof(IdleAttack), 5);
            }
            return;
        }

        if(isIdle)
        {
            if(_timeIdle > 0)
            {
                _timeIdle -= Time.deltaTime;
            }
            else
            {
                isIdle = false;
                ChangeAttack();
            }
        }




    }

    public void GetDamage(int dmg)
    {
        if (isImmune) return;
        EffectHitActive();

        health -= dmg;
        if (health < 0)
        {
            health = 0;
        }

        sliderHealth.value = health;
    }

    public void IdleAttack()
    {
        isAttacking = false;
        isIdle = true;
        _timeIdle = timeIdle;
    }
    public void ChangeAttack()
    {
        isAttacking = true;

        pathAttack++;
        if(pathAttack >= 4)
        {
            IdleAttack();
            pathAttack = 0;
        }
        else if(pathAttack >= 3)
        {
            Attack2();
        }
        else
        {
            Attack1();
        }

    }

    public void Attack1()
    {
        transform.position = objectPlayer.position;
        Invoke(nameof(Attack1A), 1);

    }
    public void Attack1A()
    {
        _timeAttack1 = 0.5f;
    }
    protected void Attack1B()
    {

        Collider2D isFoundPlayer = Physics2D.OverlapCircle(transform.position, 3, layerPlayer);

        if (isFoundPlayer != null)
        {
            isFoundPlayer.gameObject.GetComponent<PlayerControl>().GetDamage(20);
            _timeAttack1 = 0;
        }

    }

    public void Attack2()
    {
        Invoke(nameof(Attack2A), 1.5f);
    }
    public void Attack2A()
    {
        for (int i = 0; i < numOfTower; i++)
        {
            GameObject tower = Instantiate(objectTower, spawnPosOrigin.position + new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), 0), Quaternion.identity);
        }

        Invoke(nameof(IdleAttack), 5);
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
