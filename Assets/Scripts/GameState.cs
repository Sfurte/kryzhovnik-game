using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    public static Company SelectedCompany { get; private set; }

    public static void SelectCompany(Company selected)
    {
        SelectedCompany = selected;
    }
}