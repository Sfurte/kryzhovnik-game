using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{

    public void BuyOne()
    {
        GameState.SelectedCompany.Stock.TryBuy(1);
        Debug.Log("������� 1 �����");
    }
}
