using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CompanyName : MonoBehaviour
{
    public GameObject TextWindow;


    private void Start()
    {
        var textMesh = TextWindow.GetComponent<TMP_Text>();
        textMesh.text = GameState.SelectedCompany.Name;


        Clock.GetInstance().TickActions += () => { textMesh.text = GameState.SelectedCompany.Name; };
    }

    private void Update()
    {
        var textMesh = TextWindow.GetComponent<TMP_Text>();
        textMesh.text = GameState.SelectedCompany.Name;

        if (GameState.SelectedCompany.Name != textMesh.text)
            textMesh.text = GameState.SelectedCompany.Name;
    }
}
