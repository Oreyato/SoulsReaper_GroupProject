using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{

    void OnTriggerEnter(Collider other) 
    {
        Score.theScore += 1;
        Destroy(gameObject);
    }
}
