using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Отвечает за ход времени в игре
/// </summary>
public class Clock : MonoBehaviour
{
    public int TickNumber { get; private set; }

    public float tickDuration = 0.2f;
    public Action TickActions;

    private static Clock instance;

    public static Clock GetInstance() => instance;

    private void Awake()
    {
        if(instance != null)
        {
            throw new Exception("Невозможно создать несколько компонентов Clock на одной сцене");
        }
        instance = this;
    }

    private void Start()
    {
        TickActions += () =>
        {
            Debug.Log($"Tick #{TickNumber}");
        };

        StartCoroutine("Tick");
    }

    /// <summary>
    /// Переводит игру на следующий ход
    /// </summary>
    public IEnumerator Tick()
    {
        while (true)
        {
            yield return new WaitForSeconds(tickDuration);
            TickActions();
            TickNumber++;
        }
    }
}