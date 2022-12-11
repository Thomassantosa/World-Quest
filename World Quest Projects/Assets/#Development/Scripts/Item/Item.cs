using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public TypeItem type;
    [SerializeField] private int amount;
    [SerializeField] private float moveSpeed;

    public bool canClaim;
    public bool moveToTarget;
    public Vector3 targetPos;

    public void Start()
    {
        canClaim = false;
        moveToTarget = true;
        targetPos = transform.position + new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 1);
    }

    public void Update()
    {
        MoveToTargetDrop();
    }
    public void MoveToTargetDrop()
    {
        if (!moveToTarget) return;

        if (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
        else
        {
            moveToTarget = false;
            canClaim = true;
        }
    }
    private void ItemActivated(PlayerData dataPlayer)
    {
        switch (type)
        {
            case TypeItem.HEALTH:
                PlayerControl.Instance.EffectHealing();
                dataPlayer.SetHealthPoint(dataPlayer.GetHealthPoint() + amount);
                break;
            case TypeItem.MANA:
                dataPlayer.SetManaPoint(dataPlayer.GetManaPoint() + amount);
                break;
            case TypeItem.GOLD:
                GameManager.instance.Coin += amount;
                break;
            case TypeItem.POTION_HEALTH:
                //Add to inventory
                break;
            case TypeItem.POTION_MANA:
                //Add to inventory
                break;
            default:
                break;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            PlayerData dataPlayer = collision.GetComponent<PlayerData>();
            if (dataPlayer != null)
            {
                ItemActivated(dataPlayer);
            }

            Destroy(gameObject);
        }
    }
}

public enum TypeItem
{
    HEALTH,
    MANA,
    GOLD,
    POTION_HEALTH,
    POTION_MANA
}
