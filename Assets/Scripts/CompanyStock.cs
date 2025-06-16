using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий акции одной компании.
/// </summary>
public class CompanyStock
{
    public int CountStartPricePoint= 60;

    /// <summary>
    /// Текущая цена за одну акцию
    /// </summary>
    public float Price
    {
        get
        {
            float price = basePrice;
            foreach (var impact in newsImpacts)
            {
                price += impact.Value;
            }
            return price;
        }
    }

    public float BasePrice
    {
        get => basePrice;
        set
        {
            basePrice = value;
            priceLog.Add(Price);
        }
    }
    public List<NewsImpact> newsImpacts = new List<NewsImpact>();
    /// <summary>
    /// Список предыдущих значений цены за акцию,
    /// где первый элемент - самая старая записанная цена,
    /// а последний - текущая цена.
    /// </summary>
    public IReadOnlyList<float> PriceLog { get => priceLog; }
    /// <summary>
    /// Объем дивидендов, выплачиваемых за одну акцию (абсолютное значение, не процент)
    /// </summary>
    public float DividendsPerShare { get; private set; }
    /// <summary>
    /// Число акций, купленных игроком
    /// </summary>
    public int BoughtAmount { get; private set; }

    /// <summary>
    /// На покупку скольких акций игроку хватит денег
    /// </summary>
    public int MaxBuyAmount { get => (int)(PlayerStats.Money / Price); }

    private float basePrice;
    private List<float> priceLog = new List<float>();

    public CompanyStock(float price, float dividendsPerShare)
    {
        this.basePrice = price;
        DividendsPerShare = dividendsPerShare;

        for (int i = 0; i < CountStartPricePoint; i++)
        {
            priceLog.Add(50);
        }
    }

    /// <summary>
    /// Пытается купить некоторое число акций на деньги игрока
    /// </summary>
    /// <param name="amount">Число акций к покупке</param>
    /// <returns>true, если покупка успешна
    /// false, если игроку не хватает денег</returns>
    public bool TryBuy(int amount)
    {
        if(amount > MaxBuyAmount)
        {
            return false;
        }
        Buy(amount);
        return true;
    }

    /// <summary>
    /// Покупает столько акций, на сколько игроку хватит денег
    /// </summary>
    public void BuyMax()
    {
        Buy(MaxBuyAmount);
    }

    /// <summary>
    /// Покупает заданное число акций на деньги игрока
    /// </summary>
    /// <param name="amount">Число акций к покупке</param>
    public void Buy(int amount)
    {
        float TotalPrice = Price * amount;

        PlayerStats.Money -= TotalPrice;
        BoughtAmount += amount;
        
    }

    public bool TrySell(int amount)
    {
        if (amount > BoughtAmount)
        {
            return false;
        }

        Sell(amount);
        return true;
    }

    public void Sell(int amount)
    {
        float TotalPrice = Price * amount;

        PlayerStats.Money += TotalPrice;
        BoughtAmount -= amount;

    }

    /// <summary>
    /// Выплачивает игроку дивиденды в зависимости от числа купленых акций
    /// </summary>
    public void PayDividends()
    {
        float dividends = DividendsPerShare * BoughtAmount* Price;
        PlayerStats.Money += dividends;
    }
}
