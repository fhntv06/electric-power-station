using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // Global variables user state
    public bool AUTH_USER = false;
    public int TASKID;
    public string VERIFICATION_MODE = "";

    public int USER_ID;
    public int USER_BALLS;
    public bool USER_FREEZE;
    public bool USER_IN_DEATH_ZONE;

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

    // Global data
    public List<DataTasks> DATA_TASKS = new List<DataTasks>(0);
    public List<DataRule> DATA_INSTRUCTION_AND_RULE = new List<DataRule>(0);

}
