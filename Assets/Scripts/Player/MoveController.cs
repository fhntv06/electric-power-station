using UnityEngine;

public class MoveController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;
    public GlobalNavigation GlobalNavigation;
    public RulesInfringementController RulesInfringement;
    public ThingController ThingController;
    public RagdollController Ragdoll;
    public SwitcherAnimationController SwitcherAnimation;
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

            if (Input.GetKeyUp(keyForwardMove) || Input.GetKeyUp(keyBackMove) || Input.GetKeyUp(keyLeftMove) || Input.GetKeyUp(keyRightMove))
            {
                SwitcherAnimation.SetTriggerStand();
                Ragdoll.ChangeIsKinematic(true);
            }

            if (Input.GetKeyDown(keyForwardMove) || Input.GetKeyDown(keyBackMove) || Input.GetKeyDown(keyLeftMove) || Input.GetKeyDown(keyRightMove))
            {
                SwitcherAnimation.SetTriggerWalk();
                Ragdoll.ChangeIsKinematic(false);
            }

            transform.localPosition += newTransformPosition * speed;
        }

        if (Input.GetKeyUp(keyActivePauseWindow))
        {
            GlobalNavigation.OpenPauseWindow(!GlobalVariables.PAUSE_WINDOW.activeSelf);
        }
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
                ActionDangerObject(state);
                break;
            case "DeathObject":
                ActionDeathObject(state);
                break;

            case "OnEndTaskScenarioOPN":
                ScenarioOPN.NextStepScenarioOPN.SetActive(true);
                collider.transform.parent.gameObject.SetActive(false);
                break;

            case "NextStepScenarioOPN":
                ScenarioOPN.NextStep();
                collider.gameObject.SetActive(false);
                break;
            case "CheckThing":
                if (state) collider.GetComponent<ThingController>().CheckThingOnPlayer();
                collider.gameObject.SetActive(false);
                break;
        }
    }

    void ActionDangerObject(bool state)
    {
        if (GlobalVariables.TASK_MODE == GlobalVariables.TEST_MODE) GlobalVariables.WARNING_DEATH_WINDOW.SetActive(state);

        RulesInfringement.EntranceInDangerZone(state);
        if (state) GlobalVariables.DEATH_WINDOW.SetActive(!state);
    }

    void ActionDeathObject(bool state)
    {
        GlobalVariables.DEATH_WINDOW.SetActive(state);
        GlobalVariables.DEATH_WINDOW.transform.Find("Btn_" + GlobalVariables.TASK_MODE).gameObject.SetActive(state);

        GlobalVariables.USER_IN_DEATH_ZONE = state;

        if (state)
        {
            GlobalVariables.USER_FREEZE = state;
            GlobalVariables.WARNING_DEATH_WINDOW.SetActive(!state);
        }
    }

    public void ReplaceUserFreese(bool state)
    {
        GlobalVariables.USER_FREEZE = state;
    }
}
