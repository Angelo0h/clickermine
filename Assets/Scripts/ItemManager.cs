using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour{
    
    public GameObject buttonBuy;
    public GameObject itemInfo;
    public Click click;
    public float cost;
    public int tickValue;
    public int count;
    public string itemName;
    private float baseCost;
    private Slider _slider;

    void Start() {
        baseCost = cost;
        _slider = GetComponentInChildren<Slider>();
    }

    void Update() {
        if (_slider.value >= 100) {
            buttonBuy.GetComponent<Button>().interactable = true;
        } else{
            buttonBuy.GetComponent<Button>().interactable = false;
        }
        itemInfo.GetComponent<Text>().text = itemName + " (" + count + ") " + "\nValor: R$ " + CurrencyConverter.Instance.GetCurrencyIntoString(cost, false, false) + "\nOuro: " + tickValue + "/s";
        _slider.value = click.money / cost * 100;
    }

    public void PurchaseItem() {
        if (click.money >= cost) {
            click.money -= cost;
            count += 1;
            cost = Mathf.Round (baseCost * Mathf.Pow(1.15f, count));
        }
    }
}
