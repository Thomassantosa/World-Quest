using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossControl : MonoBehaviour
{
    public Transform posOriginBoss;
    public Transform objectPlayer;
    public LayerMask layerPlayer;

    public int health;
    public Slider sliderHealth;
    public TextMeshProUGUI textHealth;

    [Header("Spawn Melee")]
    public GameObject objectGoblin;
    public int numberPath;

    [Header("Spawn Range")]
    public GameObject objectTower;
    public Transform spawnPosOrigin;
    public float spawnRangeX;
    public float spawnRangeY;
    public int numOfSpawn;

    public bool isIdle;
    public float timeIdle;
    private float _timeIdle;

    private bool isAttacking;
    private float _timeAttack1;
    private float _timeAttack2;

    public int pathAttack;


    [Header("Main Variable")]
    public bool isImmune;
    public Transform startPos;

    [Header("Effect")]
    public SpriteRenderer sprite;
    public float durationGetHit;
    private float _durationGetHit;

    public GameObject effectRespawn;
    public GameObject effectPosTarget;
    public GameObject effectAttack1;
    public GameObject effectAttack1b;


    public GameObject effectDie;
    public GameObject spriteDie;
    void Start()
    {
        pathAttack = 0;
        textHealth.text = $"{health}/500";
        sliderHealth.maxValue = health;
        IdleAttack();
    }

    void Update()
    {
        UpdateEffectHit();


/*        if (isAttacking)
        {
            if (_timeAttack1 > 0)
            {
                _timeAttack1 -= Time.deltaTime;
                //Attack1B();
            }
            else
            {
                isAttacking = false;
                ResetPosition();
            }
            return;
        }*/

        if (isIdle)
        {
            if (_timeIdle > 0)
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
            Instantiate(effectDie, posOriginBoss.position, Quaternion.identity);
            Instantiate(spriteDie, posOriginBoss.position, Quaternion.identity);
            GameManager.instance.canvas.PanelWin(true);
            GameManager.instance.gameFinish = true;
            SoundManager.instance.PlayMusic(SoundMusic.MUSIC_RUINS);
            Destroy(gameObject);
        }

        sliderHealth.value = health;
        textHealth.text = $"{health}/500";
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
        if (pathAttack >= 5)
        {
            IdleAttack();
            pathAttack = 0;
        }
        else if (pathAttack >= 4)
        {
            Attack2();
        }
        else
        {
            Attack1Init();
        }

    }
    Vector3 posTarget;

    public void Attack1Init()
    {
        Debug.Log("Attacl Init");
        Vector3 offset = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0);
        posTarget = objectPlayer.position + offset;
        effectPosTarget.SetActive(true);
        effectPosTarget.transform.position = posTarget;

        Invoke(nameof(Attack1), 2);
    }

    public void Attack1()
    {
        effectPosTarget.SetActive(false);
        transform.position = posTarget;
        effectAttack1.SetActive(true);
        Invoke(nameof(Attack1A),.5f);

    }
    public void Attack1A()
    {
        effectAttack1b.SetActive(true);
        _timeAttack1 = 1f;
        Attack1B();
    }
    protected void Attack1B()
    {

        Collider2D isFoundPlayer = Physics2D.OverlapCircle(transform.position, 1.5f, layerPlayer);

        if (isFoundPlayer != null)
        {
            isFoundPlayer.gameObject.GetComponent<PlayerControl>().GetDamage(20);
            _timeAttack1 = 0;
        }

        Invoke(nameof(ResetPosition), 1f);
    }

    public void ResetPosition()
    {
        transform.position = startPos.position;
        effectRespawn.SetActive(true);
        Invoke(nameof(IdleAttack), 3);
    }

    public void Attack2()
    {
        Invoke(nameof(Attack2A), 1.5f);
    }
    public void Attack2A()
    {
        int nums = Random.Range(1, numOfSpawn + 1);

        for (int i = 0; i < nums; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY), 0);
            if (Random.Range(0, 100) < 50)
            {
                GameObject tower = Instantiate(objectTower, spawnPosOrigin.position + offset, Quaternion.identity);
                EnemyTower scriptTower = tower.GetComponent<EnemyTower>();
                scriptTower.targetPlayer = objectPlayer;
            }
            else
            {
                GameObject goblin = Instantiate(objectGoblin, spawnPosOrigin.position + offset, Quaternion.identity);

                EnemyMelee scriptGoblin = goblin.GetComponent<EnemyMelee>();
                scriptGoblin.numberPath = numberPath;
            }
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
