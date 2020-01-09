using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour{
    public GameObject buttonBuy;
    public Click click;
    public GameObject itemInfo;
    public float cost;
    public int count = 0;
    public int clickPower;
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
        itemInfo.GetComponent<Text>().text = itemName + " (" + count + ") " + "\nValor: R$ " + CurrencyConverter.Instance.GetCurrencyIntoString(cost, false, false) + "\nPoder: +" + clickPower;
        _slider.value = click.money / cost * 100;
    }

    public void PurchasedUpgrade() {
        if (click.money >= cost) {
            click.money -= cost;
            count +=1;
            click.goldperClick += clickPower;
            cost = Mathf.Round(baseCost * Mathf.Pow (1.15f, count));
        }
    }

}
