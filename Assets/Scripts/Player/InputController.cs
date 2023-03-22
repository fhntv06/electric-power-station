using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;
    public ScenarioOPN ScenarioOPN;

    public float speed;
    private KeyCode keyForwardMove = GlobalInputController.forward;
    private KeyCode keyRightMove = GlobalInputController.right;
    private KeyCode keyLeftMove = GlobalInputController.left;
    private KeyCode keyBackMove = GlobalInputController.back;
    private KeyCode keySpeedUpMove = GlobalInputController.speedUp;
    private KeyCode keyActivePauseWindow = GlobalInputController.activePauseWindow;

    void Update()
    {
        if (!GlobalVariables.USER_FREEZE)
        {
            Vector3 newTransformPosition = new Vector3(0, 0, 0);

            if (Input.GetKey(keyForwardMove)) newTransformPosition = transform.forward;
            if (Input.GetKey(keyBackMove)) newTransformPosition = -transform.forward;
            if (Input.GetKey(keyLeftMove)) newTransformPosition = -transform.right;
            if (Input.GetKey(keyRightMove)) newTransformPosition = transform.right;

            if (Input.GetKey(keyForwardMove) && Input.GetKey(keyLeftMove)) newTransformPosition = transform.forward + -transform.right;
            if (Input.GetKey(keyBackMove) && Input.GetKey(keyLeftMove)) newTransformPosition = -transform.forward + -transform.right;
            if (Input.GetKey(keyForwardMove) && Input.GetKey(keyRightMove)) newTransformPosition = transform.forward + transform.right;
            if (Input.GetKey(keyBackMove) && Input.GetKey(keyRightMove)) newTransformPosition = -transform.forward + transform.right;

            if (Input.GetKeyDown(keySpeedUpMove)) speed *= 2;
            if (Input.GetKeyUp(keySpeedUpMove)) speed /= 2;

            transform.localPosition += newTransformPosition * speed;
        }

        if (Input.GetKeyUp(keyActivePauseWindow)) GlobalVariables.PAUSE_WINDOW.SetActive(!GlobalVariables.PAUSE_WINDOW.activeSelf);
    }

    void OnTriggerEnter(Collider other)
    {
        CheckEntry(other.tag, true, other);
    }

    void OnTriggerExit(Collider other)
    {
        CheckEntry(other.tag, false, other);
    }

    void CheckEntry(string tag, bool state, Collider collider)
    {
        switch (tag)
        {
            case "DangerObject":
                GlobalVariables.WARNING_DEATH_WINDOW.SetActive(state);
                if (GlobalVariables.VERIFICATION_MODE == "") collider.GetComponent<RulesInfringementController>().EntranceInDangerZone(state);
                break;
            case "DeathObject":
                GlobalVariables.DEATH_WINDOW.SetActive(state);
                GlobalVariables.DEATH_WINDOW.transform.Find("Btn_" + GlobalVariables.TASK_MODE).gameObject.SetActive(state);

                GlobalVariables.USER_IN_DEATH_ZONE = state;
                if (GlobalVariables.USER_IN_DEATH_ZONE)
                {
                    ReplaceUserFreese(true);
                }
                break;

            case "OnEndTaskScenarioOPN":
                ScenarioOPN.NextStepScenarioOPN.SetActive(true);
                break;

            case "NextStepScenarioOPN":
                ScenarioOPN.NextStep();
                break;
        }
    }

    public void ReplaceUserFreese(bool state)
    {
        GlobalVariables.USER_FREEZE = state;
        print(GlobalVariables.USER_FREEZE);
    }
}
