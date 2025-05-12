using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static event Action<TutorialEventArgs> TutorialEvent;

    // Start is called before the first frame update
    void Start()
    {
        Clock clock = Clock.GetInstance();

        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Привет, добро пожаловать в наш симулятор инвестирования, здесь ты сможешь узнать, что такое инвестирование и как им правильно заниматься"
        }), 1);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Для начала тебе нужно купить свои первые акции, вот твой начальный бюджет (300$), его можно увидеть в нижней части экрана"
        }), 1);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Теперь купи акции металлодобывающей компании СлитКо (кнопка в левом нижнем углу). Посмотрим, как изменится курс на следующий день. Нажми на кнопку \"следующий день\" чуть правее кнопки покупки акций.",
            NewsToInitiate = new News("Политическая напряжённость растёт", "Потребность в металле для производства оружия повышается", Company.AllCompanies.First(c => c.Name == "СлитКо (металл)"), 30, 20)
        }), 1);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Цена акции выросла, теперь её можно продать (кнопка левее кнопки покупки акции)",
        }), 2);
    }

}
