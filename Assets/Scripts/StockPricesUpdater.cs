using System.Collections;
using System.Collections.Generic;
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
    private float GetNextPrice(CompanyStock stock)
    {
        return stock.Price + Random.Range(-FluctuationCoefficient, FluctuationCoefficient);
    }
}