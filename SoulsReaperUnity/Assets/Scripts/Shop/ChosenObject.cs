using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChosenObject : MonoBehaviour
{
    private int buy = 0;
    private float souls = 0f;

    private string nameChosen = "Null";
    private string description = "Null0";

    private float cost = 0f;
    private bool iUnlocked = false;
    private Texture chosenTexture;

    private int panelType = 0; //0: item, 1: skills, 2: terror

    void Start()
    {
        gameObject.transform.GetChild(0).GetComponent<Text>().text = nameChosen;
        gameObject.transform.GetChild(1).GetComponent<RawImage>().texture = chosenTexture;
        gameObject.transform.GetChild(2).GetComponent<Text>().text = description;
    }

    void Update()
    {
        
    }
}
