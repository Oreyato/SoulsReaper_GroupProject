using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopPanelsManager : MonoBehaviour
{
    public GameObject ItemsPanel;
    public GameObject SkillsPanel;
    public GameObject TerrorPanel;
    public int selectedPanel = 1; //Means that the current active Panel is the ItemsPanel one

    void Awake(){
        selectedPanel = 1;

        ItemsPanel.SetActive(true);

        SkillsPanel.SetActive(false);
        TerrorPanel.SetActive(false);
    }

    public void OpenPanelItems(){
        selectedPanel = 1;

        ItemsPanel.SetActive(true);

        SkillsPanel.SetActive(false);
        TerrorPanel.SetActive(false);
    }
    public void OpenPanelSkills(){
        selectedPanel = 2;

        SkillsPanel.SetActive(true);

        ItemsPanel.SetActive(false);
        TerrorPanel.SetActive(false);
    }
    public void OpenPanelTerror(){
        selectedPanel = 3;

        TerrorPanel.SetActive(true);

        ItemsPanel.SetActive(false);
        SkillsPanel.SetActive(false);
    }
}
