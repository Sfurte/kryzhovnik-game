using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс, описывающий компанию, которая выпускает акции
/// </summary>
public class Company
{
    public static List<Company> AllCompanies = new List<Company>();
    public string Name { get; }
    public CompanyStock Stock { get; }

    public Company(string name, double sharePrice, double dividendsPerShare)
    {
        Name = name;
        Stock = new CompanyStock(sharePrice, dividendsPerShare);
        AllCompanies.Add(this);
    }
}
