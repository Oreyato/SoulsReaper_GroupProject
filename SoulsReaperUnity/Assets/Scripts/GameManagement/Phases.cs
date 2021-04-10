﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phases : MonoBehaviour
{
    #region Variables
    [Header("Day/Night Cycle")]
    public float phasesCd = 60f;
    //
    [SerializeField] private Text timerText;
    [SerializeField] private Text dayText;
    [SerializeField] private RawImage clock;
    private float codeTr = 0f;
    private float onScreenTr = 0f;
    private bool isNight = true;
    private int dayNumber = 1;

    [Header("Difficulty Management")]
    private float dScaler;

    [Header("Souls Management")]
    [SerializeField] private GameObject sSpawner;
    [SerializeField] private GameObject soul;
    private int nbSouls = 30;
    [Range(0f, 50f)] [SerializeField] private float range;
    private float sX = 0f;
    private float sZ = 0f;
    private float soulHeight = 0f;

    [SerializeField] private GameObject sSpawnerCimetery;
    private int nbSoulsCim = 10;
    [Range(0f, 50f)] [SerializeField] private float rangec;
    private float scX = 0f;
    private float scZ = 0f;
    private float soulcHeight = 0f;

    [Header("Enemy Management")]
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject goalObject;
    private float nbEnemy = 3;
    private int waveFactor = 1;
    private float eX = 0f;
    private float eZ = 0f;
    private float enemyHeight = 0f;


    #endregion
    #region Unity Methods
    void Awake() {
        timerText.text = "Duration: 00:00";
        dayText.text = "Day: 1";

        sX = sSpawner.transform.position.x;
        sZ = sSpawner.transform.position.z;

        soulHeight = soul.transform.position.y;

        scX = sSpawnerCimetery.transform.position.x;
        scZ = sSpawnerCimetery.transform.position.z;

        soulcHeight = soul.transform.position.y;

        eX = enemySpawner.transform.position.x;
        eZ = enemySpawner.transform.position.z;

        enemyHeight = soul.transform.position.y;

    }

    void Update(){
        onScreenTr += Time.deltaTime;
        codeTr += Time.deltaTime;
        nbEnemy += (Time.deltaTime / 360) * waveFactor;

        //Gestion phases:
        if (codeTr >= phasesCd) {
            LaunchPhase();

            codeTr -= phasesCd;
        }

        string minutes = Mathf.Floor(onScreenTr/60).ToString("00");
        string seconds = (onScreenTr % 60).ToString("00");

        timerText.text = "Duration: " + minutes + ":" + seconds;
        dayText.text = "Day: " + dayNumber.ToString("00");
    }

    #endregion
    #region Custom Methods

    void LaunchPhase(){
        if (isNight){
            waveFactor++;
            Day();
        }
        else Night();
        

        nbEnemy = 0;
        isNight = !isNight;
    }

    void Day(){
        SfxManager.sfxInstance.NightAmbiance.Pause();
        SfxManager.sfxInstance.MusicNight.Pause();
        SfxManager.sfxInstance.MusicDay.Play();

        SpawnEnemy();
        SouslsDispawn();
        dayNumber += 1;
        Debug.Log("Day");
    }

    void Night(){
        SfxManager.sfxInstance.MusicDay.Pause();
        SfxManager.sfxInstance.NightAmbiance.Play();
        SfxManager.sfxInstance.MusicNight.Play();

        nbSouls += 10;
        nbSoulsCim += 1;
        SoulsSpawn();
        SoulsSpawnCimetery();

        Debug.Log("Night");
    }

    void SoulsSpawn() {
        for (int i = 0; i < nbSouls; i++)
        {
            float randX = Random.Range(-range, range);
            float randZ = Random.Range(-range, range);

            float newSX = sX + randX;
            float newSZ = sZ + randZ;

            Instantiate(soul, new Vector3(newSX, soulHeight, newSZ), transform.rotation * Quaternion.Euler(-90, 0, 0));
        }
    }

    void SouslsDispawn() {

    }

    void SoulsSpawnCimetery()
    {
        for (int j = 0; j < nbSoulsCim; j ++)
        {
            float randcX = Random.Range(-rangec, rangec);
            float randcZ = Random.Range(-rangec, rangec);

            float newScX = scX + randcX;
            float newScZ = scZ + randcZ;

            Instantiate(soul, new Vector3(newScX, soulcHeight, newScZ), transform.rotation * Quaternion.Euler(-90, 0, 0));
        }
    }

    void SpawnEnemy()
    {
        for (int k = 0; k < nbEnemy; k++)
        {
            GameObject na = (GameObject)Instantiate(enemy, new Vector3(eX, enemyHeight, eZ), Quaternion.identity);
            na.GetComponent<AIMovement>().goal = goalObject.transform;

            Invoke("SpawnAgent", Random.Range(1, 10));

        }
    }

    #endregion
}
