using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyConverter : MonoBehaviour{

    private static CurrencyConverter instance;
    public static CurrencyConverter Instance {
        get {
            return instance;
        }
    }

    void Awake() {
        CreateInstance();
    }

    void CreateInstance() {
        if (instance == null) {
            instance = this;
        }
    }

    public string GetCurrencyIntoString (float valueToConvert, bool currencyPerSec, bool currencyPerClick) {
        string converted;
        if (valueToConvert >= 1000000000) {
            converted = (valueToConvert / 1000000000f).ToString("f3") + " Bi";
        } else if (valueToConvert >= 1000000) {
            converted = (valueToConvert / 1000000f).ToString("f3") + " Mil";
        } else if (valueToConvert >= 1000) {
            converted = (valueToConvert / 1000f).ToString("f3") + " Mi";
        } else {
            converted = "" + valueToConvert;
        }

        if (currencyPerSec == true) {
            converted = converted + ".";
        }

        if (currencyPerClick == true) {
            converted = converted + ".";
        }

        return converted;

    }

}