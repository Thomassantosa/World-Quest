using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource sourceMusic;
    public AudioSource sourceSFX;

    public Slider sldierMusic;
    public Slider sldierSFX;

    [Header("Music")]
    public AudioClip[] listMusic;
    [Header("SFX")]
    public AudioClip[] listSFX;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        if(!PlayerPrefs.HasKey("VolumeMusic"))
        {

            PlayerPrefs.SetFloat("VolumeMusic", 80);
            PlayerPrefs.SetFloat("VolumeEffect", 80);
        }

        float volMusic = PlayerPrefs.GetFloat("VolumeMusic");
        sourceMusic.volume = volMusic;
        sldierMusic.value = volMusic;
        float volEffect = PlayerPrefs.GetFloat("VolumeEffect");
        sourceSFX.volume = volEffect;
        sldierSFX.value = volEffect;
    }
    public float GetValEffect()
    {
        return PlayerPrefs.GetFloat("VolumeEffect");
    }
    public float GetValMusic()
    {
        return PlayerPrefs.GetFloat("VolumeMusic");
    }
    public void PlayMusic(SoundMusic music)
    {
        sourceMusic.clip = listMusic[music.GetHashCode()];
        sourceMusic.Play();
    }
    public void PlaySFX(SoundSFX sfx)
    {
        sourceSFX.PlayOneShot(listSFX[sfx.GetHashCode()]);
    }

    public void ChangeVolumeMusic(float val)
    {
        PlayerPrefs.SetFloat("VolumeMusic", val);
        sourceMusic.volume = val;
    }
    public void ChangeVolumeEffect(float val)
    {
        PlayerPrefs.SetFloat("VolumeEffect", val);
        sourceSFX.volume = val;
    }
}

public enum SoundMusic
{
    MUSIC_MENU,
    MUSIC_GUILD,
    MUSIC_RUINS,
    MUSIC_BOSS
}
/*
- Main menu
- Guild
- Forest
- Boss theme
 */
public enum SoundSFX
{ 
    SFX_CLICK_OK,
    SFX_CLICK_CANCEL,
    SFX_CLICK_OPENING,
    SFX_POP_UP,
    SFX_PANEL_SUCCESS,
    SFX_PANEL_FAILED,
    SFX_BOSS_SOUND,
    SFX_OPEN_DOOR,

    SFX_ENEMY_GET_HIT
}
/*
 Sound effect
- Click OK
- Click Cancel
- Click Opening
- Pop-up x
- Success panel x
- Failed panel x
- Boss sound x
- Door open
- Enemy Get Hit x

Sound on object
- Weapon sound (staff x, sword, bow, spear x) 
- Get hit x
- Dash x
- Skill sound x
- Change weapon
 */

