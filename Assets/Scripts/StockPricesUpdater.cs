using UnityEngine;
using System;

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
    }

    private void UpdateAllNewsImpacts()
    {
        foreach (var news in NewsManager.ActiveNews)
        {
            news.Impact.NextDay();
        }
    }

    private void UpdateAllPrices()
    {
        foreach (var company in Company.AllCompanies)
        {
            company.Stock.BasePrice = GetNextBasePrice(company.Stock);
            Debug.Log($"Теперь у компании \"{company.Name}\" цена акции {company.Stock.Price}");
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