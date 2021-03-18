using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{
    public float speed = 8f;

    void OnTriggerEnter(Collider other) 
    {
        Time.timeScale = 0.25f;
    
    }
}
    
