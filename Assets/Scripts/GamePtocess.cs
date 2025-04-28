using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePtocess : MonoBehaviour

{
    public Clock clock;
    public CompaniesInitializer companiesInitializer;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        clock.Tick();
    }
}
