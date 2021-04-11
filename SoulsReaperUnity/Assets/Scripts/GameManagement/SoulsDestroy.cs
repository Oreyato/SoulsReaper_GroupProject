using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulsDestroy : MonoBehaviour
{
    [SerializeField] private GameObject gameManager;
    private bool isNight;
    private float posY;

    void Awake() {
        posY = gameObject.transform.position.y;
    }

    void Update() {
        isNight = gameManager.GetComponent<Phases>().isNight;

        if (!isNight && posY > -5) {
            Destroy(gameObject);
        }
    }
}
