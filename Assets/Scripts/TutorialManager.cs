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
            "Теперь купи акции металлодобывающей компании СлитКо. Нажми на кнопку \"Купить акцию\" . Посмотрим, как изменится курс на следующий день. " +
            "Нажми на кнопку \"следующий день\" чуть правее кнопки покупки акций.",
            NewsToInitiate = new News("Политическая напряжённость растёт", "Потребность в металле для производства оружия повышается", Company.AllCompanies.First(c => c.Name == "СлитКо (металл)"), 30, 20)
        }), 1);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Цена акции выросла, теперь её можно продать. Нажми на кнопку \"Продать акцию\"",
        }), 2);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Теперь, когда ты узнал, как покупать и продавать акции, тебе нужно запомнить одну очень важную вещь," +
            " твой инвестиционный портфель нужно диверсифицировать, а это значит, что в твоём инвестиционном портфеле" +
            " должно быть как можно больше акций разных компаний из разных сфер," +
            " это поможет тебе сохранить цену своего инвестиционного портфеля при неожиданных обвалах определённых областей",
        }), 3);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Теперь ты можешь купить новые акции, но помни, что свой инвестиционный портфель нужно диверсифицировать," +
            " а это значит, что лучше не вкладывать все деньги в акции одной компании или в одну отрасль"+
            "Нажми на кнопку \"Выбор компании\""
            ,
        }), 3);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Давай посмотрим на изменения в цене наших акций",
        }), 6);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Хоть цена акций строительной компании и упала, но мы всё рано находимся в плюсе, так как цена остальных акций возросла",
        }), 6);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Теперь, когда ты знаешь, как предотвратить большие убытки при неожиданных обстоятельствах, тебе стоит" +
            " научится предотвращать убытки и при тех обстоятельствах, которые можно предугадать",
            NewsToInitiate = new News("Началась аномальная жара", "последний раз такая температура наблюдалась 11 лет назад" +
            " и тогда это привело к сильным пожарам, власти настоятельно не рекомендуют находится близко к лесам и пожароопасным объектам",
            Company.AllCompanies.First(c => c.Name == "Ассоциация лесорубов"), 1, 1)
        }), 7);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Исходя из этой новости мы можем понять, что вероятность пожаров довольно велика, а потому акции лесозаготовочной компании стоит продать",
        }), 7);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Тебе стоит обращать внимание на новости, они могут помочь тебе предугадать изменения на фондовом рынке",
            NewsToInitiate = new News("В лесах начались массовые пожары", "хоть пожары и не задели леса," +
            " находящиеся рядом с городом, но сильно навредили лесозаготовке",
            Company.AllCompanies.First(c => c.Name == "Ассоциация лесорубов"), 1, 1)
        }), 8);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Тебе стоит обращать внимание на новости, они могут помочь тебе предугадать изменения на фондовом рынке",
        }), 8);

        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Отлично, ты научился как предотвращать убытки, но теперь тебе нужно узнать, как получать прибыль," +
            " в этом тебе очень сильно помогут дивиденды, получаемые от приобретённых тобой акций",
        }), 11);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Также акции могут приносить дивиденды, давай купим акции, которые скоро выплатят дивиденды"+
             "Нажми на кнопку \"Дивиденды\"",
        }), 11);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Ты получил свои первые дивиденды, цена акций торговой компании, конечно," +
            " упала из-за выплаты дивиденд, но скоро она вернётся к своему первоначальному значению",
        }), 12);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Теперь ты научился всем основным навыкам инвестирования, однако помни что деньги не бесконечны, и их стоит тратить с умом",
        }), 14);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "Ты научился всему что нужно для самостоятельного инвестирования и теперь ты можешь проверить полученные тобой навыки на практике",
        }), 15);

    }

}
