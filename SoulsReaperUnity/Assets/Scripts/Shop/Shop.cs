using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region Init
    public List<Items> itemsDBCopy;
    private List<Skills> skillsDBCopy;
    private List<Terror> terrorDBCopy;

    public ShopDatabase shopDatabase;

    private GameObject ItemTemplate;
    private GameObject g;
    private List<Items> l;

    [SerializeField] private Transform ShopScrollView;

    #endregion

    void Awake(){
        itemsDBCopy = shopDatabase.itemsDB;
        skillsDBCopy = shopDatabase.skillsDB;
        terrorDBCopy = shopDatabase.terrorDB;
    }

    void Start(){
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int lItems = itemsDBCopy.Count;
        int lSkills = skillsDBCopy.Count;
        int lTerror = terrorDBCopy.Count;

        for (int i = 0; i < lItems; i++)
        {
            g = Instantiate(ItemTemplate,ShopScrollView);
            var iInfos = g.GetComponent<ItemInfos>().itemInfos[0];

            //There surely is a better way to do this, but it works...
            iInfos.Type = itemsDBCopy[i].Type;
            iInfos.Name = itemsDBCopy[i].Name;
            iInfos.Cost = itemsDBCopy[i].Cost;
            iInfos.Limit = itemsDBCopy[i].Limit;
            iInfos.Unlocked = itemsDBCopy[i].Unlocked;
            iInfos.Placed = itemsDBCopy[i].Placed;
            iInfos.Id = itemsDBCopy[i].Id;
        }
        Destroy(ItemTemplate);
    }
}
