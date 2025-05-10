using System.Collections.Generic;
using UnityEngine;

public class NewsImpact
{
    public float Value;
    public int DurationLeft;

    public NewsImpact(float value, int duration)
    {
        Value = value;
        DurationLeft = duration;
    }

    public void NextDay()
    {
        if(DurationLeft <= 0)
        {
            Value = 0;
        }
        DurationLeft--;

        Value -= Value / DurationLeft;
    }
}