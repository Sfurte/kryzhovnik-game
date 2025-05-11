using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Отвечает за ход времени в игре
/// </summary>
public class Clock : MonoBehaviour
{
    public static Clock GetInstance() => instance;
    public int TickNumber { get; private set; }

    public float tickDuration = 0.2f;
    public Action TickActions;

    private static Clock instance;
    private List<DelayedAction> delayedActions = new List<DelayedAction>();

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
    }

    public void AddDelayedAction(Action action, int delay)
    {
        delayedActions.Add(new DelayedAction() { Action = action, DaysLeft = delay });
    } 

    /// <summary>
    /// Переводит игру на следующий ход
    /// </summary>
    public void Tick()
    {
        TickActions?.Invoke();

        var newDelayedActions = new List<DelayedAction>();
        foreach (var delayedAction in delayedActions)
        {
            delayedAction.DaysLeft--;
            if (delayedAction.DaysLeft <= 0)
            {
                delayedAction.Action();
                continue;
            }
            newDelayedActions.Add(delayedAction);
        }
        delayedActions = newDelayedActions;

        TickNumber++;
    }

    private class DelayedAction
    {
        public Action Action { get; set; }
        public int DaysLeft { get; set; }
    }
}