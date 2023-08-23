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
        // get last number like id
        // forming id in step change task
        int id = System.Convert.ToInt32((gameObject.name[gameObject.name.Length - 1].ToString()));

        // SceneManager.LoadScene("Substation");
        /*
        foreach (Transform child in GlobalVariables.Substation)
            child.gameObject.SetActive(true);
       */

        // GlobalVariables.Substation - variables have source for gameObject main station scene
        // you are can create several scene or station and activated for id
        GlobalVariables.Substation.gameObject.SetActive(true);
        GlobalNavigation.SetCursorState(false);

        GlobalVariables.CameraWindow.SetActive(false);
        GlobalNavigation.CloseActiveWindow();

        // split execution logic task modes
        // if (GlobalVariables.TASK_MODE != GlobalVariables.EXAM_MODE) return;

        GlobalVariables.TASK_ID = id;
        GlobalVariables.TASK_BALLS = GlobalVariables.TasksList.list[id].balls;

        GlobalVariables.TASK_TYPE = GlobalVariables.TasksList.list[id].type;
        GameObject.Find(GlobalVariables.TASK_TYPE).SetActive(true);

        GlobalVariables.USER_BALLS = GlobalVariables.TASK_BALLS; // in zone minus ball
    }
    public void CloseScene()
    {
        /*
        foreach (Transform child in GlobalVariables.Substation)
            child.gameObject.SetActive(false);
        */

        GlobalVariables.Substation.gameObject.SetActive(true);

        GameObject.Find(GlobalVariables.TASK_TYPE).SetActive(false);
        GlobalVariables.CameraWindow.SetActive(true);
    }
    public void OpenWindowOnlyAuth()
    {
        if (GlobalVariables.AUTH_USER == false)
        {
            OpenWindow(AuthAndRegWindow);
            GlobalVariables.HISTORY_WINDOW.Clear();
            return;
        }

        GameObject LCWindow = GlobalVariables.LC_WINDOW;
        Transform contentCardLCWindow = LCWindow.transform.Find("Wrapper/Content/Scroll View/Viewport/Content");

        OpenWindow(LCWindow);

        contentCardLCWindow.GetComponent<FormingListController>().getData();
    }

    // method for click in navigation buttons on Windows
    public void OpenTargetWindow(GameObject window)
    {
        if (window)
        {
            OpenWindow(window);
        }
        else
        {
            OpenWindow(openWindow);
        }
    }

    void OpenWindow(GameObject window)
    {

        GlobalNavigation.CloseActiveWindow();

        GlobalNavigation.AddWindowInHistory(window);
        window.SetActive(true);
    }
    

    // SetMode: exams or testing
    public void SetMode(string mode)
    {
        GlobalNavigation.ReplaceGlobalVariablesTaskMode(mode);
    }

    // SetMode testing
    public void SetTestTaskMode()
    {
        GlobalNavigation.ReplaceGlobalVariablesTaskMode(GlobalVariables.TEST_MODE);
    }

    // SetMode exams
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
