using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phases : MonoBehaviour
{
    #region Variables
    [SerializeField] private Text timerText;
    [SerializeField] private Text dayText;
    [SerializeField] private RawImage clock;

    public float phasesCd = 60f;

    private float codeTr = 0f;
    private float onScreenTr = 0f;
    private bool isNight = true;
    private int dayNumber = 1;


    #endregion
    #region Unity Methods
    void Start(){
        timerText.text = "Duration: 00:00";
        dayText.text = "Day: 1";
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
        dayText.text = "Day: " + dayNumber.ToString();
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


        Debug.Log("Night");
    }

    #endregion
}
