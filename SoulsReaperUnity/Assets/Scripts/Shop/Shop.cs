using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private GameObject ItemTemplate;
    private GameObject g;
    [SerializeField] private Transform ShopScrollView;

    void Start(){
        //Il faudrait faire l'initialisation ici à partir des DB
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;

        for (int i = 0; i < 10; i++)
        {
            g = Instantiate(ItemTemplate,ShopScrollView);
        }

        Destroy(ItemTemplate);
    }
}
