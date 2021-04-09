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

    void Start()
    {
        player = GetComponent<Rigidbody>();
        GetComponent<SphereCollider>().enabled = false;
        IsFear = false;
        IsOpenShop = false;

    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Shop")
        {
            Debug.Log(IsOpenShop);
            if (Input.GetKeyDown(KeyCode.E) && !IsOpenShop)
            {
                OpenShop();
            } 
        }
    }

    void OnTriggerExit(Collider col)
    {
        CloseShop();
    }


    // Update is called once per frame
    void Update()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirection * speed * Time.deltaTime;
        DelayFear -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && !IsFear)
        {
            GetComponent<SphereCollider>().enabled = true;
            DelayFear = 2.0f;
            IsFear = true;
        }

        if (DelayFear <= 0.0f)
        {
            DelayFear = 0.0f;
            IsFear = false;
        }

    }

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
    }

    public void CloseShop()
    {
        ShopPanel.SetActive(false);
        IsOpenShop = false;
    }
}
