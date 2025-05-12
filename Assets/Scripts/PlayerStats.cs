using System.Collections.Generic;

public static class PlayerStats
{
    private static List<double> moneyLog = new List<double>();
    public static IReadOnlyList<double> MoneyLog { get => moneyLog; }

    private static double currentMoney = 300;
    private static double tickStartMoney = 300;

    public static double Money
    {
        get => currentMoney;
        set => currentMoney = value;
    }

    public static double GetProfit()
    {
        return currentMoney - tickStartMoney;
    }

    public static void UpdateMoneyLog()
    {
        moneyLog.Add(currentMoney);
        tickStartMoney = currentMoney; 
    }
}