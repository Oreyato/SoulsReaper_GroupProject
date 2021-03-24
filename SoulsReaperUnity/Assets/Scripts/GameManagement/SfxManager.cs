using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public AudioSource ClicButton;
    public AudioSource BackButton;
    public AudioSource BuyButton;
    public AudioSource PauseMenuOpen;
    public AudioSource PauseMenuClose;
    public AudioSource MusicMenu;
    public AudioSource MusicDay;
    public AudioSource MusicNight;
    public AudioSource NightAmbiance;
    public AudioSource Cocorico;
    public AudioSource RunCharacter;
    public AudioSource BouhCharacter;
    public AudioSource RunEnemy;
    public AudioSource ScreamEnemy;


    public AudioClip ClicButtonSnd;
    public AudioClip BackButtoSnd;
    public AudioClip BuyButtonSnd;
    public AudioClip PauseMenuOpenSnd;
    public AudioClip PauseMenuCloseSnd;
    public AudioClip MusicMenuSnd;
    public AudioClip MusicDaySnd;
    public AudioClip MusicNightSnd;
    public AudioClip NightAmbianceSnd;
    public AudioClip CocoricoSnd;
    public AudioClip RunCharacterSnd;
    public AudioClip BouhCharacterSnd;
    public AudioClip RunEnemySnd;
    public AudioClip ScreamEnemySnd;

    public static SfxManager sfxInstance;
    private void Awake()
    {
        if (sfxInstance != null && sfxInstance != this)
        {
            Destroy(this.gameObject);
            return;

        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
