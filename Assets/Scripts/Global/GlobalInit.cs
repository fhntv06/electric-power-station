using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInit : MonoBehaviour
{
    public GlobalVariables GlobalVariables;
    public GlobalNavigation GlobalNavigation;
    public GameObject StartingWindow;

    private void Start()
    {
        GlobalNavigation.AddWindowInHistory(StartingWindow);
    }
}
