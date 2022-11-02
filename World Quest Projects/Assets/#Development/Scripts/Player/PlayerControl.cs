using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;


    [Header("Data")]
    public PlayerData playerData;
    public PlayerAttack playerAttack;

    [Header("Movement")]
    public VariableJoystick joystick;

    [Header("Animation")]
    public GameObject playerSprite;

    private Rigidbody2D rB;

    private Vector2 moveDirect;


    /*    public Vector2 moveDirect
        {
            get { return moveDirect; }
            private set { moveDirect = value; }
        }*/

    public NPCControl npcActive;

    private void Awake()
    {
        Instance = this;

        rB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.G))
            playerAttack.Attack();
    }

    public void UpdateDirectionFace()
    {
        if (moveDirect.x > 0)
        {
            if (!playerData.isFaceRight)
                ChangeDirectionFace(true);
        }
        else
        {
            if (playerData.isFaceRight)
                ChangeDirectionFace(false);
        }
    }
    private void ChangeDirectionFace(bool toRight)
    {
        if (toRight)
        {
            playerData.isFaceRight = true;
            playerAttack.ChangePosHandGrap(GrabHand.RIGHT);
            playerSprite.transform.eulerAngles = Vector3.zero;
        }
        else
        {
            playerData.isFaceRight = false;
            playerAttack.ChangePosHandGrap(GrabHand.LEFT);
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

}
