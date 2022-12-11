using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public TypeUser type;
    [Header("Main Data")]
    public EnemyData enemyData;
    public EnemyAttack enemyAttack;
    public GameObject enemyAnim;
    public Rigidbody2D rB;
    public SpriteRenderer sprite;
    [SerializeField] protected TypeAttack typeAttack;

    [Header("Item Drop")]
    public Item[] listItem;
    public int maxItemDrop;

    [Header("Main Variable")]
    public bool isImmune;

    [Header("Effect")]
    public float durationGetHit;
    private float _durationGetHit;


    [Header("Area")]
    public AreaManager areaManager;

    [Header("Finding Player")]
    public float radiusFindPlayer;
    public LayerMask layerPlayer;

    [Header("Movement")]
    [SerializeField] protected float minDistance;
    protected float moveSpeed;
    public float counterTimeIdle;

    [Header("Movement Random")]
    public int numberPath;
    protected Vector3 targetRandom;

    [Header("Movement Target")]
    [SerializeField] protected Transform targetPlayer;


    [Header("Effect")]
    public GameObject effectDie;
    public GameObject spriteDie;
    public void Init()
    {
        moveSpeed = enemyData.GetMovementSpeed();
        ChangeMovement();
        UpdateDirectionFace(transform.position - (Vector3.right * -5));
    }
    protected void FindPlayer()
    {
        
        Collider2D isFoundPlayer = Physics2D.OverlapCircle(transform.position, radiusFindPlayer, layerPlayer);

        if (isFoundPlayer != null)
        {
            if (targetPlayer == null)
            {
                FoundPlayer(isFoundPlayer.gameObject);
            }
        }
        else
        {
            targetPlayer = null;
        }
        
    }
    protected void UpdateMovement()
    {
        FindPlayer();

        if (enemyData.isIdle)
        {
            if (counterTimeIdle >= 0)
            {
                counterTimeIdle -= Time.deltaTime;
            }
            else
            {
                enemyData.isIdle = false;

                if (targetPlayer == null)
                    ChangeMovement();
            }
        }
        else
        {
            if (targetPlayer != null)
            {
                UpdateMovementTarget();
            }
            else
            {
                UpdateMovementRandom();
            }
        }
        
    }

    protected void UpdateMovementRandom()
    {
        if (Vector3.Distance(transform.position, targetRandom) > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetRandom, moveSpeed * Time.deltaTime);
        }
        else
        {
            IdleIsTrue();
        }
    }
    public virtual void UpdateMovementTarget()
    {
    }
    protected void IdleIsFalse()
    {
        enemyData.isIdle = false;
    }
    protected void IdleIsTrue()
    {
        enemyData.isIdle = true;
        float timeCd = enemyData.GetTimeIdle();
        counterTimeIdle = Random.Range(timeCd, timeCd * 2);
    }

    protected void UpdateDirectionFace(Vector3 target)
    {
        if (transform.position.x < target.x)
        {
            if (!enemyData.isFaceRight)
                ChangeDirectionFace(true);
        }
        else
        {
            if (enemyData.isFaceRight)
                ChangeDirectionFace(false);
        }

        enemyAttack.UpdateRotationWeapon(target);
    }
    private void ChangeDirectionFace(bool toRight)
    {
        if (toRight)
        {
            enemyData.isFaceRight = true;
/*            enemyAttack.ChangePosHandGrap(GrabHand.RIGHT);*/
            enemyAnim.transform.eulerAngles = Vector3.zero;
        }
        else
        {
            enemyData.isFaceRight = false;
/*            enemyAttack.ChangePosHandGrap(GrabHand.LEFT);*/
            enemyAnim.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    protected void UpdateRotationWeapon()
    {
        if (targetPlayer != null)
            UpdateDirectionFace(targetPlayer.position);
        else
            UpdateDirectionFace(targetRandom);
    }

    public void FoundPlayer(GameObject objectPlayer)
    {
        targetPlayer = objectPlayer.transform;
        IdleIsFalse();
    }


    protected void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    public void GetDamage(int dmg)
    {
        if (isImmune) return;

        SoundManager.instance.PlaySFX(SoundSFX.SFX_ENEMY_GET_HIT);
        EffectHitActive();
        //Test
        int lastHealth = enemyData.GetHealthPoint() - dmg;
        if (lastHealth > 0)
        {
            enemyData.SetHealthPoint(lastHealth);
        }
        else
        {
            Instantiate(effectDie, transform.position, Quaternion.identity);
            Instantiate(spriteDie, transform.position, Quaternion.identity);
            
            DropItem();

            PlayerControl.Instance.GetExp(5);

            if(areaManager != null) areaManager.EnemyDie();
            enemyData.SetHealthPoint(0);
            Destroy(gameObject);
        }
    }


    protected void ChangeMovement()
    {
        targetRandom = EnemyManager.instance.enemyPaths[numberPath - 1].GetRandomPath();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusFindPlayer);
    }

    public void DropItem()
    {
        int countDrop = Random.Range(0, maxItemDrop);
        for (int i = 0; i < countDrop; i++)
        {
            Instantiate(
                listItem[Random.Range(0, listItem.Length)].gameObject, 
                transform.position, 
                Quaternion.identity);

        }
    }

    public void UpdateEffectHit()
    {
        if (!isImmune) return;

        if(_durationGetHit > 0)
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
