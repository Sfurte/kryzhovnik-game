using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsManager : MonoBehaviour
{
    public IReadOnlyList<News> ActiveNews { get => activeNews; }

    [SerializeField]
    private float newsChancePerTick;
    private List<News> activeNews = new List<News>();

    private void Start()
    {
        Clock.GetInstance().TickActions += () =>
        {
            if (newsChancePerTick >= Random.value)
            {
                ActivateNews(GenerateNews());
            }
        };
    }

    public void ActivateNews(News news)
    {
        news.AffectedCompany.Stock.Price += news.ImpactOnStocks;
        Debug.Log($"�������: {news.Title}");

        activeNews.Add(news);
    }

    public News GenerateNews()
    {
        var affectedCompany = Company.AllCompanies[Random.Range(0, Company.AllCompanies.Count)];

        return new News(
            $"� �������� \"{affectedCompany.Name}\" ������� ����-��������",
            $"{affectedCompany.Name} ����������� � ��������� ���������: ��������� ������� ���� ���������� �� ������� ����� � �� �������. �� �� ������� ����. ���� ����� ��������� ������.",
            affectedCompany,
            -affectedCompany.Stock.Price / 3);
    }
}
