using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorTaskController : MonoBehaviour
{
    public Text descriptionTask;
    public Text commonInfo;
    public GlobalVariables GlobalVariables;

    public GameObject notificationTask;
    public GameObject plus;

    public void SetTaskScenarioOPN()
    {
        descriptionTask.text = "1. Выполните обход территории. \n2. Выполните осмотр ОПН - 220кВ первой линии.";
        commonInfo.text = "Вчера была проведена установка ОПН - 220 кВ первой линии. Удостоверьтесь, что ОПН - 220 кВ первой линии исправен.";
        SetTask();
    }
    void SetTask()
    {
        GlobalVariables.PAUSE_WINDOW.SetActive(!GlobalVariables.PAUSE_WINDOW.activeSelf);
        notificationTask.SetActive(true);

        StartCoroutine(HiddenNotificationTask());
    }
    IEnumerator HiddenNotificationTask()
    {
        yield return new WaitForSeconds(3);
        notificationTask.SetActive(false);
    }
}
