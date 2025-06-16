using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class MoneyCounter : MonoBehaviour
{
    public GameObject TextWindowForMoney;
    public GameObject TextWindowForProfit;

    private TMP_Text textMeshForMoney;
    private TMP_Text textMeshForProfit;


    public Color negativeColor = Color.red;
    private Color positiveColor = Color.green;



    private void Start()
    {
        textMeshForMoney = TextWindowForMoney.GetComponent<TMP_Text>();
        textMeshForProfit = TextWindowForProfit.GetComponent<TMP_Text>();

        Clock.GetInstance().TickActions += () => { PrintProfitMoney(); };
    }

    public void PrintCountMoney()
    {
        textMeshForMoney.text = PlayerStats.Money.ToString("0.00") + "$";

    }
    public void PrintProfitMoney()
    {
        var profit = PlayerStats.GetProfit();
        string sign = profit >= 0 ? "+" : "";
        textMeshForProfit.text = sign + profit.ToString("0.00") + "$";
        textMeshForProfit.color = profit >= 0 ? positiveColor : negativeColor;
    }


    public void Update()
    {
        PrintCountMoney();
    }

}