using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource sourceMusic;
    public AudioSource sourceSFX;

    [Header("Music")]
    public AudioClip[] listMusic;
    [Header("SFX")]
    public AudioClip[] listSFX;
    private void Awake()
    {
        instance = this;
    }
    public void PlayMusic(SoundMusic music)
    {
        sourceMusic.clip = listSFX[music.GetHashCode()];
        sourceMusic.Play();
    }
    public void PlaySFX(SoundSFX sfx)
    {
        sourceSFX.PlayOneShot(listSFX[sfx.GetHashCode()]);
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
}
/*
 Sound effect
- Click OK
- Click Cancel
- Click Opening
- Pop-up
- Success panel
- Failed panel
- Boss sound
- Door open

Sound on object
- Weapon sound (staff, sword, bow, spear) 
- Get hit
- Dash
- Skill sound
- Change weapon
 */

