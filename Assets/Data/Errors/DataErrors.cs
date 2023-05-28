using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Error_TypeError", menuName = "Type error")]
public class DataErrors : ScriptableObject
{
    // Type error 1:
    public int id = 0;
    public string title = "�������� �������!";
    public string sourceOnRule = "1.2.3 ������";
    public string description = "���� � ������� ���� �� ��������! ���������� ���������� �������� �� ���������� �� 4� �� ������� ����.";
    public int takeBall = 1;
    public string type = "DangerZone";
    public string name = "HardHat";

    public int Id { get => id; }
    public string Title { get => title; }
    public string Description { get => description; }
    public string Rule { get => sourceOnRule; }
    public int TakeBalls { get => takeBall; }
    public string Type { get => type; }
    public string Name { get => name; }

}
