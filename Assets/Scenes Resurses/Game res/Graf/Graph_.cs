using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TMPro;
using UnityEngine;

public class Graph_ : MonoBehaviour
{
    public GameObject Window;

    [Header("X Axis Settings")]
    public GameObject XDivision;             //������ �������
    public int CountXDivision = 13;               // ����� �������
    public Vector2 XDivisionSize;            // ������ ������ �������
    public float xAxisTextOffset = 0.5f;     // ������ ������ �� �������

    [Header("Y Axis Settings")]
    public GameObject YDivision;
    public int CountYDivision;
    public Vector2 YDivisionSize;
    public float yAxisTextOffset = 0.5f;


    [Header("Graph Settings")]
    public int CountPoint;
    public GameObject Point;            //����� ������
    public float Width;               //������� ����� �������
                                      // public float scaleGraphX = 1;    // ������� �������
    public float scaleGraphY = 0.03f;     // ������� �������
    public int axisFontSize = 24;     //������ ������ �������

    public int MinDivisionYValue = 10;
    public int YDivisionCoeff = 5;
    private int currentYDivisionScale = 1;

    private float scaleGraphX = 1;
    // public float scaleGraphY = 1;

    public int xAxisStep = 2;


    [Header("Line Settings")]
    public GameObject horizontalLinePrefab; // ������ �������������� ����� 
    private GameObject currentHorizontalLine;
    public float lineLength = 10f;

    [Header("Points Settings")]
    private GameObject[] Points;
    private Vector3[] Tops;
    private LineRenderer lineRenderer;




    private int currentFirstHour = 15;
    private int xAxisOffset = 0;

    private List<GameObject> allGraphObjects = new List<GameObject>(); // ��� ��������� ������� �������


    [Header("Axis Settings")]

    private float scaleXAxisDivisions = 1;
    private float scaleYAxisDivisions = 1;
    private float DivisionYValue = 100;  // ���� ������� �� Y



    private void CalculateScale()
    {
        RectTransform rectTransform = Window.GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        float graphWidth = corners[2].x - transform.position.x;
        float graphHeight = corners[2].y - transform.position.y;

        scaleXAxisDivisions = graphWidth / (CountXDivision);
        scaleGraphX = graphWidth / Mathf.Max(1, CountPoint);


        scaleYAxisDivisions = graphHeight / CountYDivision;

        CalculateDivisionYValue(graphHeight);
    }

    private void CalculateDivisionYValue(float graphHeight)
    {
        float maxValue = Tops.Max(p => p.y);
        if (maxValue > MinDivisionYValue * currentYDivisionScale)
            currentYDivisionScale *= YDivisionCoeff;
        else if (maxValue < MinDivisionYValue * currentYDivisionScale && currentYDivisionScale > 1)
            currentYDivisionScale /= YDivisionCoeff;
        DivisionYValue = MinDivisionYValue * currentYDivisionScale;
    }



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
        CalculateScale();
        ClearAllGraphObjects();

        Vector3 Position = transform.position;

        for (int i = 0; i < CountXDivision; i++)
        {
            int value = ((i + xAxisOffset) * xAxisStep) % 30;
            Vector3 divisionPos = Position + new Vector3(i * scaleXAxisDivisions, 0, 0);

            GameObject division = Instantiate(XDivision, divisionPos, transform.rotation);
            division.transform.localScale = new Vector3(XDivisionSize.x, XDivisionSize.y, 1f);
            allGraphObjects.Add(division);

            Vector3 textPos = divisionPos + new Vector3(0, -xAxisTextOffset, 0);
            GameObject textObj = CreateTextDivision(textPos, value.ToString(), axisFontSize);
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
        if (Clock.GetInstance().TickNumber % 2 == 0)
        {
            xAxisOffset++; 
            CreateXY();    
        }
    }

    public GameObject CreateTextDivision(Vector3 position, string value, int fontSize)
    {
        GameObject textObj = new GameObject("TimeDivision");
        textObj.transform.position = position;

        TextMeshPro tmp = textObj.AddComponent<TextMeshPro>();
        tmp.text = value;
        tmp.fontSize = fontSize;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.color = UnityEngine.Color.black;

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
            Tops[i] = Position + new Vector3(
                i * scaleGraphX,
                arrPoint[i].y * scaleGraphY,
                0);
        }



        lineRenderer.positionCount = Tops.Length;
        lineRenderer.SetPositions(Tops);


    }

    public void UpdateGraph(Vector3[] DataArray)
    {
        ShiftHoursLeft();
        ClearAllGraphObjects();

        DrawGraph(DataArray);
       // UpdateHorizontalLine(DataArray);
        LocateGraph(DataArray);
        CreateXY();
    }

    public void CreateGraph(Vector3[] DataArray)
    {
        ClearAllGraphObjects();

        DrawGraph(DataArray);
      //  UpdateHorizontalLine(DataArray);
        LocateGraph(DataArray);
        CreateXY();
    }
}