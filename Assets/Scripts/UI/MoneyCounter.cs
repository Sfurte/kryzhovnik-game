using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCounter : MonoBehaviour
{
    void Start()
    {
        Clock.GetInstance().TickActions += () => PrintCountMoney();
    }

    public void PrintCountMoney()
    {
        TextMeshProUGUI[] textComponents = GetComponentsInChildren<TextMeshProUGUI>();
            textComponents[0].text = PlayerStats.Money.ToString() + "€$";
    }
}
