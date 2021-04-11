using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfos : MonoBehaviour
{   

    public List<Skills> skillsInfos = new List<Skills>();
    
    private int buy = 0;
    private float souls = 0;

    #region ShortCuts Initialization
    private string sName = "Null";
    private float sCost = 0f;
    private int sLimit = 0;
    private float sMultiplier = 0f;
    private bool sUnlocked = false;
    private bool sPlaced = false;
    #endregion

    void Awake() {
        //Adding this somehow allows me to dodge this error:
            //ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. Parameter name: index
        skillsInfos.Add(new Skills() {Type = 0, Name = "Null", Cost = 0f, Multiplier = 0f, Limit = 0, Unlocked = false, Id = 0000});
    }

    void Start() {
        #region ShortCuts
        sName = skillsInfos[0].Name;
        sCost = skillsInfos[0].Cost;
        sMultiplier = skillsInfos[0].Multiplier;
        sLimit = skillsInfos[0].Limit;
        sUnlocked = skillsInfos[0].Unlocked;
        #endregion

        //g.transform.GetChild(0).GetComponent<Image>().sprite = itemsDBCopy[i].Image;
        gameObject.transform.GetChild(1).GetComponent<Text>().text = sName;
        gameObject.transform.GetChild(0).GetComponent<Button>().interactable = sUnlocked;
        //gameObject.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = sCost.ToString() + " souls";
    }

    void Update() {
        //voir si souls isoké, sinon pas clickable
            //comme ça on enlève la condition dans le purchase() :)
    }

    public void Purchase() {
        if (Score.Souls >= sCost) {
            sCost *= sMultiplier;
            sMultiplier += 1;
            Score.Souls -= sCost;

            buy += 1;
        }

        if (buy >= sLimit) {
            gameObject.transform.GetChild(2).GetComponent<Button>().interactable = false;
        }

        gameObject.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = sCost.ToString() + " souls";
    }
}