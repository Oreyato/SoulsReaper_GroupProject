using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDatabase : MonoBehaviour
{
    #region Items List
    public List<Items> itemsDB = new List<Items>
    {
        //new Items {Name = "", Cost = f, Limit = , Unlocked = , Id = }, 
        //Default: Type = 1 && Placed = False

        new Items {Name = "Puddle", Cost = 10f, Limit = 10, Unlocked = true, Id = 1000}, 
        new Items {Name = "Clown Box", Cost = 50f, Limit = 8, Unlocked = true, Id = 1001}, 
        new Items {Name = "Raven", Cost = 100f, Limit = 5, Unlocked = true, Id = 1002},
        new Items {Name = "Grave", Cost = 150f, Limit = 10, Id = 1003}, 
        new Items {Name = "Portal", Cost = 250f, Limit = 2, Id = 1004}, //buy pairs
        new Items {Name = "Tesla", Cost = 500f, Limit = 2, Id = 1005}
    };
    #endregion
    #region Skills List

    public List<Skills> skillsDB = new List<Skills>
    {
        //new Skills {Name = "", Cost = f, Multiplier = f, Limit = , Unlocked = , Id = },
        //Default: Type = 2 

        //Character stats
        new Skills {Name = "Attack Speed", Cost = 10f, Multiplier = 1.5f, Limit = 10, Unlocked = true, Id = 2000},
        new Skills {Name = "Attack Range", Cost = 10f, Multiplier = 1.5f, Limit = 10, Unlocked = true, Id = 2001},
        new Skills {Name = "Speed", Cost = 20f, Multiplier = 2f, Limit = 10, Unlocked = true, Id = 2002},
        new Skills {Name = "Space", Id = 9999}, //separation when displaying the list 

        //Special Skills
        new Skills {Name = "Dash", Cost = 200f, Multiplier = 3f, Limit = 3, Id = 2100},
        new Skills {Name = "Area", Cost = 250f, Multiplier = 3f, Limit = 3, Id = 2101}, //ToDo - nom à définir
        new Skills {Name = "Pew", Cost = 300f, Multiplier = 3f, Limit = 3, Id = 2102}, //ToDo - nom à définir
        new Skills {Name = "Space", Id = 9999},

        //Collect related Skills
        new Skills {Name = "Spawn Count", Cost = 100f, Multiplier = 2f, Limit = 5, Id = 2200}  
    };

    #endregion
    #region Terror List
    public List<Terror> terrorDB = new List<Terror>
    {
        //new Terror {Name = "", Cost = f, Multiplier = , Limit = , Id = },
        //Default: Type = 3

        //Unlocks
        new Terror {Name = "Grave Unlock", Cost = 10f, Limit = 1, Id = 3001},
        new Terror {Name = "Portal Unlock", Cost = 10f, Limit = 1, Id = 3002},
        new Terror {Name = "Tesla Unlock", Cost = 10f, Limit = 1, Id = 3003},

        new Terror {Name = "Dash Unlock", Cost = 10f, Limit = 1, Id = 3004},
        new Terror {Name = "Area Unlock", Cost = 10f, Limit = 1, Id = 3005},
        new Terror {Name = "Pew Unlock", Cost = 10f, Limit = 1, Id = 3006},
        new Terror {Name = "Spawn Count Unlock", Cost = 10f, Limit = 1, Id = 3007},

        new Terror {Name = "Cemetery Unlock", Cost = 10f, Multiplier = 0, Limit = 1, Id = 3020},
        new Terror {Name = "Tombstone", Cost = 10f, Multiplier = 0, Limit = 1, Id = 3021},
        new Terror {Name = "Space", Id = 9999},

        //Temporary buffs
        new Terror {Name = "Soul Spawn Boost", Cost = 10f, Limit = 1, Id = 3100},
        new Terror {Name = "Space", Id = 9999},

        //Permanent buffs
//        new Terror {Name = "Max HP", Cost = 10f, Multiplier = 5, Limit = 3, Id = 3200},
        new Terror {Name = "Max Souls", Cost = 10f, Multiplier = 5, Limit = 3, Id = 3200},
        new Terror {Name = "Max Terror", Cost = 10f, Multiplier = 5, Limit = 3, Id = 3201},

    };
    #endregion

    [Header("ID explanations")]
    public string idInfos = "Ids: 1 + three numbers > items";
    public string idInfos2 = "2 > skills | 3 > terror";

    #region Context Menus
    [ContextMenu("Display items list")]
    public void ItemsDisplay() {
        Debug.Log("Items List: =====================");
        foreach (var item in itemsDB)
        {
            if (item.Id == 9999) {
                Debug.Log(" ");
            }
            else Debug.Log(item.Name + ": Costs " + item.Cost + " souls and it can be used " + item.Limit + " times  || Dev infos: unlockable: " + item.Unlocked  + ", placed: " + item.Placed + ", item ID: " + item.Id);
        }
        Debug.Log("=================================");
    }

    [ContextMenu("Display skills list")]
    public void SkillsDisplay() {
        Debug.Log("Skills List: =====================");
        foreach (var item in skillsDB)
        {
            if (item.Id == 9999) {
                Debug.Log(" ");
            }
            else Debug.Log(item.Name + ": Costs " + item.Cost + " souls, multiplier: " + item.Multiplier + " and it can be used " + item.Limit + " times || Dev infos: unlockable: " + item.Unlocked + ", item ID: " + item.Id);
        }
        Debug.Log("=================================");
    }

    [ContextMenu("Display terror list")]
    public void TerrorsDisplay() {
        Debug.Log("Terror List: =====================");
        foreach (var item in terrorDB)
        {
            if (item.Id == 9999) {
                Debug.Log(" ");
            }
            else Debug.Log(item.Name + ": Costs " + item.Cost + " souls, multiplier: " + item.Multiplier + " and it can be used " + item.Limit + " times || Dev infos: item ID: " + item.Id);
        }
        Debug.Log("=================================");
    }

    #endregion
}
