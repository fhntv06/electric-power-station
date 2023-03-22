using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // Global variables user state
    public bool AUTH_USER = false;
    public int TASKID;
    public string VERIFICATION_MODE = "";

    public int USER_BALLS = 0;
    public bool USER_FREEZE = true;
    public bool USER_IN_DEATH_ZONE = false;

    // Global variables window
    public List<GameObject> HISTORY_WINDOW = new List<GameObject>(0);

    public GameObject PREV_WINDOW;
    public GameObject ACTIVE_WINDOW;
    public GameObject LC_WINDOW;
    public GameObject WARNING_DEATH_WINDOW;
    public GameObject DEATH_WINDOW;
    public GameObject PAUSE_WINDOW;

    // Global task mode
    public string TASK_MODE;
    public string TEST_MODE = "testMode";
    public string EXAM_MODE = "examMode";
}
