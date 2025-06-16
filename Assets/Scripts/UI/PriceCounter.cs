using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PriceCounter : MonoBehaviour
{
    private void Start()
    {
        var textMesh = GetComponent<TMP_Text>();
        textMesh.text = GameState.SelectedCompany.Stock.Price.ToString("0.00") + "$";


        Clock.GetInstance().TickActions += () => { textMesh.text = GameState.SelectedCompany.Stock.Price.ToString("0.00") + "$";  };
    }

    private void Update()
    {
        var textMesh = GetComponent<TMP_Text>();
        textMesh.text = GameState.SelectedCompany.Stock.Price.ToString("0.00") + "$";


        if (GameState.SelectedCompany.Stock.Price.ToString() != textMesh.text)
            textMesh.text = GameState.SelectedCompany.Stock.Price.ToString("0.00") + "$"; 
    }
}
