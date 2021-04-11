using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopPanelsManager : MonoBehaviour
{
    public GameObject ItemsPanel;
    public GameObject SkillsPanel;
    public GameObject TerrorPanel;

    public GameObject SelectedItems;
    public GameObject SelectedSkills;
    public GameObject SelectedTerror;

    public int selectedPanel = 1; //Means that the current active Panel is the ItemsPanel one

    void Awake(){
        selectedPanel = 1;

        ItemsPanel.SetActive(true);
        SelectedItems.SetActive(true);

        SkillsPanel.SetActive(false);
        TerrorPanel.SetActive(false);
    }

    public void OpenPanelItems(){
        selectedPanel = 1;

        ItemsPanel.SetActive(true);
        SelectedItems.SetActive(true);

        SkillsPanel.SetActive(false);
        TerrorPanel.SetActive(false);
        SelectedSkills.SetActive(false);
        SelectedTerror.SetActive(false);
    }
    public void OpenPanelSkills(){
        selectedPanel = 2;

        SkillsPanel.SetActive(true);
        SelectedSkills.SetActive(true);

        ItemsPanel.SetActive(false);
        TerrorPanel.SetActive(false);
        SelectedItems.SetActive(false);
        SelectedTerror.SetActive(false);
    }
    public void OpenPanelTerror(){
        selectedPanel = 3;

        TerrorPanel.SetActive(true);
        SelectedTerror.SetActive(true);

        ItemsPanel.SetActive(false);
        SkillsPanel.SetActive(false);
        SelectedItems.SetActive(false);
        SelectedSkills.SetActive(false);
    }
}
