using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInit : MonoBehaviour
{
    public GlobalVariables GlobalVariables;
    public GlobalNavigation GlobalNavigation;
    public GlobalSettings GlobalSettings;

    public GameObject StartingWindow;

    void Awake()
    {
        GlobalNavigation.AddWindowInHistory(StartingWindow);
        GlobalSettings.ReLoadGlobalSettings();
    }
}
