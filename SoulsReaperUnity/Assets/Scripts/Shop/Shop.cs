using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region Init
    private List<Items> itemsDBCopy;
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
        //Il faudrait faire l'initialisation ici à partir des DB
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        int lItems = itemsDBCopy.Count;
        int lSkills = skillsDBCopy.Count;
        int lTerror = terrorDBCopy.Count;

        for (int i = 0; i < lItems; i++)
        {
            g = Instantiate(ItemTemplate,ShopScrollView);
            //l = g.GetComponent<ItemInfos>().itemInfos;

            //donner chaque composant à la liste
            //ou dupliquer listes
            /*
            foreach (var info in itemsDBCopy)
            {
                
            }
            */
            //g.GetComponent<ItemInfos>().itemInfos = itemsDBCopy[i];

            //g.transform.GetChild(0).GetComponent<Image>().sprite = itemsDBCopy[i].Image;
            g.transform.GetChild(1).GetComponent<Text>().text = itemsDBCopy[i].Name;
            g.transform.GetChild(2).GetComponent<Button>().interactable = itemsDBCopy[i].Unlocked;
            g.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = itemsDBCopy[i].Cost.ToString() + " souls";
        }

        Destroy(ItemTemplate);
    }
}
