using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

// ����� �������� �� ������������ ���������� ������������� ������.
// ����� ������ ������������ ����������, ������� ��� ������ ������������ �� ����.

// ������ �������� �� ������, �������������� � ������� ������������ ����� ��������� ������.
public class RulesInfringementController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;
    public BallsActionsController BallsAction;

    public DataErrors Error; // concretno error, example: move in DangerZone

    public GameObject RuleEntrance;

    public Transform ListErrors;
    public GameObject prefabError;

    public List<int> arIndexsErrorsType = new List<int>(2);

    public Text message;
    public Transform InfoTask;

    // ��� 1: ���� ������������ � ������� ����.
    public void EntranceInDangerZone(bool state)
    {
        DataErrors Error = GlobalVariables.ErrorList.list[0];

        if (GlobalVariables.TASK_MODE == GlobalVariables.TEST_MODE)
        {
            RuleEntrance.SetActive(state);
            RuleEntrance.transform.Find("Text").GetComponent<Text>().text = Error.Title;

        }

        if (state == true)
            FormingListIndexsErrorsType(Error);
    }

    public void FormingListIndexsErrorsType(DataErrors error)
    {
        BallsAction.MinusBall(error.TakeBalls);
        arIndexsErrorsType.Add(error.Id);
        GlobalVariables.USER_VOLUME_ERRORS += 1;

        if (GlobalVariables.TASK_MODE == GlobalVariables.TEST_MODE)
            StartCoroutine(ShowRuleEntranceError(error));
    }


    public void AddedErrorInListErrors()
    {
        ClearListError();
        BallsAction.CalcAward();

        InfoTask.Find("NameTask").GetComponent<Text>().text = GlobalVariables.TasksList.list[GlobalVariables.TASK_ID].Title;
        InfoTask.Find("LVLTask").GetComponent<Text>().text = "<b>������� ���������</b>: " + GlobalVariables.TasksList.list[GlobalVariables.TASK_ID].Level;
        InfoTask.Find("VolumeError").GetComponent<Text>().text = "<b>���������� ������</b>: " + GlobalVariables.USER_VOLUME_ERRORS;
        InfoTask.Find("Award").GetComponent<Text>().text = "<b>������</b>: " + GlobalVariables.USER_AWARD;

        if (arIndexsErrorsType.Count > 0)
        {
            foreach (int index in arIndexsErrorsType)
            {
                Transform error = Instantiate(prefabError, new Vector3(0, 0, 0), Quaternion.identity).transform;
                error.Find("Title").GetComponent<Text>().text = GlobalVariables.ErrorList.list[index].Title;
                error.Find("Desctiption").GetComponent<Text>().text = GlobalVariables.ErrorList.list[index].Description;
                error.Find("Rule").GetComponent<Text>().text = GlobalVariables.ErrorList.list[index].Rule;
                error.SetParent(ListErrors);
            }
        } else
        {
            Transform error = Instantiate(prefabError, new Vector3(0, 0, 0), Quaternion.identity).transform;
            error.Find("Title").GetComponent<Text>().text = "������� ��������� ��� ������!";
            error.localScale = Vector3.one;
            error.SetParent(ListErrors);
        }
    }

    public void ClearListError()
    {
        foreach (Transform child in ListErrors)
            Destroy(child.gameObject);
    }

    IEnumerator ShowRuleEntranceError(DataErrors error)
    {
        yield return new WaitForSeconds(.5f);
        RuleEntrance.SetActive(true);
        RuleEntrance.transform.Find("Text").GetComponent<Text>().text = "�������� �������: " + error.sourceOnRule;
        yield return new WaitForSeconds(3f);
        RuleEntrance.SetActive(false);
        RuleEntrance.transform.Find("Text").GetComponent<Text>().text = "";

    }
    /*IEnumerator HiddenMessageError(DataErrors error)
    {
        yield return new WaitForSeconds(1f);
        message.gameObject.SetActive(true);
        message.text = "�������� �������: " + error.Rule;
        yield return new WaitForSeconds(3f + error.Id);
        message.gameObject.SetActive(false);
        message.text = "";
    }*/
}
