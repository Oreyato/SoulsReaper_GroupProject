using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FearBar : MonoBehaviour
{
    private Slider slider;

    public float FillSpeed = 0.5f;
    private float targetProgress = 0;

    public PlayerMovement Player;


    private void Awake() {
        
        slider = gameObject.GetComponent<Slider>();
        
    }


    void Update() {
        
        if(Player.IsFear){
            
            IncrementFear(0.25f);

            if(slider.value < targetProgress){

            slider.value += FillSpeed * Time.deltaTime;
            }
        }
    }

    public void IncrementFear(float fear){

        targetProgress = slider.value + fear;
    }
}