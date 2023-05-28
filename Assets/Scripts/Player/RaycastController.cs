using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    public EditorTaskController EditorTaskController;
    public GlobalNavigation GlobalNavigation;

    public Text message;
    public GameObject OrbitObject;

    private RaycastHit hit;
    private Collider collider;
    private bool state = false;
    private int step = 0;
    private string text = "";

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4))
        {
            collider = hit.collider;
            step = ScenarioOPN.scenarioOPNPhoneBlockedStep;
            switch (collider.tag)
            {
                case "Door":
                    Interaction interactionComponent = collider.GetComponent<Interaction>();
                    text = interactionComponent.flag ? "������� �����" : "������� �����";
                     
                    if (Input.GetKeyUp(KeyCode.F)) interactionComponent.ChangeStateAnimateOpenClose();
                    break;
                case "ElectObj":
                    text = "��������� ������";

                    if (Input.GetKeyUp(KeyCode.F)) OrbitObject.GetComponent<ShowOrbitObject>().ActiveShowOrbitMode(hit);
                    break;
                case "Phone":
                    switch (step) {
                        case 0:
                            text = "�������� �� �����";

                            if (Input.GetKeyUp(KeyCode.F))
                            {
                                collider.GetComponent<TelephoneController>().PlayRingPhone(false);
                                EditorTaskController.SetTaskScenario();
                            }
                            break;
                        case 2:
                            text = "�������� � ������������� ������";
                            if (Input.GetKeyUp(KeyCode.F)) EditorTaskController.SetTaskScenario();

                            break;
                        case 3:
                            text = "�������� � ���������� ������";
                            if (Input.GetKeyUp(KeyCode.F)) collider.GetComponent<Navigation>().SetProgressTask();
                            break;
                    }
                    break;
                case "Thing":
                    text = "�����";
                    if (Input.GetKeyUp(KeyCode.F)) collider.GetComponent<ThingController>().PlayersTakeThing(collider);
                    break;
                case "AudioSource":
                    text = "��������";
                    state = Input.GetKey(KeyCode.F);
                    collider.GetComponent<AudioController>().PlayAudio(collider, state);
                    break;
                case "StopSignalized":
                    text = "���� �������� ������������";
                    if (Input.GetKeyUp(KeyCode.F)) collider.GetComponent<AudioController>().StopSignalized(collider);
                    break;
                case "SwitchDrive":
                    string[] name = collider.name.Split('_');
                    if (name[2] == "on")
                    {
                        state = false;
                        text = "��������� " + name[0] + "(" + name[1] + ")";
                    }
                    if (name[2] == "off")
                    {
                        state = true;
                        text = "�������� " + name[0] + "(" + name[1] + ")";
                    }

                    if (Input.GetKeyUp(KeyCode.F)) collider.GetComponent<SwitcherElectricController>().ChangeStateSwitch(state);
                    break;
                case "Magazine":
                    switch (step)
                    {
                        case 0:
                        case 1:
                            text = "������������� ������� �����";
                            break;
                        case 2:
                            text = "������������� ����� ������ ������";
                            break;
                        case 3:
                            text = "������������� ����������� ������������";
                            break;
                    }

                    if (Input.GetKeyUp(KeyCode.F))
                    {
                        GlobalNavigation.SwitcherContentPauseWindow("Magazine");
                    }
                    break;
            }
        }
        else
        {
            text = "";
        }

        message.text = text;
    }
}
