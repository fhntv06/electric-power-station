using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// ����� �������� �� ������������ ���������� ������������� ������.
// ����� ������ ������������ ����������, ������� ��� ������ ������������ �� ����.

public class RulesInfringementController : MonoBehaviour
{
    public DataErrors Errors;

    public GameObject RuleEntrance;

    // ��� 1: ���� ������������ � ������� ����.
    public void EntranceInDangerZone(bool state)
    {
        RuleEntrance.SetActive(state);
        print("Errors: " + Errors);
        RuleEntrance.transform.Find("Text").GetComponent<Text>().text = Errors.typeOne;
    }
}
