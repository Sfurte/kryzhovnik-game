using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControler : MonoBehaviour
{

    public void BuyOne()
    {
        if(GameState.SelectedCompany.Stock.TryBuy(1))
            Debug.Log("Куплена 1 акция");
    }

    public void SellOne()
    {
        if (GameState.SelectedCompany.Stock.TrySell(1))
            Debug.Log("Продана 1 акция");
    }
}
