using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Класс отвечает за отслеживание совершения пользователем ошибок.
// Видов ошибок ограниченное количество, поэтому все ошибки подразделены на типы.

// Скрипт вешается на объект, взаимодействие с которым пользователь может совершить ошибку.
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

    // Тип 1: вход пользователя в опасную зону.
    public void EntranceInDangerZone(bool state)
    {
        DataErrors Error = GlobalVariables.ErrorList.list[0];

        if (GlobalVariables.TASK_MODE == GlobalVariables.TEST_MODE)
        {
            RuleEntrance.SetActive(state);
            RuleEntrance.transform.Find("Text").GetComponent<Text>().text = Error.Title;
        }

        if (state == true) FormingListIndexsErrorsType(Error);
    }

    public void FormingListIndexsErrorsType(DataErrors error)
    {
        BallsAction.MinusBall(error.TakeBalls);
        arIndexsErrorsType.Add(error.Id);
        GlobalVariables.USER_VOLUME_ERRORS += 1;

        if (GlobalVariables.TASK_MODE == GlobalVariables.TEST_MODE)
            StartCoroutine(ShowRuleEntranceError(error));
    }


    // forming list errors
    public void AddedErrorInListErrors()
    {
        ClearListError();
        BallsAction.CalcAward();
        FormingInfoTask();

        if (arIndexsErrorsType.Count == 0)
            CompletedNotError();
        else
            CompletedWithError();
    }

    void FormingInfoTask()
    {
        InfoTask.Find("NameTask").GetComponent<Text>().text = GlobalVariables.TasksList.list[GlobalVariables.TASK_ID].Title;
        InfoTask.Find("LVLTask").GetComponent<Text>().text = "<b>Уровень сложности</b>: " + GlobalVariables.TasksList.list[GlobalVariables.TASK_ID].Level;
        InfoTask.Find("VolumeError").GetComponent<Text>().text = "<b>Количество ошибок</b>: " + GlobalVariables.USER_VOLUME_ERRORS;
        InfoTask.Find("Award").GetComponent<Text>().text = "<b>Оценка</b>: " + GlobalVariables.USER_AWARD;
    }
    void CompletedWithError()
    {
        foreach (int index in arIndexsErrorsType)
        {
            Transform error = Instantiate(prefabError, new Vector3(0, 0, 0), Quaternion.identity).transform;
            error.Find("Title").GetComponent<Text>().text = GlobalVariables.ErrorList.list[index].Title;
            error.Find("Desctiption").GetComponent<Text>().text = GlobalVariables.ErrorList.list[index].Description;
            error.Find("Rule").GetComponent<Text>().text = GlobalVariables.ErrorList.list[index].Rule;
            error.SetParent(ListErrors);
        }
    }

    void CompletedNotError()
    {
        Transform error = Instantiate(prefabError, new Vector3(0, 0, 0), Quaternion.identity).transform;
        error.Find("Title").GetComponent<Text>().text = "Задание выполнено без ошибок!";
        error.localScale = Vector3.one;
        error.SetParent(ListErrors);
    }

    public void ClearListError()
    {
        foreach (Transform child in ListErrors)
            Destroy(child.gameObject);
    }

    // showed tablet with error
    IEnumerator ShowRuleEntranceError(DataErrors error)
    {
        yield return new WaitForSeconds(.5f);
        RuleEntrance.SetActive(true);
        RuleEntrance.transform.Find("Text").GetComponent<Text>().text = "Нарушено правило: " + error.sourceOnRule;
        yield return new WaitForSeconds(3f);
        RuleEntrance.SetActive(false);
        RuleEntrance.transform.Find("Text").GetComponent<Text>().text = "";

    }
    /*IEnumerator HiddenMessageError(DataErrors error)
    {
        yield return new WaitForSeconds(1f);
        message.gameObject.SetActive(true);
        message.text = "Нарушено правило: " + error.Rule;
        yield return new WaitForSeconds(3f + error.Id);
        message.gameObject.SetActive(false);
        message.text = "";
    }*/
}
