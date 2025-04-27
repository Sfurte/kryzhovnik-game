using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Graph_Data : MonoBehaviour
{
    [SerializeField] int CountPoint = 5;
    public int ScaleX = 3;
    public Graph_ graph_;
    public List<Vector3> DataArray;

    void Start()
    {
        InitializeData();
    }

    void InitializeData()
    {
        DataArray = new List<Vector3>(CountPoint);

        for (int i = 0; i < CountPoint; i++)
        {
            DataArray.Add(new Vector3(i * ScaleX, Random.Range(10, 100), 0));
        }

        graph_.CreateXY();
        graph_.DrawGraph(DataArray.ToArray());
        graph_.LocateGraph(DataArray.ToArray());
    }

    public void AddRandomPoint()
    {
        DataArray.RemoveAt(0);

        Vector3 lastPoint = DataArray.Last();
        DataArray.Add(new Vector3(lastPoint.x + ScaleX, Random.Range(10, 100), 0));

        ShiftPointsLeft();

        UpdateGraph();
    }

    public void AddPoint(float value)
    {
        DataArray.RemoveAt(0);

        Vector3 lastPoint = DataArray.Last();
        DataArray.Add(new Vector3(lastPoint.x + ScaleX, value, 0));

        ShiftPointsLeft();

        UpdateGraph();
    }

    private void ShiftPointsLeft()
    {
        for (int i = 0; i < DataArray.Count; i++)
        {
            DataArray[i] = new Vector3(DataArray[i].x - ScaleX, DataArray[i].y, 0);
        }
    }

    private void UpdateGraph()
    {
        graph_.ShiftHoursLeft();
        graph_.CreateXY();
        graph_.DrawGraph(DataArray.ToArray());
        graph_.LocateGraph(DataArray.ToArray());

    }
}