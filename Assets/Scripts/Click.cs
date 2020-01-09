using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour{
    public GameObject gpc;
    public GameObject goldDisplay;
    public GameObject moneyDisplay;
    public float gold = 0f;
    public float money = 0f;
    public int goldperClick = 1;

    void Update() {
        gpc.GetComponent<Text>().text = goldperClick + " Ouro/Click";
        goldDisplay.GetComponent<Text>().text = "Ouro: " + CurrencyConverter.Instance.GetCurrencyIntoString(gold, false, false);
        moneyDisplay.GetComponent<Text>().text = "R$: " + CurrencyConverter.Instance.GetCurrencyIntoString(money, false, false);
    }

    public void Clicked() {
        gold += goldperClick;
    }

    public void SellMine() {
        money += gold;
        gold -= gold;
    }
    

}
