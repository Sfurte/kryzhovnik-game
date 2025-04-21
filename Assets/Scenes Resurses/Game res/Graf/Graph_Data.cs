using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Graph_Data : MonoBehaviour
{
    [SerializeField] int CountPoint = 5;

    public Graph_ graph_ = new Graph_();
  
    void Start()
    { 
        
    
        var DataArray = new Vector3[CountPoint]; 

        for(int i =0; i/2 < CountPoint; i += 2)
        {
            DataArray[i / 2] = new Vector3(Random.Range(i, i + 2), Random.Range(0, 10), 0);
        }

            graph_.CreateXY();
        graph_.DrawGraph(DataArray);
        graph_.LocateGraph(DataArray);
    }

    

    void Update()
    {
        
    }
}
