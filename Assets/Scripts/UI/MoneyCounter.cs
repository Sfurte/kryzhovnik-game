using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class MoneyCounter : MonoBehaviour
{
    public void PrintCountMoney()
    {
        TextMeshProUGUI[] textComponents = GetComponentsInChildren<TextMeshProUGUI>();
        textComponents[0].text = PlayerStats.Money.ToString("0.00") + "$";
    }

    public void Update()
    {
         PrintCountMoney();
    }

}
