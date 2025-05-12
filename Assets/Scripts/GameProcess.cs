using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProcess : MonoBehaviour
{
    public Clock clock;
    public CompaniesInitializer companiesInitializer;

    void Start()
    {
        PlayerStats.Money = 300;

        Clock.GetInstance().TickActions += () => { PlayerStats.UpdateMoneyLog(); };
        clock.Tick();
    }

    void Update()
    {
       
    }
}
