using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Инициализирует компании в игре перед её началом
/// </summary>
public class CompaniesInitializer : MonoBehaviour
{
    private void Awake()
    {
        Initialize(GetUninitializedCompanies());
        SelectDefaultCompany();
    }

    /// <summary>
    /// Инициализирует компании
    /// </summary>
    /// <param name="uninitializedCompanies"></param>
    private void Initialize(List<Company> uninitializedCompanies)
    {
        foreach (var company in uninitializedCompanies)
        {
            Clock.GetInstance().TickActions += company.Stock.PayDividends;
        }
    }

    /// <summary>
    /// Получает список неинициализированных компаний (по идее берётся из какого-нибудь json-а или xml)
    /// </summary>
    /// <returns></returns>
    private List<Company> GetUninitializedCompanies()
    {
        return new List<Company>() { new Company("Cool company", 100, 0.02) };
    }

    /// <summary>
    /// Выбирает первую попавшуюся компанию как GameState.Selected.
    /// </summary>
    private void SelectDefaultCompany()
    {
        GameState.SelectCompany(Company.AllCompanies[0]);
    }
}