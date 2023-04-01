using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

// File includes methods for just action button
public class Navigation : MonoBehaviour
{
    public GameObject openWindow;
    public GameObject AuthAndRegWindow;

    public GlobalNavigation GlobalNavigation;
    public GlobalVariables GlobalVariables;

    string urlData = "http://substation/data.php";

    public void OpenScene()
    {
        int id = System.Convert.ToInt32((gameObject.name[gameObject.name.Length - 1].ToString()));

        // SceneManager.LoadScene("Substation");
        foreach (Transform child in GameObject.Find("Substation").transform)
            child.gameObject.SetActive(true);

        GlobalVariables.TASKID = id;
        GlobalVariables.TASK_BALLS = GlobalVariables.DATA_TASKS[id].balls;
        GlobalVariables.USER_BALLS = GlobalVariables.TASK_BALLS; // in zone minus ball
        GameObject.Find("CameraWindow").SetActive(false);
        GlobalNavigation.CloseActiveWindow();
    }
    public void CloseScene()
    {
        GameObject.Find("Substation").SetActive(false);
        GameObject.Find("CameraWindow").SetActive(true);
    }
    public void OpenWindowOnlyAuth()
    {
        GameObject window;

        if (GlobalVariables.AUTH_USER == false)
        {
            window = AuthAndRegWindow;
            GlobalVariables.HISTORY_WINDOW.Clear();
        }
        else
        {
            window = openWindow;
        }

        OpenWindow(window);
    }

    public void OpenTargetWindow()
    {
        OpenWindow(openWindow);
    }

    void OpenWindow(GameObject window)
    {
        GlobalNavigation.CloseActiveWindow();

        GlobalNavigation.AddWindowInHistory(window);
        window.SetActive(true);
    }
    

    public void SetMode(string mode)
    {
        GlobalNavigation.ReplaceGlobalVariablesTaskMode(mode);
    }

    public void SetTestTaskMode()
    {
        GlobalNavigation.ReplaceGlobalVariablesTaskMode(GlobalVariables.TEST_MODE);
    }
    public void SetExamTaskMode()
    {
        GlobalNavigation.ReplaceGlobalVariablesTaskMode(GlobalVariables.EXAM_MODE);
    }

    public void SetProgressTask()
    {
        StartCoroutine(PassTask());
    }

    public IEnumerator PassTask()
    {
        string url = urlData + "?action=post&type=tasks&field=pass&value=1&id=" + GlobalVariables.TASKID;
        print(url);
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
    }
}
