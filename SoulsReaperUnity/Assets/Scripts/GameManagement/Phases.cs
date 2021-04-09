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


    #endregion
    #region Unity Methods
    void Awake() {
        timerText.text = "Duration: 00:00";
        dayText.text = "Day: 1";

        sX = sSpawner.transform.position.x;
        sZ = sSpawner.transform.position.z;

        soulHeight = soul.transform.position.y;

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


        dayNumber += 1;
        Debug.Log("Day");
    }

    void Night(){
        SoulsSpawn();
        test += 1;

        Debug.Log("Night");
    }

    void SoulsSpawn() {
        for (int i = 0; i < test; i++)
        {
            float randX = Random.Range(-range, range);
            float randZ = Random.Range(-range, range);

            float newSX = sX + randX;
            float newSZ = sZ + randZ;

            Instantiate(soul, new Vector3(newSX, soulHeight, newSZ), Quaternion.identity);
        }
    }

    void SouslsDispawn() {

    }

    void SpawnAgent()
    {

    }

    #endregion
}
