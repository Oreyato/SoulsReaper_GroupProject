using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfos : MonoBehaviour
{   
    public List<Terror> terrorInfos = new List<Terror>();
    
    private int buy = 0;
    private float souls = 0;

    #region ShortCuts Initialization
    private string tName = "Null";
    private float tCost = 0f;
    private int tLimit = 0;
    private float tMultiplier = 0f;
    private bool tUnlocked = false;
    private bool tPlaced = false;
    #endregion

    void Awake() {
        //Adding this somehow allows me to dodge this error:
            //ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. Parameter name: index
        terrorInfos.Add(new Terror() {Type = 0, Name = "Null", Cost = 0f, Multiplier = 0f, Limit = 0, Id = 0000});
    }

    void Start() {
        #region ShortCuts
        tName = terrorInfos[0].Name;
        tCost = terrorInfos[0].Cost;
        tMultiplier = terrorInfos[0].Multiplier;
        tLimit = terrorInfos[0].Limit;
        #endregion

        //g.transform.GetChild(0).GetComponent<Image>().sprite = itemsDBCopy[i].Image;
        gameObject.transform.GetChild(1).GetComponent<Text>().text = tName;
        gameObject.transform.GetChild(2).GetComponent<Button>().interactable = tUnlocked;
        gameObject.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = tCost.ToString() + " souls";
    }

    void Update() {
        //voir si souls isoké, sinon pas clickable
            //comme ça on enlève la condition dans le purchase() :)
    }

    public void Purchase() {
        if (Score.Souls >= tCost) {
            tCost *= tMultiplier;
            tMultiplier += 1;
            Score.Souls -= tCost;

            buy += 1;
        }

        if (buy >= tLimit) {
            gameObject.transform.GetChild(2).GetComponent<Button>().interactable = false;
        }

        gameObject.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = tCost.ToString() + " souls";
    }
}