using System.Collections;
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
    public bool isNight = true;
    private int dayNumber = 1;

    [Header("Difficulty Management")]
    private float dScaler;

    [Header("Souls Management")]
    [SerializeField] private GameObject sSpawner;
    [SerializeField] private GameObject soul;
    private int nbSouls = 30;
    private int spawnedSouls = 0;
    private int spawningSpeed = 0;
    [Range(0f, 50f)] [SerializeField] private float range;
    private float sX = 0f;
    private float sZ = 0f;
    private float soulHeight = 0f;

    [SerializeField] private GameObject sSpawnerCimetery;
    private int nbSoulsCim = 10;
    private int spawnedSoulsCim = 0;
    private int spawningSpeedCim = 0;
    [Range(0f, 50f)] [SerializeField] private float rangec;
    private float scX = 0f;
    private float scZ = 0f;

    [Header("Enemy Management")]
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject goalObject;
    private int nbEnemyPerWave = 1;
    private float spawningSpeedEn = 0;

    private int waveNumber = 1;
    private int dayNbToGrow = 3;
    private int euclidian = 0;

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

        scX = sSpawnerCimetery.transform.position.x;
        scZ = sSpawnerCimetery.transform.position.z;

        eX = enemySpawner.transform.position.x;
        eZ = enemySpawner.transform.position.z;

        //enemyHeight = soul.transform.position.y;

    }

    void Update(){
        onScreenTr += Time.deltaTime;
        codeTr += Time.deltaTime;
        //nbEnemyPerWave += (Time.deltaTime / 360) * waveNumber; //Not Used RN

        //Gestion phases:
        if (codeTr >= phasesCd) {
            LaunchPhase();

            codeTr -= phasesCd;
        }

        //Souls Spawn
        if (isNight && spawnedSouls < nbSouls) {
            if (spawningSpeed >= 120) {
                SoulsSpawn();
                spawnedSouls++; 

                spawningSpeed = 0;
            }
        }
        //Soulsc Spawn
        if (isNight && spawnedSoulsCim < nbSoulsCim) {
            if (spawningSpeedCim >= 60) {
                SoulsSpawnCimetery();
                spawnedSoulsCim++; 

                spawningSpeedCim = 0;
            }
        }
        //Enemy Spawn
        if (!isNight) {
            if (spawningSpeedEn >= phasesCd/waveNumber) {
                SpawnEnemy();

                spawningSpeedEn = 0;
            }
        }
    
        spawningSpeed++;
        spawningSpeedCim++;
        spawningSpeedEn += Time.deltaTime;

        string minutes = Mathf.Floor(onScreenTr/60).ToString("00");
        string seconds = (onScreenTr % 60).ToString("00");

        timerText.text = "Duration: " + minutes + ":" + seconds;
        dayText.text = "Day: " + dayNumber.ToString("00");
    }

    #endregion
    #region Custom Methods
    #region Phases
    void LaunchPhase(){
        if (isNight){
            Day();
            SfxManager.sfxInstance.Cocorico.PlayOneShot(SfxManager.sfxInstance.CocoricoSnd);
        }
        else Night();
        
        isNight = !isNight;
    }

    void Day(){
        SfxManager.sfxInstance.NightAmbiance.Pause();
        SfxManager.sfxInstance.MusicNight.Pause();
        SfxManager.sfxInstance.MusicDay.Play();

        nbEnemyPerWave += 1;
        spawnedSouls = 0;
        spawnedSoulsCim = 0;

        euclidian++;

        int testEuclidian = euclidian % dayNbToGrow;
        Debug.Log(testEuclidian);
        if (testEuclidian == 0) waveNumber++; 
        Debug.Log(waveNumber);

        dayNumber += 1;
        Debug.Log("Day");
    }

    void Night(){
        SfxManager.sfxInstance.MusicDay.Pause();
        SfxManager.sfxInstance.NightAmbiance.Play();
        SfxManager.sfxInstance.MusicNight.Play();

        nbSouls += 10;
        nbSoulsCim += 1;

        Debug.Log("Night");
    }
    #endregion
    #region SoulsSpawn
    void SoulsSpawn() {
        float randX = Random.Range(-range, range);
        float randZ = Random.Range(-range, range);

        float newSX = sX + randX;
        float newSZ = sZ + randZ;

        Instantiate(soul, new Vector3(newSX, soulHeight, newSZ), transform.rotation * Quaternion.Euler(-90, 0, 0));
    }

    void SoulsSpawnCimetery()
    {
        float randcX = Random.Range(-rangec, rangec);
        float randcZ = Random.Range(-rangec, rangec);

        float newScX = scX + randcX;
        float newScZ = scZ + randcZ;

        Instantiate(soul, new Vector3(newScX, soulHeight, newScZ), transform.rotation * Quaternion.Euler(-90, 0, 0));
    }
    #endregion
    void SpawnEnemy()
    {
        for (int i = 0; i < nbEnemyPerWave; i++)
        {
            GameObject na = (GameObject)Instantiate(enemy, new Vector3(eX, enemyHeight, eZ), Quaternion.identity);
            na.GetComponent<AIMovement>().goal = goalObject.transform;

            Invoke("SpawnAgent", Random.Range(1, 10));
        }
    }

    #endregion
}
