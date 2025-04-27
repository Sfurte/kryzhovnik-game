using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Graph_ : MonoBehaviour
{



    [Header("X Axis Settings")]
    public float scaleXAxisDivisions = 1;   // масштаб оси делений
    public GameObject XDivision;             //префаб деления
    public int CountXDivision = 13;               // число делений
    public Vector2 XDivisionSize;            // размер самого деления
    public float xAxisTextOffset = 0.5f;     // отступ текста от деления

    [Header("Y Axis Settings")]
    public float scaleYAxisDivisions = 1;
    public GameObject YDivision;
    public int CountYDivision;
    public Vector2 YDivisionSize;
    public float yAxisTextOffset = 0.5f;

    public float DivisionYValue = 100;  // цена деления по Y


    [Header("Graph Settings")]
    public GameObject Point;            //Точка префаб
    public float Width;               //Толщина линии графика
    public float scaleGraphX = 1;    // Масштаб графика
    public float scaleGraphY = 1;     // Масштаб графика
    public int axisFontSize = 24;     //размер шрифта деления


    public GameObject horizontalLinePrefab; // Префаб горизонтальной линии 
    private GameObject currentHorizontalLine;
    public float lineLength = 10f;


    private GameObject[] Points;
    private Vector3[] Tops;
    private LineRenderer lineRenderer;


    private int currentFirstHour = 0;



    private List<GameObject> allGraphObjects = new List<GameObject>(); // все созданные объекты графика

    private void ClearAllGraphObjects()
    {
        foreach (var obj in allGraphObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        allGraphObjects.Clear();


        Points = null;
    }

    public void CreateXY()
    {
        ClearAllGraphObjects(); 

        Vector3 Position = transform.position;

        for (int i = 0; i < CountXDivision; i++)
        {
            int hour = (currentFirstHour + i) % 24;
            Vector3 divisionPos = Position + new Vector3(i * scaleXAxisDivisions, 0, 0);

            GameObject division = Instantiate(XDivision, divisionPos, transform.rotation);
            division.transform.localScale = new Vector3(XDivisionSize.x, XDivisionSize.y, 1f);
            allGraphObjects.Add(division);

            Vector3 textPos = divisionPos + new Vector3(0, -xAxisTextOffset, 0);
            GameObject textObj = CreateTextDivision(textPos, FormatTime(hour), axisFontSize);
            allGraphObjects.Add(textObj);
        }

        for (int i = 0; i < CountYDivision; i++)
        {
            Vector3 divisionPos = Position + new Vector3(0, i * scaleYAxisDivisions, 0);
            GameObject division = Instantiate(YDivision, divisionPos, transform.rotation);
            division.transform.localScale = new Vector3(YDivisionSize.x, YDivisionSize.y, 1f);
            allGraphObjects.Add(division);

            Vector3 textPos = divisionPos + new Vector3(-yAxisTextOffset, 0, 0);
            GameObject textObj = CreateTextDivision(textPos, (i * DivisionYValue).ToString(), axisFontSize);
            allGraphObjects.Add(textObj);
        }
    }

    public void DrawGraph(Vector3[] arrayPoints)
    {
        if (Points != null)
        {
            foreach (var point in Points)
            {
                if (point != null) Destroy(point);
            }
        }

        Tops = arrayPoints;
        Points = new GameObject[arrayPoints.Length];
        lineRenderer = GetComponent<LineRenderer>();

        for (int i = 0; i < Points.Length; i++)
        {
            Points[i] = Instantiate(Point, Vector3.zero, transform.rotation);
            allGraphObjects.Add(Points[i]); 
        }
    }

    

    public void ShiftHoursLeft()
    {
        currentFirstHour = (currentFirstHour + 1) % 24;
        CreateXY();
    }

    public GameObject CreateTextDivision(Vector3 position, string value, int fontSize)
    {
        GameObject textObj = new GameObject("TimeDivision");
        textObj.transform.position = position;

        TextMeshPro tmp = textObj.AddComponent<TextMeshPro>();
        tmp.text = value;
        tmp.fontSize = fontSize;
        tmp.alignment = TextAlignmentOptions.Center;

        return textObj;
    }

    private string FormatTime(int hour)
    {
        return string.Format("{0:00}:00", hour);
    }

    private void UpdateHorizontalLine(Vector3[] points)
    {
        if (points == null || points.Length == 0) return;

        //  float yPos = points[points.Length - 1].y * scaleGraphY;
        Vector3 linePosition = transform.position + new Vector3(points[points.Length - 1].x * scaleGraphY, points[points.Length - 1].y * scaleGraphY, 0);

        if (currentHorizontalLine == null)
        {
            currentHorizontalLine = Instantiate(horizontalLinePrefab, transform);
        }

        currentHorizontalLine.transform.position = linePosition;
        currentHorizontalLine.transform.localScale = new Vector3(lineLength, 0.01f, 1);
    }



    public void LocateGraph(Vector3[] arrPoint)
    {
        Vector3 Position = transform.position;

        for (int i = 0; i < arrPoint.Length; i++)
        {
            Tops[i] = Position + new Vector3(arrPoint[i].x * scaleGraphX, arrPoint[i].y * scaleGraphY, 0);
        }

        for (int i = 0; i < arrPoint.Length; i++)
        {
            Points[i].transform.position = Tops[i];

        }
        lineRenderer.SetWidth(Width, Width);
        lineRenderer.positionCount = Tops.Length;
        lineRenderer.SetPositions(Tops);

        
    }

    public void UpdateGraph(Vector3[] DataArray)
    {
        ClearAllGraphObjects();
        ShiftHoursLeft();
        CreateXY();
        DrawGraph(DataArray);
        UpdateHorizontalLine(DataArray);
        LocateGraph(DataArray);
    }

    public void CreateGraph(Vector3[] DataArray)
    {
        ClearAllGraphObjects();
        CreateXY();
        DrawGraph(DataArray);
        UpdateHorizontalLine(DataArray);
        LocateGraph(DataArray);
    }


}
