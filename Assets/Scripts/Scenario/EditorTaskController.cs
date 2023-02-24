using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorTaskController : MonoBehaviour
{
    public Text descriptionTask;
    public GlobalVariables GlobalVariables;

    public GameObject notificationTask;
    public GameObject plus;

    void SetTask()
    {
        GlobalVariables.PAUSE_WINDOW.SetActive(!GlobalVariables.PAUSE_WINDOW.activeSelf);
        notificationTask.SetActive(true);

        StartCoroutine(HiddenNotificationTask());
    }
    public void SetTaskScenarioOPN()
    {
        descriptionTask.text = "1. Выполните осмотр ОПН - 220";
        SetTask();
    }

    IEnumerator HiddenNotificationTask()
    {
        yield return new WaitForSeconds(3);
        notificationTask.SetActive(false);
    }
}
