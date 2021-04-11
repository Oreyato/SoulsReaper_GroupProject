using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody player;

    public float DelayFear = 2.0f;

    public bool IsFear = false;

    public GameObject ShopPanel;
    public bool IsOpenShop;

    private bool isInRange = false;

    public GameObject InGameUI;
    public GameObject SharonInfo;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        GetComponent<SphereCollider>().enabled = false;
        IsFear = false;
        isInRange = false;
        IsOpenShop = false;

        ShopPanel.SetActive(false);
        SharonInfo.SetActive(false);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Shop")
        {
            isInRange = true;

            if (!IsOpenShop){
                SharonInfo.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        CloseShop();
        SharonInfo.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirection * speed * Time.deltaTime;
        DelayFear -= Time.deltaTime;

        if (isInRange && Input.GetKeyDown(KeyCode.E) && !IsOpenShop){
            OpenShop();
            IsOpenShop = true;
        }

        if (Input.GetKeyDown(KeyCode.F) && !IsFear)
        {
            GetComponent<SphereCollider>().enabled = true;
            DelayFear = 2.0f;
            IsFear = true;
            SfxManager.sfxInstance.BouhCharacter.PlayOneShot(SfxManager.sfxInstance.BouhCharacterSnd);
        }

        if (DelayFear <= 0.0f)
        {
            DelayFear = 0.0f;
            IsFear = false;
            GetComponent<SphereCollider>().enabled = false;
        }

    }

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
        InGameUI.SetActive(false);
        SharonInfo.SetActive(false);
    }

    public void CloseShop()
    {
        SharonInfo.SetActive(true);
        InGameUI.SetActive(true);
        ShopPanel.SetActive(false);
        IsOpenShop = false;
    }
}
