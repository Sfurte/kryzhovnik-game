using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph_ : MonoBehaviour
{
    public float scale;

    public GameObject XDivision;
    public int CountXDivision;

    public GameObject YDivision;
    public int CountYDivision;

    public void CreateXY()
    {
        for(int i=1;i<CountXDivision;i++)
        {
            GameObject division;
            division = Instantiate(XDivision, new Vector3(i * scale, 0, 0), transform.rotation);
        }

        for (int i = 1; i < CountYDivision; i++)
        {
            GameObject division;
            division = Instantiate(YDivision, new Vector3(0,i * scale, 0), transform.rotation);
        }

    }
}
