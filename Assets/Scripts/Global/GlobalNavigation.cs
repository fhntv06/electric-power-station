using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// File includes methods for global replace: variables and history navigation

public class GlobalNavigation : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public void Back()
    {
        CloseActiveWindow();
        GlobalVariables.PREV_WINDOW.SetActive(true);

        ReplaceGlobalVariablesWindow(GlobalVariables.PREV_WINDOW);
    }

    public void ReplaceGlobalVariablesWindow(GameObject activeWindow)
    {
        GlobalVariables.PREV_WINDOW = GlobalVariables.ACTIVE_WINDOW;
        GlobalVariables.ACTIVE_WINDOW = activeWindow;
    }

    public void ReplaceGlobalVariablesTaskMode(string mode)
    {
        GlobalVariables.TASK_MODE = mode;
    }

    public void CloseActiveWindow()
    {
        GlobalVariables.ACTIVE_WINDOW.SetActive(false);
    }

    public void OpenNextWindow(GameObject window)
    {
        window.SetActive(true);
    }
}
