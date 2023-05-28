using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CardStruct;

[CreateAssetMenu(fileName = "Task_(type)", menuName = "Data Task")]
public class DataTasks : ScriptableObject
{
    // Task 1
    public int id = 0;
    public string title = "������ ������������ ��������������";
    public string description_1 = "1. ��������� ����� ����������. \n2. ��������� ������ ��� - 220�� ������ �����.";
    public string description_2 = "" +
        "1. ��������� ������������. \n" +
        "2. ��������� ������ ����������� � ������������� ��������. \n" +
        "3. ������������� ����� ������ ������ � �������. \n" +
        "4. ��������� ������������: \n" +
        "4.1.\t��������� ����������� ��� � 220 � 2 \n" +
        "4.2.\t��������� �������� �������������: �� � 220 / 1250 � 6, �� � 220 / 1250 � 8, �� � 220 / 1250 � 12 \n" +
        "4.3.\t�������� ���� ����������  �������� �������������� �� � 220 / 1250 � 6, �� � 220 / 1250 � 8, �� � 220 / 1250 � 12 �� ������� �����; \n" +
        "4.4.\t����������� ������ ���������� �������������� ���� ������� ����������� ����������� � ���������� ���������� �����������; \n" +
        "4.5.\t����������� ������ ���������� ����������� ������ ������ ��� ������ Q14;";

    public string commonInfo_1 = "����� ���� ��������� ��������� ��� - 220 �� ������ �����. ��������������, ��� ��� - 220 �� ������ ����� ��������.";
    public string commonInfo_2 = "";
    public string type = "ScenarioOPN";
    public int balls = 10;
    public int level = 1;
    public string tag = "Task";

    public int Id { get => id; }
    public string Title { get => title; }
    public string Description_1 { get => description_1; }
    public string Description_2 { get => description_2; }
    public string CommonInfo_1 { get => commonInfo_1; }
    public string CommonInfo_2 { get => commonInfo_2; }
    public string Type { get => type; }
    public int Balls { get => balls; }
    public int Level { get => level; }
    public string Tag { get => tag; }
}
