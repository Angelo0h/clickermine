using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shop;
    public GameObject shopButton;
    public GameObject closeShop;
    public GameObject itemsShop;
    public GameObject upgradesShop;

    public void ShopClick()
    {
        shop.SetActive(true);
        shopButton.SetActive(false);
    }

    public void CloseShop()
    {
        shop.SetActive(false);
        shopButton.SetActive(true);
    }

    public void Items()
    {
        itemsShop.SetActive(true);
        upgradesShop.SetActive(false);
    }

    public void Upgrades()
    {
        itemsShop.SetActive(false);
        upgradesShop.SetActive(true);
    }


}
