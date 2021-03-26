using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region Init
    public List<Items> itemsDBCopy;
    public List<Skills> skillsDBCopy;
    public List<Terror> terrorDBCopy;

    public ShopDatabase shopDatabase;

    private GameObject itemsTemplate;
    private GameObject skillsTemplate;
    private GameObject terrorTemplate;
    private GameObject g;
    private List<Items> l;

    [SerializeField] private Transform itemsOrganization;
    [SerializeField] private Transform skillsOrganization;
    [SerializeField] private Transform terrorOrganization;

    #endregion

    void Awake(){
        itemsDBCopy = shopDatabase.itemsDB;
        skillsDBCopy = shopDatabase.skillsDB;
        terrorDBCopy = shopDatabase.terrorDB;
    }

    void Start(){
        #region Items

        itemsTemplate = itemsOrganization.GetChild(0).gameObject;
        int lItems = itemsDBCopy.Count;

        for (int i = 0; i < lItems; i++)
        {
            g = Instantiate(itemsTemplate,itemsOrganization);
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
        Destroy(itemsTemplate);   

        #endregion
        #region Skills

        skillsTemplate = skillsOrganization.GetChild(0).gameObject;
        int lSkills = skillsDBCopy.Count;

        for (int i = 0; i < lSkills; i++)
        {
            g = Instantiate(skillsTemplate,skillsOrganization);
            var sInfos = g.GetComponent<SkillInfos>().skillsInfos[0];

            //There surely is a better way to do this, but it works...
            sInfos.Type = skillsDBCopy[i].Type;
            sInfos.Name = skillsDBCopy[i].Name;
            sInfos.Cost = skillsDBCopy[i].Cost;
            sInfos.Multiplier = skillsDBCopy[i].Multiplier;
            sInfos.Limit = skillsDBCopy[i].Limit;
            sInfos.Unlocked = skillsDBCopy[i].Unlocked;
            sInfos.Id = skillsDBCopy[i].Id;
        }
        Destroy(skillsTemplate);   

        #endregion
        #region Terror
            
        terrorTemplate = terrorOrganization.GetChild(0).gameObject;
        int lTerror = terrorDBCopy.Count;

        for (int i = 0; i < lTerror; i++)
        {
            g = Instantiate(terrorTemplate,terrorOrganization);
            var tInfos = g.GetComponent<TerrorInfos>().terrorInfos[0];

            //There surely is a better way to do this, but it works...
            tInfos.Type = terrorDBCopy[i].Type;
            tInfos.Name = terrorDBCopy[i].Name;
            tInfos.Cost = terrorDBCopy[i].Cost;
            tInfos.Multiplier = terrorDBCopy[i].Multiplier;
            tInfos.Limit = terrorDBCopy[i].Limit;
            tInfos.Id = terrorDBCopy[i].Id;
        }
        Destroy(terrorTemplate);  

        
        #endregion
    }
}
