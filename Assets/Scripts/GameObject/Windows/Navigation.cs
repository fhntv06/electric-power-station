using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

// File includes methods for just action button
public class Navigation : MonoBehaviour
{
    public GameObject openWindow;
    public GameObject AuthAndRegWindow;

    public GlobalNavigation GlobalNavigation;
    public GlobalVariables GlobalVariables;

    public void OpenScene()
    {
        int id = System.Convert.ToInt32((gameObject.name[gameObject.name.Length - 1].ToString()));

        // SceneManager.LoadScene("Substation");
        foreach (Transform child in GlobalVariables.Substation)
            child.gameObject.SetActive(true);

        GameObject.Find("CameraWindow").SetActive(false);
        GlobalNavigation.CloseActiveWindow();

        if (GlobalVariables.TASK_MODE == GlobalVariables.EXAM_MODE)
        {
            GlobalVariables.TASK_ID = id;
            GlobalVariables.TASK_BALLS = GlobalVariables.TasksList.list[id].balls;

            GlobalVariables.TASK_TYPE = GlobalVariables.TasksList.list[id].type;
            GameObject.Find(GlobalVariables.TASK_TYPE).SetActive(true);

            GlobalVariables.USER_BALLS = GlobalVariables.TASK_BALLS; // in zone minus ball
        }
    }
    public void CloseScene()
    {
        foreach (Transform child in GlobalVariables.Substation)
            child.gameObject.SetActive(false);

        GameObject.Find(GlobalVariables.TASK_TYPE).SetActive(false);
        GlobalVariables.CameraWindow.SetActive(true);
    }
    public void OpenWindowOnlyAuth()
    {
        if (GlobalVariables.AUTH_USER == false)
        {
            OpenWindow(AuthAndRegWindow);
            GlobalVariables.HISTORY_WINDOW.Clear();
        }

        OpenWindow(openWindow);
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
        openWindow.SetActive(true);
        GlobalVariables.USER_FREEZE = true;
        StartCoroutine(PassTask());
    }

    public IEnumerator PassTask()
    {
        string url = GlobalVariables.URL_DATA + "?action=post&type=tasks&field=pass&value=1&id=" + GlobalVariables.TASK_ID;
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();
    }
}
