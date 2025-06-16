using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Инициализирует компании в игре перед её началом
/// </summary>
public class CompaniesInitializer : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown companyDropdown;

    private List<Company> uninitializedCompanies;
    
    [System.Serializable]  public class CompanyData

    {
        public string name;
        public float money;
        public float dividendsPerShare;
    }

    [System.Serializable]
    public class CompanyListWrapper
    {
        public CompanyData[] companies;
    }

    private void Awake()
    {
        uninitializedCompanies = CreateUninitializedCompanies();
        SetupCompanyDropdown();
        SelectDefaultCompany();
    }

    private void Start()
    {
        Initialize(uninitializedCompanies);
        uninitializedCompanies = null;
        
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
    private List<Company> CreateUninitializedCompanies()
    {
        List<Company> companies = new List<Company>();

        TextAsset jsonFile = Resources.Load<TextAsset>("companies");
        if (jsonFile == null)
        {
            Debug.LogError("File 'companies.json' not found");
            return companies;
        }

        CompanyListWrapper wrapper = JsonUtility.FromJson<CompanyListWrapper>(jsonFile.text);
        CompanyData[] companiesData = wrapper.companies;

       
        foreach (var data in companiesData)
        {
            companies.Add(new Company(data.name, data.money, data.dividendsPerShare));
        }

        Company.CreateListCompanies(companies);
        return companies;
    }

    /// <summary>
    /// Выбирает первую попавшуюся компанию как GameState.Selected.
    /// </summary>
    private void SelectDefaultCompany()
    {
        GameState.SelectCompany(Company.AllCompanies[0]);
    }

    public void SelectCompany(int index)
    {
        GameState.SelectCompany(Company.AllCompanies[index]);
        Debug.Log($"selected company : {Company.AllCompanies[index].Name}");

    }

    private void SetupCompanyDropdown()
    {
        companyDropdown.ClearOptions();

        List<string> companyNames = new List<string>();
        foreach (var company in Company.AllCompanies)
        {
            companyNames.Add(company.Name);
        }

        companyDropdown.AddOptions(companyNames);

        companyDropdown.onValueChanged.AddListener(OnCompanySelected);
    }

    private void OnCompanySelected(int index)
    {
        SelectCompany(index);
    }
}