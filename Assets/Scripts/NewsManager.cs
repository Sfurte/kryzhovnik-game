using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsManager : MonoBehaviour
{
    public IReadOnlyList<News> ActiveNews { get => activeNews; }
    public static Action<News> OnNewsActivated;

    [SerializeField]
    private float newsChancePerTick;
    private List<News> activeNews = new List<News>();
    private List<NewsTemplate> templates;

    private void Awake()
    {
        templates = new List<NewsTemplate>(NewsParser.GetTemplates());
    }

    private void Start()
    {
        Clock.GetInstance().TickActions += () =>
        {
            if (newsChancePerTick >= UnityEngine.Random.value)
            {
                ActivateNews(GenerateNews());
            }
        };
    }

    public void ActivateNews(News news)
    {
        news.AffectedCompany.Stock.Price += news.ImpactOnStocks;
        Debug.Log($"Новость: {news.Title}");

        activeNews.Add(news);
        OnNewsActivated(news);
    }

    public News GenerateNews()
    {
        var affectedCompany = Company.AllCompanies[UnityEngine.Random.Range(0, Company.AllCompanies.Count)];
        var chosenTemplate = templates[UnityEngine.Random.Range(0, templates.Count)];

        return chosenTemplate.GetNews(affectedCompany);

        /*return new News(
            $"У компании \"{affectedCompany.Name}\" сгорела штаб-квартира",
            $"{affectedCompany.Name} столкнулась с печальной ситуацией: сотрудник оставил утюг включённым на рабочем месте и всё сгорело. Ну не повезло блин. Курс акций обвалится походу.",
            affectedCompany,
            -affectedCompany.Stock.Price / 3);*/
    }
}
