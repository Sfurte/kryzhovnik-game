using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTime : MonoBehaviour
{

    public Clock clock;

    public void SwitchDay()
    {
        clock.Tick();
    }

}
