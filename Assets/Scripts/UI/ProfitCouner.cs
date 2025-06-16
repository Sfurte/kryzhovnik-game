using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfitCounter : MonoBehaviour
{
    public GameObject TextWindow;

    public void PrintProfitMoney()
    {
        var textMesh = TextWindow.GetComponent<TMP_Text>();

        TextMeshProUGUI[] textComponents = GetComponentsInChildren<TextMeshProUGUI>();
        textComponents[0].text = PlayerStats.Money.ToString("0.00") + "$";



    }

    public void Update()
    {
    }
}
