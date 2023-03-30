using UnityEngine;
using UnityEngine.UI;

// Класс отвечает за отслеживание совершения пользователем ошибок.
// Видов ошибок ограниченное количество, поэтому все ошибки подразделены на типы.

public class RulesInfringementController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public DataErrors Errors;

    public GameObject RuleEntrance;

    // Тип 1: вход пользователя в опасную зону.
    public void EntranceInDangerZone(bool state)
    {
        if (GlobalVariables.TASK_MODE == "testMode")
        {
            RuleEntrance.SetActive(state);
            RuleEntrance.transform.Find("Text").GetComponent<Text>().text = Errors.typeOne;
        }
            
        if (state == true)
            GlobalVariables.USER_BALLS -= Errors.takeBalls;

    }
}
