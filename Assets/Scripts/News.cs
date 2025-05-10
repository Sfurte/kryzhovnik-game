using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class News
{
    public string Title { get; private set; }
    public string Text { get; private set; }
    public Company AffectedCompany { get; private set; }
    public NewsImpact Impact { get; private set; }

    public News(string title, string text, Company affectedCompany, int impactDuration, float impactOnStocks)
    {
        Title = title;
        Text = text;
        AffectedCompany = affectedCompany;

        Impact = new NewsImpact(impactOnStocks, impactDuration);
    }
}
