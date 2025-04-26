using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph_ : MonoBehaviour
{
    public float scale;


    public GameObject XDivision;
    public int CountXDivision;
    public Vector2 XDivisionSize;

    public GameObject YDivision;
    public int CountYDivision;
    public Vector2 YDivisionSize;

    public GameObject Point;
    public float Width;
    GameObject[] Points;

    Vector3[] Tops;

    LineRenderer lineRenderer;

    public void CreateXY()
    {
        Vector3 Position = transform.position;


        for (int i = 1; i < CountXDivision; i++)
        {
            GameObject division = Instantiate(XDivision, Position +new Vector3(i * scale, 0, 0), transform.rotation);
            // Устанавливаем размер для X делений
            division.transform.localScale = new Vector3(XDivisionSize.x, XDivisionSize.y, 1f);

            division.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = i.ToString();
        }

        for (int i = 1; i < CountYDivision; i++)
        {
            GameObject division = Instantiate(YDivision, Position+ new Vector3(0, i * scale, 0), transform.rotation);
            // Устанавливаем размер для Y делений
            division.transform.localScale = new Vector3(YDivisionSize.x, YDivisionSize.y, 1f);
            division.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = i.ToString();
        }

    }

    public void DrawGraph(Vector3[] arrayPoints)
    {
        Tops = arrayPoints;
        Points = new GameObject[arrayPoints.Length];

        lineRenderer = GetComponent<LineRenderer>();

        for (int i = 0; i < Points.Length; i++)
            Points[i] = Instantiate(Point, Vector3.zero, transform.rotation);

    }

    public void LocateGraph(Vector3[] arrPoint)
    {
        Vector3 Position = transform.position;

        for (int i = 0; i < arrPoint.Length; i++)
        {
            Tops[i] = Position +  new Vector3(arrPoint[i].x * scale, arrPoint[i].y * scale, 0);
        }

        for (int i = 0; i < arrPoint.Length; i++)
        {
            Points[i].transform.position = Tops[i];

        }
        lineRenderer.SetWidth(Width, Width);
        lineRenderer.positionCount = Tops.Length;
        lineRenderer.SetPositions(Tops);
    }
}
