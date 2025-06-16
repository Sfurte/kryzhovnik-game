using TMPro;
using UnityEngine;

public class ActionsCounter : MonoBehaviour
{
    public GameObject TextWindow;


    private void Start()
    {
        var textMesh = TextWindow.GetComponent<TMP_Text>();
        textMesh.text = GameState.SelectedCompany.Stock.BoughtAmount.ToString();
    }

    private void Update()
    {
        var textMesh = TextWindow.GetComponent<TMP_Text>();
        textMesh.text = GameState.SelectedCompany.Stock.BoughtAmount.ToString();
    }
}
