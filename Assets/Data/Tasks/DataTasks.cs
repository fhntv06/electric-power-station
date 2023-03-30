using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CardStruct;

[CreateAssetMenu(fileName = "Task_(number)", menuName = "Data Task")]
public class DataTasks : ScriptableObject
{
    // Task 1
    public int id = 0;
    public string title = "Осмотр ограничителя перенапряжения";
    public string type = "ScenarioOPN";
    public int balls = 10;
    public string tag = "Task";

    public int Id { get => id; }
    public string Title { get => title; }
    public string Type { get => type; }
    public int Balls { get => balls; }
    public string Tag { get => tag; }
}
