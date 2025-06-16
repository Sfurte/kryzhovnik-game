using System;
using System.Linq;
using UnityEngine;

/// <summary>
/// Отвечает за изменение цены акций компании согласно некой модели
/// </summary>
public class StockPricesUpdater : MonoBehaviour
{
    [SerializeField]
    private float FluctuationCoefficient;

    private void Start()
    {
        for (int i = 0; i < 100; i++)
            UpdateAllPrices();
        Clock.GetInstance().TickActions += UpdateAllPrices;
        Clock.GetInstance().TickActions += UpdateAllNewsImpacts;
    }

    private void UpdateAllNewsImpacts()
    {
        if (Clock.GetInstance().TickNumber < 15)
            return;
        foreach (var news in NewsManager.ActiveNews)
        {
            news.Impact.NextDay();
        }
    }

    private void UpdateAllPrices()
    {
        if (Clock.GetInstance().TickNumber < 15)
        {
            foreach (var data in TutorialPries.CompanysData)
            {
                if (Clock.GetInstance().TickNumber < data.Prices.Count)
                {
                    Company.AllCompanies.Where(c => c.Name == data.CompanyName).FirstOrDefault().Stock.BasePrice = data.Prices[Clock.GetInstance().TickNumber];

                }
                else
                    Company.AllCompanies.Where(c => c.Name == data.CompanyName).FirstOrDefault().Stock.BasePrice = Company.AllCompanies.Where(c => c.Name == data.CompanyName).FirstOrDefault().Stock.BasePrice;
            }
        }

        else
        {
            foreach (var company in Company.AllCompanies)
            {
                company.Stock.BasePrice = GetNextBasePrice(company.Stock);
                Debug.Log($"Теперь у компании \"{company.Name}\" цена акции {company.Stock.Price} (базовая: {company.Stock.BasePrice})");
            }
        }



    }

    /// <summary>
    /// Вычисляет цену акции на следующем ходу
    /// </summary>
    /// <param name="stock">Акции компании</param>
    public float GetNextBasePrice(CompanyStock stock)
    {

        return Math.Abs(stock.BasePrice + UnityEngine.Random.Range(-FluctuationCoefficient, FluctuationCoefficient));
    }
}