using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �����, ����������� ����� ����� ��������.
/// </summary>
public class CompanyStock
{
    /// <summary>
    /// ������� ���� �� ���� �����
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
    /// ������ ���������� �������� ���� �� �����,
    /// ��� ������ ������� - ����� ������ ���������� ����,
    /// � ��������� - ������� ����.
    /// </summary>
    public IReadOnlyList<double> PriceLog { get => priceLog; }
    /// <summary>
    /// ����� ����������, ������������� �� ���� ����� (���������� ��������, �� �������)
    /// </summary>
    public double DividendsPerShare { get; private set; }
    /// <summary>
    /// ����� �����, ��������� �������
    /// </summary>
    public int BoughtAmount { get; private set; }

    /// <summary>
    /// �� ������� �������� ����� ������ ������ �����
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
        PlayerStats.Money -= Price * amount;
        BoughtAmount += amount;
    }

    /// <summary>
    /// ����������� ������ ��������� � ����������� �� ����� �������� �����
    /// </summary>
    public void PayDividends()
    {
        PlayerStats.Money += DividendsPerShare * BoughtAmount;
    }
}
