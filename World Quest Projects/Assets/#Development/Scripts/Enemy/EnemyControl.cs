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
    [SerializeField] protected TypeAttack typeAttack;
    
    [Header("Finding Player")]
    public float radiusFindPlayer;
    public LayerMask layerPlayer;

    [Header("Movement")]
    [SerializeField] protected float minDistance;
    protected float moveSpeed;
    public float counterTimeIdle;

    [Header("Movement Random")]
    [SerializeField] protected int numberPath;
    protected Vector3 targetRandom;

    [Header("Movement Target")]
    [SerializeField] protected Transform targetPlayer;

    public void Init()
    {
        moveSpeed = enemyData.GetMovementSpeed();
        ChangeMovement();
        UpdateDirectionFace(Vector3.zero);
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
        counterTimeIdle = enemyData.GetTimeIdle();
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
        //Test
        Destroy(gameObject);
        return;
        int lastHealth = enemyData.GetHealthPoint() - dmg;
        if (lastHealth > 0)
        {
            enemyData.SetHealthPoint(lastHealth);
        }
        else
        {
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
}
