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
    public float Price
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

    private float price;
    private List<float> priceLog = new List<float>();

    public CompanyStock(float price, float dividendsPerShare)
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
