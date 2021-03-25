using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PausePanel;

    void Update() //Pause the Game 
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            PauseMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            ClosePauseMenu();
        }
    }

    public void PauseMenu()
    {
        Time.timeScale = 0;
        SfxManager.sfxInstance.PauseMenuOpen.PlayOneShot(SfxManager.sfxInstance.PauseMenuOpenSnd);
        PausePanel.SetActive(true);
    }

    public void ClosePauseMenu()
    {
        Time.timeScale = 1;
        SfxManager.sfxInstance.PauseMenuClose.PlayOneShot(SfxManager.sfxInstance.PauseMenuCloseSnd);
        PausePanel.SetActive(false);
    }
}
