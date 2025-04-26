using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class Graph_Data : MonoBehaviour
{
    [SerializeField] int CountPoint = 5;

    public Graph_ graph_;

    public List<Vector3> DataArray;

    void Start()
    {
        graph_ = GetComponent<Graph_>();

        DataArray = new List<Vector3>(CountPoint);

        graph_.CreateXY();
        graph_.DrawGraph(DataArray.ToArray());  
        graph_.LocateGraph(DataArray.ToArray());

        // Эта строчка делает так чтобы каждый тик на график добавлялась точка с текущей ценой выбранной компании
        Clock.GetInstance().TickActions += () => AddPoint((float)GameState.SelectedCompany.Stock.Price);
    }

    public void AddRandomPoint()
    {
        AddPoint(DataArray.LastOrDefault().y + Random.Range(-1, 4));
    }

    public void AddPoint(float value)
    {
        DataArray.Add(new Vector3(DataArray.LastOrDefault().x + 1, value, 0));
        graph_.DrawGraph(DataArray.ToArray());
        graph_.LocateGraph(DataArray.ToArray());
    }
}
