using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfos : MonoBehaviour
{   
    public List<Items> itemInfos = new List<Items>();

    void Awake() {
        //Adding this somehow allows me to dodge this error:
            //ArgumentOutOfRangeException: Index was out of range. Must be non-negative and less than the size of the collection. Parameter name: index
        itemInfos.Add(new Items() {Type = 0, Name = "Null", Cost = 0f, Limit = 0, Unlocked = false, Placed = false, Id = 0000});
    }

    void Start() {
        //g.transform.GetChild(0).GetComponent<Image>().sprite = itemsDBCopy[i].Image;
        gameObject.transform.GetChild(1).GetComponent<Text>().text = itemInfos[0].Name;
        gameObject.transform.GetChild(2).GetComponent<Button>().interactable = itemInfos[0].Unlocked;
        gameObject.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = itemInfos[0].Cost.ToString() + " souls";
    }


}