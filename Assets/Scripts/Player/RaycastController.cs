using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    public EditorTaskController EditorTaskController;
    public GlobalNavigation GlobalNavigation;

    public Text message;
    public GameObject OrbitObject;

    private RaycastHit hit;
    private Ray ray;
    private Collider collider;
    private bool state = false;
    private int step = 0;
    private string text = "";
    private LayerMask layerMask;

    void Start()
    {
        layerMask = 1 << LayerMask.NameToLayer("Things");
    }
    void Update()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 4, layerMask))
            message.text = SetMessage();
        else
            if (message.text != "") StartCoroutine(resetMessage());
    }

    string SetMessage()
    {
       
        collider = hit.collider;
        step = ScenarioOPN.scenarioOPNPhoneBlockedStep;
        switch (collider.tag)
        {
            case "Door":
                Interaction interactionComponent = collider.GetComponent<Interaction>();
                    text = interactionComponent.flag ? "Закрыть дверь" : "Открыть дверь";

                if (Input.GetKeyUp(KeyCode.F)) interactionComponent.ChangeStateAnimateOpenClose();
                break;
            case "ElectObj":
                    text = "Осмотреть объект";

                if (Input.GetKeyUp(KeyCode.F)) OrbitObject.GetComponent<ShowOrbitObject>().ActiveShowOrbitMode(hit);
                break;
            case "Phone":
                switch (step)
                {
                    case 0:
                            text = "Вступить на смену";

                        if (Input.GetKeyUp(KeyCode.F))
                        {
                            collider.GetComponent<TelephoneController>().PlayRingPhone(false);
                            EditorTaskController.SetTaskScenario();
                        }
                        break;
                    case 2:
                            text = "Сообщить о возникновении аварии";
                        if (Input.GetKeyUp(KeyCode.F)) EditorTaskController.SetTaskScenario();

                        break;
                    case 3:
                            text = "Сообщить о ликвидации аварии";
                        if (Input.GetKeyUp(KeyCode.F)) collider.GetComponent<Navigation>().SetProgressTask();
                        break;
                }
                break;
            case "Thing":
                    text = "Взять";
                if (Input.GetKeyUp(KeyCode.F)) collider.GetComponent<ThingController>().PlayersTakeThing(collider);
                break;
            case "AudioSource":
                    text = "Включить";
                state = Input.GetKey(KeyCode.F);
                collider.GetComponent<AudioController>().PlayAudio(collider, state);
                break;
            case "StopSignalized":
                    text = "Съем звуковой сигнализации";
                if (Input.GetKeyUp(KeyCode.F)) collider.GetComponent<AudioController>().StopSignalized(collider);
                break;
            case "SwitchDrive":
                string[] name = collider.name.Split('_');
                if (name[2] == "on")
                {
                    state = false;
                        text = "Отключить " + name[0] + "(" + name[1] + ")";
                }
                if (name[2] == "off")
                {
                    state = true;
                        text = "Включить " + name[0] + "(" + name[1] + ")";
                }

                if (Input.GetKeyUp(KeyCode.F)) collider.GetComponent<SwitcherElectricController>().ChangeStateSwitch(state);
                break;
            case "Magazine":
                switch (step)
                {
                    case 0:
                    case 1:
                            text = "Зафиксировать приемку смены";
                        break;
                    case 2:
                            text = "Зафиксировать время начала аварии";
                        break;
                    case 3:
                            text = "Зафиксировать совершенные переключения";
                        break;
                }

                if (Input.GetKeyUp(KeyCode.F)) GlobalNavigation.SwitcherContentPauseWindow("Magazine");
                break;
        }


        return text;
    }

    IEnumerator resetMessage()
    {
        yield return new WaitForSeconds(.5f);
        text = "";
        message.text = "";
    }
}
