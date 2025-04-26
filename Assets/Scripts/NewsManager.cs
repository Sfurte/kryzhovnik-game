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
        Debug.Log($"Новость: {news.Title}");

        activeNews.Add(news);
    }

    public News GenerateNews()
    {
        var affectedCompany = Company.AllCompanies[Random.Range(0, Company.AllCompanies.Count)];

        return new News(
            $"У компании \"{affectedCompany.Name}\" сгорела штаб-квартира",
            $"{affectedCompany.Name} столкнулась с печальной ситуацией: сотрудник оставил утюг включённым на рабочем месте и всё сгорело. Ну не повезло блин. Курс акций обвалится походу.",
            affectedCompany,
            -affectedCompany.Stock.Price / 3);
    }
}
