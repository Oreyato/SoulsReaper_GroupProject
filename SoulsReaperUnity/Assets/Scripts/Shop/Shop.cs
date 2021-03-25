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

            //donner chaque composant à la liste
            //ou dupliquer listes
            foreach (var info in itemsDBCopy)
            {
                
            }

            //g.GetComponent<ItemInfos>().itemInfos = itemsDBCopy[i];

            //g.transform.GetChild(0).GetComponent<Image>().sprite = itemsDBCopy[i].Image;
            g.transform.GetChild(1).GetComponent<Text>().text = itemsDBCopy[i].Name;
            g.transform.GetChild(2).GetComponent<Button>().interactable = itemsDBCopy[i].Unlocked;
            g.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = itemsDBCopy[i].Cost.ToString() + " souls";
        }

        /*
        itemsDBCopy[1].Name = "Testing";
        g.transform.GetChild(1).GetComponent<Text>().text = itemsDBCopy[1].Name;

        > change the name of the last item only (quite expected)

        What we're looking for now:
            accessing each item's list, changing it! 
        */

        Destroy(ItemTemplate);
/*
        for (int i = 0; i < lSkills; i++)
        {
            g = Instantiate(ItemTemplate,ShopScrollView);
            var sInfos = g.GetComponent<SkillInfos>().skillInfos[0];

            //There surely is a better way to do this, but it works...
            sInfos.Type = itemsDBCopy[i].Type;
            sInfos.Name = skillsDBCopy[i].Name;
            sInfos.Cost = skillsDBCopy[i].Cost;
            sInfos.Multiplier = skillsDBCopy[i].Multiplier;
            sInfos.Limit = skillsDBCopy[i].Limit;
            sInfos.Unlocked = skillsDBCopy[i].Unlocked;
            sInfos.Id = skillsDBCopy[i].Id;
        }

        for (int i = 0; i < lTerror; i++)
        {
            g = Instantiate(ItemTemplate,ShopScrollView);
            var tInfos = g.GetComponent<TerrorInfos>().terrorInfos[0];

            //There surely is a better way to do this, but it works...
            tInfos.Type = terrorDBCopy[i].Type;
            tInfos.Name = terrorDBCopy[i].Name;
            tInfos.Cost = terrorDBCopy[i].Cost;
            tInfos.Multiplier = terrorDBCopy[i].Multiplier;
            tInfos.Limit = terrorDBCopy[i].Limit;
            tInfos.Id = terrorDBCopy[i].Id;
        }
*/
    }
}
