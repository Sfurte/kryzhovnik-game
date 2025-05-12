using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class Graph_Data : MonoBehaviour
{
    [SerializeField] int CountPoint = 60;
    public int ScaleX = 3;
    public Graph_ graph_;
    public List<Vector3> DataList = new List<Vector3>();


     void Start()
    {
        int lenghtPriceLog = GameState.SelectedCompany.Stock.PriceLog.Count;
        for (int i = 0; i < 60; i++)
        {
            DataList.Add(new Vector3(i * ScaleX, GameState.SelectedCompany.Stock.PriceLog[lenghtPriceLog- CountPoint +i], 0));
        }

        CreateGraph();
    }

    //public void AddRandomPoint()
    //{
    //    DataList.RemoveAt(0);

    //    Vector3 lastPoint = DataList.Last();
    //    DataList.Add(new Vector3(lastPoint.x + ScaleX, UnityEngine.Random.Range(10, 100), 0));

    //    ShiftPointsLeft();

    //    UpdateGraph();
    //}

    public void AddPoint(float value)
    {
        if (DataList.Count > CountPoint) 
            DataList.RemoveAt(0);

        Vector3 lastPoint = DataList.Last();
        DataList.Add(new Vector3(lastPoint.x + ScaleX, value, 0));

        ShiftPointsLeft();

        UpdateGraph();
        Debug.Log($" Добавлена точка {value}");
    }

    public void SetDataArray(List<Vector3> newDataList)
    {
        DataList = newDataList.Skip(Math.Max(0, newDataList.Count - CountPoint)).ToList();

        UpdateGraph();
    }

    public void SetDataArray(List<float> newDataList)
    {
        List<Vector3> dtlist = new List<Vector3>();

        int startIndex = Math.Max(0, newDataList.Count - CountPoint);

        for (int i = startIndex; i < newDataList.Count; i++)
        {
            float normalizedX = i - startIndex;
            dtlist.Add(new Vector3(normalizedX * ScaleX, newDataList[i], 0));
        }

        DataList = dtlist;
        CreateGraph();
    }


    private void ShiftPointsLeft()
    {
        for (int i = 0; i < DataList.Count; i++)
        {
            DataList[i] = new Vector3(DataList[i].x - ScaleX, DataList[i].y, 0);
        }
    }

    private void UpdateGraph()
    {
        graph_.UpdateGraph(DataList.ToArray());

    }

    private void CreateGraph()
    {
        graph_.CreateGraph(DataList.ToArray());

    }


}