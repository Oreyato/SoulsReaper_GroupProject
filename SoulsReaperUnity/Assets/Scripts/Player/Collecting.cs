using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag== "Player")
        {
            Score.Souls += 1;
            Destroy(gameObject);
            //SfxManager.sfxInstance.SoulCollect.pitch = Random.Range(0.2, 1.5);
            SfxManager.sfxInstance.SoulCollect.PlayOneShot(SfxManager.sfxInstance.SoulCollectSnd);
        }

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
