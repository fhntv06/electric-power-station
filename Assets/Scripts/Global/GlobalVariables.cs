using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // Global variables authentification
    public bool AUTH_USER = false;
    public string VERIFICATION_MODE = "";

    // Global variables user state
    public int USER_ID;
    public int USER_BALLS;
    public int USER_MAX_BALLS_METRIC = 100;
    public int USER_VOLUME_ERRORS;
    public int USER_MAX_AWARD = 5;
    public int USER_AWARD;
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
    public Transform PAUSE_WINDOW_CONTENT;
    public GameObject CameraWindow;

    // Global variables task 
    public int TASK_ID;
    public string TASK_MODE;
    public string TEST_MODE = "testMode";
    public string EXAM_MODE = "examMode";
    public int TASK_BALLS;
    public string TASK_TYPE;

    // Global data
    public TasksList TasksList;
    public ErrorList ErrorList;
    public InstructionAndRuleList InstructionAndRuleList;

    // Global variables connect to database
    static string HOST = "http://substation/";
    public string URL_DATA = HOST + "data.php";
    public string URL_AUTH = HOST + "auth.php";

    // Substation
    public Transform Substation;

}
