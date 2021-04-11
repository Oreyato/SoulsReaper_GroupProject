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
    private string description2 = "Null1";

    [SerializeField] private GameObject defaultObj;

    private string oName;
    //private string oDescription;

    private float cost = 0f;
    private bool iUnlocked = false;
    private Texture chosenTexture;

    private int panelType = 0; //0: item, 1: skills, 2: terror

    void Awake()
    {
        //gameObject.transform.GetChild(0).GetComponent<RawImage>().texture = chosenTexture;
        gameObject.transform.GetChild(1).GetComponent<Text>().text = description;
        gameObject.transform.GetChild(2).GetComponent<Text>().text = description2;
        gameObject.transform.GetChild(3).GetComponent<Text>().text = nameChosen;
    }

    void Update(){
        oName = defaultObj.transform.GetChild(0).GetComponent<ItemInfos>().iName;
        gameObject.transform.GetChild(3).GetComponent<Text>().text = oName;
    }

}
