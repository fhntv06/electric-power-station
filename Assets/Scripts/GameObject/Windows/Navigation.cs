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

    public void SetTestVerificationMode()
    {
        GlobalNavigation.ReplaceGlobalVariablesVerificationMode("test");
    }
    public void SetExamVerificationMode()
    {
        GlobalNavigation.ReplaceGlobalVariablesVerificationMode("exam");
    }
}
