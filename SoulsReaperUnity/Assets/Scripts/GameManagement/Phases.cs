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
    private bool isNight = true;
    private int dayNumber = 1;

    [Header("Difficulty Management")]
    private float dScaler;
    private int test = 1;

    [Header("Souls Management")]
    [SerializeField] private GameObject sSpawner;
    [SerializeField] private GameObject soul;
    [Range(0f, 50f)] [SerializeField] private float range;
    private float sX = 0f;
    private float sZ = 0f;
    private float soulHeight = 0f;

    [SerializeField] private GameObject sSpawnerCimetery;
    [Range(0f, 50f)] [SerializeField] private float rangec;
    private float scX = 0f;
    private float scZ = 0f;
    private float soulcHeight = 0f;

    [Header("Enemy Management")]
    [SerializeField] private GameObject EnemySpawner;
    [SerializeField] private GameObject enemy;
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

    }

    void Update(){
        onScreenTr += Time.deltaTime;
        codeTr += Time.deltaTime;

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
            Day();
        }
        else Night();

        isNight = !isNight;
    }

    void Day(){

        SouslsDispawn();
        dayNumber += 1;
        Debug.Log("Day");
    }

    void Night(){
        test += 1;
        SoulsSpawn();
        SoulsSpawnCimetery();

        Debug.Log("Night");
    }

    void SoulsSpawn() {
        for (int i = 0; i < test; i++)
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
        for (int j = 0; j < test; j ++)
        {
            float randcX = Random.Range(-rangec, rangec);
            float randcZ = Random.Range(-rangec, rangec);

            float newScX = scX + randcX;
            float newScZ = scZ + randcZ;

            Instantiate(soul, new Vector3(newScX, soulcHeight, newScZ), transform.rotation * Quaternion.Euler(-90, 0, 0));
        }
    }

    void SpawnAgent()
    {

    }

    #endregion
}
