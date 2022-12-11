using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public bool isPlayer;
    [Header("Main Data")]
    [SerializeField] private int healthPoint;
    [SerializeField] private int manaPoint;
    [SerializeField] private int exPoint;
    [SerializeField] private int damage;
    [Header("Movement")]
    [SerializeField] private float normalSpeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float skillSpeed;
    [Header("Dash")]
    public float dashTime;
    public float dashCooldown;
    private float _dashTime;
    private bool isDash;

    [Header("Skill")]
    [SerializeField] private bool skillActive;
    [SerializeField] private int skillDamage;
    public float skillTime;
    public float skillCooldown;
    private float _skillTime;
    private bool isSkill;

    [Header("Attack")]
    public float attackCooldown;

    public bool isFaceRight;
    public bool isIdle;

    [Header("Level")]
    [SerializeField] private int level;
    [SerializeField] private int maxExp;
    [SerializeField] private int incrementExp;


    [Header("SFX")]
    public AudioSource audioSource;
    public AudioClip sfxDash;
    public AudioClip sfxGetHit;
    public AudioClip sfxSkill;
    public AudioClip sfxChange;

    public void SFXDash()
    {
        audioSource.PlayOneShot(sfxDash);
    }
    public void SFXGetHit()
    {
        audioSource.PlayOneShot(sfxGetHit);
    }
    public void SFXSkill()
    {
        audioSource.PlayOneShot(sfxSkill);
    }
    public void SFXChange()
    {
        audioSource.PlayOneShot(sfxChange);
    }
    public void SetHealthPoint(int healthPoint)
    {
        if (healthPoint >= 100) healthPoint = 100;
        this.healthPoint = healthPoint;

        if(isPlayer) GameManager.instance.canvas.canvasPlayer.SetHP(healthPoint);
    }

    public void SetManaPoint(int manaPoint)
    {
        if (manaPoint >= 100) manaPoint = 100;
        this.manaPoint = manaPoint;
        if (isPlayer) GameManager.instance.canvas.canvasPlayer.SetMP(manaPoint);
    }
    public void SetExp(int exPoint)
    {
        if (exPoint >= maxExp)
        {
            exPoint = 0;
            maxExp += incrementExp;
            level++;
            //Tambah Level Up
            Debug.LogWarning("Tambah Level Up");
        }
        this.exPoint = exPoint;
        if (isPlayer) GameManager.instance.canvas.canvasPlayer.SetEXP(level,exPoint, maxExp);
    }


    public void SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }
    public int GetDamage()
    {
        return damage;
    }

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }
    public float GetNormalSpeed()
    {
        return normalSpeed;
    }

    public int GetHealthPoint()
    {
        return healthPoint;
    }

    public int GetManaPoint()
    {
        return manaPoint;
    }
    public int GetExPoint()
    {
        return exPoint;
    }

    private void Update()
    {
        //Dash
        if (isDash)
        {
            if (_dashTime > 0)
            {
                _dashTime -= Time.deltaTime;

                if (_dashTime <= 0)
                {
                    PlayerDashFalse();
                }
            }
        }

        //Skill
        if (isSkill)
        {
            if (_skillTime > 0)
            {
                _skillTime -= Time.deltaTime;
                PlayerControl.Instance.EffectSkillActive();
                if (_skillTime <= 0)
                {
                    PlayerSkillFalse();
                }
            }
        }
    }

   
    public void PlayerDashTrue()
    {
        SFXDash();
        _dashTime = dashTime;
        movementSpeed = dashSpeed;
        isDash = true;
    }
    public void PlayerDashFalse()
    {
        _dashTime = 0;
        movementSpeed = normalSpeed;
        isDash = false;
    }

    public void PlayerSkillTrue()
    {
        PlayerControl.Instance.EffectUseSkill();
        SFXSkill();
        _skillTime = skillTime;
        skillActive = true;
        isSkill = true;

        movementSpeed = skillSpeed;
        damage += skillDamage;
    }
    public void PlayerSkillFalse()
    {
        PlayerControl.Instance.EffectSkillEnd();
        _skillTime = 0;
        skillActive = false;
        isSkill = false;

        movementSpeed = normalSpeed;
        damage -= skillDamage;
    }
}
