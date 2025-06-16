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
            "������, ����� ���������� � ��� ��������� ��������������, ����� �� ������� ������, ��� ����� �������������� � ��� �� ��������� ����������"
        }), 1);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "��� ������ ���� ����� ������ ���� ������ �����, ��� ���� ��������� ������ (300$), ��� ����� ������� � ������ ����� ������"
        }), 1);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "������ ���� ����� ����������������� �������� ������. ����� �� ������ \"������ �����\" . ���������, ��� ��������� ���� �� ��������� ����. " +
            "����� �� ������ \"��������� ����\" ���� ������ ������ ������� �����.",
            NewsToInitiate = new News("������������ ������������ �����", "����������� � ������� ��� ������������ ������ ����������", Company.AllCompanies.First(c => c.Name == "������ (������)"), 30, 20)
        }), 1);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "���� ����� �������, ������ � ����� �������. ����� �� ������ \"������� �����\"",
        }), 2);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "������, ����� �� �����, ��� �������� � ��������� �����, ���� ����� ��������� ���� ����� ������ ����," +
            " ���� �������������� �������� ����� �����������������, � ��� ������, ��� � ���� �������������� ��������" +
            " ������ ���� ��� ����� ������ ����� ������ �������� �� ������ ����," +
            " ��� ������� ���� ��������� ���� ������ ��������������� �������� ��� ����������� ������� ����������� ��������",
        }), 3);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "������ �� ������ ������ ����� �����, �� �����, ��� ���� �������������� �������� ����� �����������������," +
            " � ��� ������, ��� ����� �� ���������� ��� ������ � ����� ����� �������� ��� � ���� �������"+
            "����� �� ������ \"����� ��������\""
            ,
        }), 3);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "����� ��������� �� ��������� � ���� ����� �����",
        }), 6);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "���� ���� ����� ������������ �������� � �����, �� �� �� ���� ��������� � �����, ��� ��� ���� ��������� ����� ��������",
        }), 6);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "������, ����� �� ������, ��� ������������� ������� ������ ��� ����������� ���������������, ���� �����" +
            " �������� ������������� ������ � ��� ��� ���������������, ������� ����� �����������",
            NewsToInitiate = new News("�������� ���������� ����", "��������� ��� ����� ����������� ����������� 11 ��� �����" +
            " � ����� ��� ������� � ������� �������, ������ ������������ �� ����������� ��������� ������ � ����� � ������������� ��������",
            Company.AllCompanies.First(c => c.Name == "���������� ���������"), 1, 1)
        }), 7);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "������ �� ���� ������� �� ����� ������, ��� ����������� ������� �������� ������, � ������ ����� ���������������� �������� ����� �������",
        }), 7);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "���� ����� �������� �������� �� �������, ��� ����� ������ ���� ����������� ��������� �� �������� �����",
            NewsToInitiate = new News("� ����� �������� �������� ������", "���� ������ � �� ������ ����," +
            " ����������� ����� � �������, �� ������ ��������� �������������",
            Company.AllCompanies.First(c => c.Name == "���������� ���������"), 1, 1)
        }), 8);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "���� ����� �������� �������� �� �������, ��� ����� ������ ���� ����������� ��������� �� �������� �����",
        }), 8);

        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "�������, �� �������� ��� ������������� ������, �� ������ ���� ����� ������, ��� �������� �������," +
            " � ���� ���� ����� ������ ������� ���������, ���������� �� ������������ ����� �����",
        }), 11);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "����� ����� ����� ��������� ���������, ����� ����� �����, ������� ����� �������� ���������"+
             "����� �� ������ \"���������\"",
        }), 11);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "�� ������� ���� ������ ���������, ���� ����� �������� ��������, �������," +
            " ����� ��-�� ������� ��������, �� ����� ��� ������� � ������ ��������������� ��������",
        }), 12);


        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "������ �� �������� ���� �������� ������� ��������������, ������ ����� ��� ������ �� ����������, � �� ����� ������� � ����",
        }), 14);
        clock.AddDelayedAction(() => TutorialEvent(new TutorialEventArgs()
        {
            TutorialText =
            "�� �������� ����� ��� ����� ��� ���������������� �������������� � ������ �� ������ ��������� ���������� ����� ������ �� ��������",
        }), 15);

    }

}
