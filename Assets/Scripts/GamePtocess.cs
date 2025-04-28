using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePtocess : MonoBehaviour

{
    public Clock clock;
    public CompaniesInitializer companiesInitializer;

    void Start()
    {
        PlayerStats.Money = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        clock.Tick();
    }
}
