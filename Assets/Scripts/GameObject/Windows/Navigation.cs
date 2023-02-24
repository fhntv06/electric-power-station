using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// File includes methods for just action button
public class Navigation : MonoBehaviour
{
    public GameObject openWindow;
    public GameObject AuthAndRegWindow;

    public GlobalNavigation GlobalNavigation;
    public GlobalVariables GlobalVariables;

    public void OpenWindowOnlyAuth()
    {
        GlobalNavigation.CloseActiveWindow();

        GameObject window = GlobalVariables.AUTH_USER ? openWindow : AuthAndRegWindow;

        GlobalNavigation.ReplaceGlobalVariablesWindow(window);
        window.SetActive(true);
    }

    public void OpenTargetWindow()
    {
        GlobalNavigation.CloseActiveWindow();
        openWindow.SetActive(true);

        GlobalNavigation.ReplaceGlobalVariablesWindow(openWindow);
    }

    public void SetTestTaskMode()
    {
        GlobalNavigation.ReplaceGlobalVariablesTaskMode("testMode");
    }
    public void SetExamTaskMode()
    {
        GlobalNavigation.ReplaceGlobalVariablesTaskMode("examMode");
    }

    public void SetProgressTask()
    {
        // записываем данные в бэк + достаем данные из бэка и добавляем обновленные в LC
        Debug.Log("AnswerForTask");
    }
}
