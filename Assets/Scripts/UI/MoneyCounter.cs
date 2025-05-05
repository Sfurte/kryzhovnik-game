using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    public void PrintCountMoney()
    {
        TextMeshProUGUI[] textComponents = GetComponentsInChildren<TextMeshProUGUI>();
            textComponents[0].text = PlayerStats.Money.ToString() + "€$";
    }

    public void Update()
    {
         PrintCountMoney();
    }

}
