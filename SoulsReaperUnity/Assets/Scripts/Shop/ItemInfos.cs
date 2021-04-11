using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfos : MonoBehaviour
{   
    public List<Items> itemInfos = new List<Items>();
    
    private int buy = 0;
    private float souls = 0;

    #region ShortCuts Initialization
    public string iName = "Null";
    private float iCost = 0f;
    private int iLimit = 0;
    private bool iUnlocked = false;
    private bool iPlaced = false;
    #endregion

    void Awake() {
        //Adding this somehow allows me to dodge this error:
            //ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. Parameter name: index
        itemInfos.Add(new Items() {Type = 0, Name = "Null", Cost = 0f, Limit = 0, Unlocked = false, Placed = false, Id = 0000});
    }

    void Start() {
        #region ShortCuts
        iName = itemInfos[0].Name;
        iCost = itemInfos[0].Cost;
        iLimit = itemInfos[0].Limit;
        iUnlocked = itemInfos[0].Unlocked;
        iPlaced = itemInfos[0].Placed;
        #endregion

        //g.transform.GetChild(0).GetComponent<Image>().sprite = itemsDBCopy[i].Image;
        gameObject.transform.GetChild(1).GetComponent<Text>().text = iName;
        gameObject.transform.GetChild(0).GetComponent<Button>().interactable = iUnlocked;
        //gameObject.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = iCost.ToString() + " souls";
    }

    public void Purchase() {
        if (Score.Souls >= iCost) {
            Score.Souls -= iCost;

            buy += 1;
        }

        if (buy >= iLimit) {
            gameObject.transform.GetChild(2).GetComponent<Button>().interactable = false;
        }

    }
}
