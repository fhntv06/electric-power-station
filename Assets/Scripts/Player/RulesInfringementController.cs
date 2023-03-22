using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Класс отвечает за отслеживание совершения пользователем ошибок.
// Видов ошибок ограниченное количество, поэтому все ошибки подразделены на типы.

public class RulesInfringementController : MonoBehaviour
{
    public DataErrors Errors;

    public GameObject RuleEntrance;

    // Тип 1: вход пользователя в опасную зону.
    public void EntranceInDangerZone(bool state)
    {
        RuleEntrance.SetActive(state);
        print("Errors: " + Errors);
        RuleEntrance.transform.Find("Text").GetComponent<Text>().text = Errors.typeOne;
    }
}
