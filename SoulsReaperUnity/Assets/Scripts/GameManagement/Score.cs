using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject scoreText;
    public static float Souls = 0;

    void Update() 
    {
        scoreText.GetComponent<Text>().text = "Souls: " + Souls;
    }
}
