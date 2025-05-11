using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewsManager : MonoBehaviour
{
    public static IReadOnlyList<News> ActiveNews { get => activeNews; }
    public static Action<News> OnNewsActivated;

    public GameObject NewsWindow;

    [SerializeField]
    private float newsChancePerTick;
    [SerializeField]
    private int randomNewsStartDay;

    private static List<News> activeNews = new List<News>();
    private List<NewsTemplate> templates;

    private void Awake()
    {
        templates = new List<NewsTemplate>(NewsParser.GetTemplates());
        OnNewsActivated = (news) => { Debug.Log($"�������: {news.Title}"); };
    }

    private void Start()
    {
        Clock.GetInstance().AddDelayedAction(() => StartRandomNewsGeneration(), randomNewsStartDay);
    }

    /// <summary>
    /// �������� ���������� �������, � ����� �������� �������� ���������� ��
    /// </summary>
    public void InitiateNews(News news, int delay)
    {
        PrintNews(news);
        Clock.GetInstance().AddDelayedAction(() => ActivateNews(news), delay);
    }

    /// <summary>
    /// ���������� ������� �������� ������ �� ���� �����
    /// </summary>
    public void ActivateNews(News news)
    {
        news.AffectedCompany.Stock.newsImpacts.Add(news.Impact);

        activeNews.Add(news);
        OnNewsActivated(news);
    }

    private void PrintNews(News news)
    {
        TextMeshProUGUI[] textComponents = NewsWindow.GetComponentsInChildren<TextMeshProUGUI>();

        if (textComponents.Length >= 2)
        {
            textComponents[0].text = news.Title;
            textComponents[1].text = news.Text;
        }
    }

    private News GenerateNews()
    {
        var affectedCompany = Company.AllCompanies[UnityEngine.Random.Range(0, Company.AllCompanies.Count)];
        var chosenTemplate = templates[UnityEngine.Random.Range(0, templates.Count)];

        return chosenTemplate.GetNews(affectedCompany);

        /*return new News(
            $"� �������� \"{affectedCompany.Name}\" ������� ����-��������",
            $"{affectedCompany.Name} ����������� � ��������� ���������: ��������� ������� ���� ���������� �� ������� ����� � �� �������. �� �� ������� ����. ���� ����� ��������� ������.",
            affectedCompany,
            -affectedCompany.Stock.Price / 3);*/
    }

    private void StartRandomNewsGeneration()
    {
        Clock.GetInstance().TickActions += () =>
        {
            if (newsChancePerTick >= UnityEngine.Random.value)
            {
                InitiateNews(GenerateNews(), 1);
            }
        };
    }
}
