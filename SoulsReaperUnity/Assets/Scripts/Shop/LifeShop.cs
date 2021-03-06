using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeShop : MonoBehaviour
{
    public float maxHealthShop = 100f;
    public float currentHealthShop;

    public GameObject shopBarUI;
    public Slider slider;

    void Start()
    {
        currentHealthShop = maxHealthShop;
        slider.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();

        if (currentHealthShop <= 0)
        {
            SfxManager.sfxInstance.NightAmbiance.Pause();
            SfxManager.sfxInstance.MusicNight.Pause();
            SfxManager.sfxInstance.MusicNight.Pause();
            SceneManager.LoadScene("GameOver");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentHealthShop -= 5;
            Debug.Log(currentHealthShop);
        }
    }

    float CalculateHealth()
    {
        return currentHealthShop / maxHealthShop;
    }
}
