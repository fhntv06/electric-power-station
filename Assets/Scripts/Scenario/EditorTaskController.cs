using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EditorTaskController : MonoBehaviour
{
   
    public GlobalVariables GlobalVariables;
    public GlobalNavigation GlobalNavigation;

    public Transform descriptionTask;
    public Text commonInfoTask;

    public GameObject notificationTask;
    public GameObject plus;

    public GameObject prefabText;

    public void SetTaskScenario()
    {
        string description = "";
        string commonInfo = "";
        switch(ScenarioOPN.scenarioOPNPhoneBlockedStep)
        {
            case 0:
                description = GlobalVariables.TasksList.list[GlobalVariables.TASK_ID].description_1;
                commonInfo = GlobalVariables.TasksList.list[GlobalVariables.TASK_ID].commonInfo_1;
                break;
            case 2:
                description = GlobalVariables.TasksList.list[GlobalVariables.TASK_ID].description_2;
                commonInfo = GlobalVariables.TasksList.list[GlobalVariables.TASK_ID].commonInfo_2;
                break;
        }

        ClearDescription();

        string[] texts = description.Split('\n');
        foreach (string p in texts)
        {
            Transform paragraph = Instantiate(prefabText, new Vector3(0, 0, 0), Quaternion.identity).transform;
            paragraph.GetComponent<Text>().text = p;
            paragraph.SetParent(descriptionTask);
        }

        commonInfoTask.text = commonInfo;
        SetTask();

        ScenarioOPN.scenarioOPNPhoneBlockedStep += 1;
    }

    void ClearDescription()
    {
        foreach (Transform child in descriptionTask) Destroy(child.gameObject);
    }

    void SetTask()
    {
        GlobalNavigation.SwitcherContentPauseWindow("Tasks");
        notificationTask.SetActive(true);
        StartCoroutine(HiddenNotificationTask());
    }
    IEnumerator HiddenNotificationTask()
    {
        yield return new WaitForSeconds(3);
        notificationTask.SetActive(false);
    }
}
