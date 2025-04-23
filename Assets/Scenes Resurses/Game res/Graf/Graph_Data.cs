using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;


public class Graph_Data : MonoBehaviour
{
    [SerializeField] int CountPoint = 5;

    public Graph_ graph_ = new Graph_();

    public List<Vector3> DataArray ;

    void Start()
    {
        DataArray = new List<Vector3>(CountPoint);

            graph_.CreateXY();
        graph_.DrawGraph(DataArray.ToArray());
        graph_.LocateGraph(DataArray.ToArray());
    }

    public void AddPoint()
    {
        DataArray.Add(new Vector3(DataArray.LastOrDefault().x +1, DataArray.LastOrDefault().y+ Random.Range(-1, 4), 0));
        graph_.DrawGraph(DataArray.ToArray());
        graph_.LocateGraph(DataArray.ToArray());
    }

    

    void Update()
    {
        
    }
}
