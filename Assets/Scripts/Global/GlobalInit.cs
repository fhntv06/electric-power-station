using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInit : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    void Start()
    {
        GlobalVariables.USER_FREEZE = false;
    }
}
