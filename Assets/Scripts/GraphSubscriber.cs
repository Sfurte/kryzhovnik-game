using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphSubscriber : MonoBehaviour
{
    public Graph_Data Graph_Data;

    private void Start()
    {
        Clock.GetInstance().TickActions += () => Graph_Data.AddPoint((float)GameState.SelectedCompany.Stock.Price);
    }
}
