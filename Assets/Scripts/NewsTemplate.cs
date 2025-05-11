using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NewsTemplate
{
    public string TitleTemplate;
    public string TextTemplate;
    public int ImpactDuration;
    public double ImpactOnStocksCoefficient;
    public bool IsImpactMultiplicative;

    public News GetNews(Company affectedCompany)
    {
        string title = TitleTemplate.Replace("%company_name%", affectedCompany.Name);
        string text = TextTemplate.Replace("%company_name%", affectedCompany.Name);
        int impactDuration = ImpactDuration;
        float impactOnStocks = (IsImpactMultiplicative ? affectedCompany.Stock.Price : 1) * (float)ImpactOnStocksCoefficient;

        return new News(title, text, affectedCompany, impactDuration, impactOnStocks);
    }
}