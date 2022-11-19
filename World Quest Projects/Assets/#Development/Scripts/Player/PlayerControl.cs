using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

    public TypeUser type;
    [Header("Data")]
    public PlayerData playerData;
    public PlayerAttack playerAttack;

    [Header("Movement")]
    public VariableJoystick joystick;

    [Header("Animation")]
    public GameObject playerSprite;

    private Rigidbody2D rB;

    private Vector2 moveDirect;

    public NPCControl npcActive;

    private void Awake()
    {
        Instance = this;

        rB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerData.SetMovementSpeed(playerData.GetNormalSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;
        moveDirect = new Vector2(moveX, moveY);
        GameManager.instance.canvas.SetDPad(moveX, moveY);

        if (moveDirect != Vector2.zero)
        {
            UpdateDirectionFace();
            playerAttack.UpdateRotationWeapon(moveDirect);
        }
    }

    public void UpdateDirectionFace()
    {
        if (moveDirect.x > 0)
        {
                ChangeDirectionFace(true);
        }
        else
        {
                ChangeDirectionFace(false);
        }
    }
    private void ChangeDirectionFace(bool toRight)
    {
        if (toRight)
        {
            playerData.isFaceRight = true;
            playerSprite.transform.eulerAngles = Vector3.zero;
        }
        else
        {
            playerData.isFaceRight = false;
            playerSprite.transform.eulerAngles = new Vector3(0, 180, 0);
        }


    }

    private void FixedUpdate()
    {
        rB.velocity = moveDirect * playerData.GetMovementSpeed() * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("NPC"))
        {
            npcActive = collision.GetComponent<NPCControl>();
            GameManager.instance.canvas.SetButtonDialog(npcActive);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals("NPC"))
        {
            GameManager.instance.canvas.CloseButtonDialog();
            npcActive = null;
        }
    }
    public void GetDamage(int dmg)
    {
        int lastHealth = playerData.GetHealthPoint() - dmg;
        if (lastHealth > 0)
        {
            playerData.SetHealthPoint(lastHealth);
        }
        else
        {
            playerData.SetHealthPoint(0);
            Debug.LogWarning("Player Die");
        }
    }
}
