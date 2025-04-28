using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewsManager : MonoBehaviour
{
    public IReadOnlyList<News> ActiveNews { get => activeNews; }
    public static Action<News> OnNewsActivated;

    public GameObject NewsWindow;


    [SerializeField]
    private float newsChancePerTick;
    private List<News> activeNews = new List<News>();
    private List<NewsTemplate> templates;



    private void Awake()
    {
        templates = new List<NewsTemplate>(NewsParser.GetTemplates());
        OnNewsActivated = (news) => { Debug.Log($"Новость: {news.Title}"); };
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

        activeNews.Add(news);
        OnNewsActivated(news);

        PrintNews(news);
    }

    public void PrintNews(News news)
    {
        TextMeshProUGUI[] textComponents = NewsWindow.GetComponentsInChildren<TextMeshProUGUI>();

        if (textComponents.Length >= 2)
        {
            textComponents[0].text = news.Title;
            textComponents[1].text = news.Text;
        }
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
