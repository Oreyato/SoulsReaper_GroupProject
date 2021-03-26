using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsDisplay : MonoBehaviour
{
    [SerializeField] private GameObject soulsText;

    void Update()
    {
        soulsText.GetComponent<Text>().text = Score.Souls.ToString();
    }
}
