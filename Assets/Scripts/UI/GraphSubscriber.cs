using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GraphSubscriber : MonoBehaviour
{
    public Graph_Data Graph_Data;
    private Company previousCompany = GameState.SelectedCompany;

    private void Start()
    {
        Clock.GetInstance().TickActions += () => Graph_Data.AddPoint(GameState.SelectedCompany.Stock.PriceLog.Last());
    }

    void Update()
    {
        if (previousCompany != GameState.SelectedCompany)
            Graph_Data.SetDataArray(GameState.SelectedCompany.Stock.PriceLog.ToList());
        previousCompany = GameState.SelectedCompany;

    }

}
