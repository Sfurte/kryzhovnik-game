using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий акции одной компании.
/// </summary>
public class CompanyStock
{
    /// <summary>
    /// Текущая цена за одну акцию
    /// </summary>
    public double Price
    {
        get => price;
        set
        {
            price = value;
            priceLog.Add(value);
        }
    }
    /// <summary>
    /// Список предыдущих значений цены за акцию,
    /// где первый элемент - самая старая записанная цена,
    /// а последний - текущая цена.
    /// </summary>
    public IReadOnlyList<double> PriceLog { get => priceLog; }
    /// <summary>
    /// Объем дивидендов, выплачиваемых за одну акцию (абсолютное значение, не процент)
    /// </summary>
    public double DividendsPerShare { get; private set; }
    /// <summary>
    /// Число акций, купленных игроком
    /// </summary>
    public int BoughtAmount { get; private set; }

    /// <summary>
    /// На покупку скольких акций игроку хватит денег
    /// </summary>
    public int MaxBuyAmount { get => (int)(PlayerStats.Money / Price); }

    private double price;
    private List<double> priceLog = new List<double>();

    public CompanyStock(double price, double dividendsPerShare)
    {
        Price = price;
        DividendsPerShare = dividendsPerShare;
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
        PlayerStats.Money -= Price * amount;
        BoughtAmount += amount;
    }

    /// <summary>
    /// Выплачивает игроку дивиденды в зависимости от числа купленых акций
    /// </summary>
    public void PayDividends()
    {
        PlayerStats.Money += DividendsPerShare * BoughtAmount;
    }
}
