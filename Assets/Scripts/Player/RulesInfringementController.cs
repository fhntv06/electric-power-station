using UnityEngine;
using UnityEngine.UI;

// ����� �������� �� ������������ ���������� ������������� ������.
// ����� ������ ������������ ����������, ������� ��� ������ ������������ �� ����.

public class RulesInfringementController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public DataErrors Errors;

    public GameObject RuleEntrance;

    // ��� 1: ���� ������������ � ������� ����.
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
