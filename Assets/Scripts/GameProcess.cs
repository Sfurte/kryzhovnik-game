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
        clock.Tick();

        Clock.GetInstance().TickActions += () => { PlayerStats.UpdateMoneyLog(); };
    }

    void Update()
    {
       
    }
}
