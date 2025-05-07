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

    private void UpdateAllPrices()
    {
        foreach (var company in Company.AllCompanies)
        {
            company.Stock.Price = GetNextPrice(company.Stock);
            Debug.Log($"Теперь у компании \"{company.Name}\" цена акции {company.Stock.Price}");
        }
    }

    /// <summary>
    /// Вычисляет цену акции на следующем ходу
    /// </summary>
    /// <param name="stock">Акции компании</param>
    public float GetNextPrice(CompanyStock stock)
    {
        return Math.Abs(stock.Price + UnityEngine.Random.Range(-FluctuationCoefficient, FluctuationCoefficient));
    }
}