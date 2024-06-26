using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;



    public TypeUser type;
    [Header("Die")]
    public bool isDie;
    public GameObject objectSprite;
    [Header("Data")]
    public PlayerData playerData;
    public PlayerAttack playerAttack;

    [Header("Main Variable")]
    public bool isImmune;

    [Header("Effect")]
    public float durationGetHit;
    private float _durationGetHit;

    [Header("Movement")]
    public VariableJoystick joystick;

    [Header("Animation")]
    public SpriteRenderer playerSprite;



    private Rigidbody2D rB;

    private Vector2 moveDirect;

    public NPCControl npcActive;

    [Header("Effect")]
    public GameObject effectSkill;
    public GameObject effectSkillActive;
    public GameObject effectHeal;


    [Header("Effect Die")]
    public GameObject effectDie;
    public GameObject spriteDie;
    private void Awake()
    {
        Instance = this;

        rB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        playerData.SetMovementSpeed(playerData.GetNormalSpeed());
        playerData.SetExp(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie) return;
/*#if !UNITY_EDITOR || UNITY_EDITOR
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerData.PlayerDashTrue();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerAttack.ChangeWeapon();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            playerData.PlayerSkillTrue();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAttack.Attack();
        }*/
//#elif UNITY_ANDORID 
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;
//#endif

        moveDirect = new Vector2(moveX, moveY);
        GameManager.instance.canvas.SetDPad(moveX, moveY);

        if (moveDirect != Vector2.zero)
        {
            UpdateDirectionFace();
            playerAttack.UpdateRotationWeapon(moveDirect);
        }


        UpdateEffectHit();
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
        if (isImmune) return;

        playerData.SFXGetHit();
        EffectHitActive();
        int lastHealth = playerData.GetHealthPoint() - dmg;
        if (lastHealth > 0)
        {
            playerData.SetHealthPoint(lastHealth);
        }
        else
        {
            playerData.SetHealthPoint(0);
            Instantiate(effectDie, transform.position, Quaternion.identity);
            Instantiate(spriteDie, transform.position, Quaternion.identity);
            PlayerDie();
            Debug.LogWarning("Player Die");
        }
    }

    public void PlayerDie()
    {
        isDie = true;
        objectSprite.SetActive(false);
        GameManager.instance.canvas.PanelLose(true);
    }
    public void GetExp(int exp)
    {
        playerData.SetExp(playerData.GetExPoint() + exp);
    }

    //Effect
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
        playerSprite.color = new Color(255, 0, 0);
        isImmune = true;
    }
    public void EffectHitEnd()
    {
        playerSprite.color = Color.white;
        isImmune = false;
    }
    public void EffectUseSkill()
    {
        effectSkill.SetActive(true);
    }
    public void EffectSkillActive()
    {
        effectSkillActive.SetActive(true);
    }
    
    public void EffectSkillEnd()
    {
        effectSkillActive.SetActive(false);
    }
    public void EffectHealing()
    {
        effectHeal.SetActive(true);
    }
}
