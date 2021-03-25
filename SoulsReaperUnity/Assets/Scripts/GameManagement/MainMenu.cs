using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SfxManager.sfxInstance.ClicButton.PlayOneShot(SfxManager.sfxInstance.ClicButtonSnd);
        SceneManager.LoadScene("SampleScene");
    }

    public void ReturnMenu()
    {
        SfxManager.sfxInstance.ClicButton.PlayOneShot(SfxManager.sfxInstance.ClicButtonSnd);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        SfxManager.sfxInstance.ClicButton.PlayOneShot(SfxManager.sfxInstance.ClicButtonSnd);
        Application.Quit();
    }

    public void PlayButtonSound()
    {
        SfxManager.sfxInstance.ClicButton.PlayOneShot(SfxManager.sfxInstance.ClicButtonSnd);
    }

    public void PlayBackMenuSound()
    {
        SfxManager.sfxInstance.ClicButton.PlayOneShot(SfxManager.sfxInstance.ClicButtonSnd);
    }

}
