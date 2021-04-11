using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody player;

    private float DelayFear = 0;
    public bool IsFear;

    public GameObject ShopPanel;
    public bool IsOpenShop = false;

    private bool isInRange = false;

    public GameObject InGameUI;
    public GameObject SharonInfo;

    void Start()
    {
        player = GetComponent<Rigidbody>();
        GetComponent<SphereCollider>().enabled = false;

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
        DelayFear += Time.deltaTime;

        if (isInRange && Input.GetKeyDown(KeyCode.E) && !IsOpenShop){
            OpenShop();
            IsOpenShop = true;
        }

        if (Input.GetKeyDown(KeyCode.F) && DelayFear >= 2.0f)
        {
            Debug.Log(DelayFear);
            IsFear = true;
            GetComponent<SphereCollider>().enabled = true;
            DelayFear = 0f;
            SfxManager.sfxInstance.BouhCharacter.PlayOneShot(SfxManager.sfxInstance.BouhCharacterSnd);
        }

        if (DelayFear < 2.0f && DelayFear > 1.0f) {
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
