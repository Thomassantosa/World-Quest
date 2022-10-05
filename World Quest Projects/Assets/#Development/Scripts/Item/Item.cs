using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public TypeItem type;
    [SerializeField] private int amount;
    
    private void ItemActivated(PlayerData dataPlayer)
    {
        switch (type)
        {
            case TypeItem.HEALTH:
                dataPlayer.SetHealthPoint(dataPlayer.GetHealthPoint() + amount);
                break;
            case TypeItem.MANA:
                dataPlayer.SetManaPoint(dataPlayer.GetManaPoint() + amount);
                break;
            case TypeItem.GOLD:
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
    GOLD
}
