using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;

    public bool isFaceRight;

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
    private void Awake()
    {
        Instance = this;

        rB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Debug.Log("Player Control");
    }

    // Update is called once per frame
    void Update()
    {
        moveDirect = new Vector2(joystick.Horizontal, joystick.Vertical);

        if (moveDirect != Vector2.zero)
        {
            UpdateDirectionFace();
            playerAttack.UpdateRotationWeapon(moveDirect);
        }

        if (Input.GetKeyDown(KeyCode.G))
            playerAttack.Attack();
    }

    private void UpdateDirectionFace()
    {
        /*        if (moveDirect.x > 0)
                    playerSprite.flipX = false;
                else
                {
                    playerSprite.flipX = true;
                }*/
        if (moveDirect.x > 0)
        {
            isFaceRight = true;
            playerAttack.ChangePosHandGrap(GrabHand.RIGHT);
            playerSprite.transform.eulerAngles = Vector3.zero;
        }
        else
        {
            isFaceRight = false;
            playerAttack.ChangePosHandGrap(GrabHand.LEFT);
            playerSprite.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void FixedUpdate()
    {
        rB.velocity = moveDirect * playerData.GetMovementSpeed() * Time.deltaTime;
    }
}
