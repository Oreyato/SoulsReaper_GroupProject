using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotation : MonoBehaviour
{
    [SerializeField] private GameObject gManager;

    private float rot = 0f;
    private float timeOfDay = 0f;
    private float dayCd = 0f;

    private void Start() {
        gameObject.transform.eulerAngles = new Vector3(0f,0f,rot+180);
    }

    private void Update() {
        timeOfDay = gManager.GetComponent<LightingManager>().TimeOfDay;
        dayCd = gManager.GetComponent<Phases>().phasesCd;

        rot = timeOfDay * 180 / dayCd;
        gameObject.transform.eulerAngles = new Vector3(0f,0f,rot+180);
    }
}
