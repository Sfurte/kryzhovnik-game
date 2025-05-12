using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����, ����������� ����� ����� ��������.
/// </summary>
public class CompanyStock
{
    public int CountStartPricePoint= 60;

    /// <summary>
    /// ������� ���� �� ���� �����
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
    /// ������ ���������� �������� ���� �� �����,
    /// ��� ������ ������� - ����� ������ ���������� ����,
    /// � ��������� - ������� ����.
    /// </summary>
    public IReadOnlyList<float> PriceLog { get => priceLog; }
    /// <summary>
    /// ����� ����������, ������������� �� ���� ����� (���������� ��������, �� �������)
    /// </summary>
    public float DividendsPerShare { get; private set; }
    /// <summary>
    /// ����� �����, ��������� �������
    /// </summary>
    public int BoughtAmount { get; private set; }

    /// <summary>
    /// �� ������� �������� ����� ������ ������ �����
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
    /// �������� ������ ��������� ����� ����� �� ������ ������
    /// </summary>
    /// <param name="amount">����� ����� � �������</param>
    /// <returns>true, ���� ������� �������
    /// false, ���� ������ �� ������� �����</returns>
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
    /// �������� ������� �����, �� ������� ������ ������ �����
    /// </summary>
    public void BuyMax()
    {
        Buy(MaxBuyAmount);
    }

    /// <summary>
    /// �������� �������� ����� ����� �� ������ ������
    /// </summary>
    /// <param name="amount">����� ����� � �������</param>
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
    /// ����������� ������ ��������� � ����������� �� ����� �������� �����
    /// </summary>
    public void PayDividends()
    {
        float dividends = DividendsPerShare * BoughtAmount* Price;
        PlayerStats.Money += dividends;
    }
}
