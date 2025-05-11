using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий компанию, которая выпускает акции
/// </summary>
public class Company
{
    public static IReadOnlyList<Company> AllCompanies { get => allCompanies; }
    public string Name { get; }
    public CompanyStock Stock { get; }

    private static List<Company> allCompanies = new List<Company>();

    public Company(string name, float sharePrice, float dividendsPerShare)
    {
        Name = name;
        Stock = new CompanyStock(sharePrice, dividendsPerShare);
        allCompanies.Add(this);
    }

    public static void CreateListCompanies(List<Company> _companies)
    {
        allCompanies = _companies;
    }
}
