using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class DividendsPanel : MonoBehaviour
{
    [SerializeField] private GameObject Window; 
    [SerializeField] private Button openButton;     

    [SerializeField] private string windowText = "Диведенды";
    [SerializeField] private TMP_Text textComponent;   

    private void Start()
    {
        openButton.onClick.AddListener(ToggleWindow);

        if (textComponent != null)
            textComponent.text = windowText;
    }

    public void ToggleWindow()
    {
        Window.SetActive(!Window.activeSelf);
    }

    public void SetWindowText(string newText)
    {
        windowText = newText;
        if (textComponent != null)
            textComponent.text = windowText;
    }

    public void Update()
    {
        string money = (GameState.SelectedCompany.Stock.DividendsPerShare *
            GameState.SelectedCompany.Stock.Price).ToString("0.00") + "$";
    SetWindowText($"C каждой акции будет выплачено {money}");
    }
}
