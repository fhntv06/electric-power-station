using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Text error", menuName = "Text error")]
public class DataErrors : ScriptableObject
{
    // Type error 1:
    public string typeOne = "Нарушено правило!";

    public string Error { get => typeOne; }
}
