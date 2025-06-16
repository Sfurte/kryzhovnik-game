using System.Collections.Generic;
using System.Linq;
using System;

public static class TutorialPries
{
    public static List<TutorialCompanyData> CompanysData = new List<TutorialCompanyData>()
    {
        new TutorialCompanyData("Яблочная компания", new List<float>{22,25,24,26,21,26,20,20,24,19,17,18,20 ,21,27,26}),
        new TutorialCompanyData("СлитКо (металл)", new List<float>{17,14,15,16,24,29,31,34,24,20,19,21,22,40,23,12}),
        new TutorialCompanyData("Ассоциация лесорубов", new List<float>{27,24,25,26,24,29,11,14,14,10,19,21,22,20,27,22}),
        new TutorialCompanyData("Второй Архитекториум (строительство)", new List<float>{30,32,31,36,38,28,20,21,19,20,24,23,27,25,26,23}),
    };

    public static void SetStartPriceLogCompanys()
    {
        Random random = new Random();
        foreach (var data in CompanysData)
        {
            var company = Company.AllCompanies.FirstOrDefault(c => c.Name == data.CompanyName);
            if (company == null || data.Prices.Count == 0) continue;


            float currentPrice = data.Prices[0];
            data.Prices.Add(currentPrice);

            for (int i = 1; i < 30; i++)
            {
                float randomChange = random.Next(-10, 10);
                currentPrice += randomChange;
   

                currentPrice = Math.Max(2f, currentPrice);

                data.Prices.Add(currentPrice);

                company.Stock.BasePrice = currentPrice;
            }
        }
    }


}


public class TutorialCompanyData
{
   public string CompanyName;
   public List<float> Prices;
    public TutorialCompanyData(string companyName, List<float> prices)
    {
        CompanyName = companyName;
        Prices = prices;
    }
}