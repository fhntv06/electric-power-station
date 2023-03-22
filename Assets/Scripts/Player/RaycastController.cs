using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastController : MonoBehaviour
{
    public Text message;
    public GameObject OrbitObject;
    
    RaycastHit hit;
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 4))
        {
            switch (hit.collider.tag)
            {
                case "Door":
                    Interaction interactionComponent = hit.collider.GetComponent<Interaction>();
                    message.text = interactionComponent.flag ? "Закрыть дверь" : "Открыть дверь";
                     

                    if (Input.GetKeyUp(KeyCode.F)) interactionComponent.ChangeStateAnimateOpenClose();
                    break;
                case "ElectObj":
                    message.text = "Осмотреть объект";

                    if (Input.GetKeyUp(KeyCode.F)) OrbitObject.GetComponent<ShowOrbitObject>().ActiveShowOrbitMode(hit);
                    break;
                case "Phone":
                    if (ScenarioOPN.scenarioOPNPhoneBlockedStep == 0)
                    {
                        message.text = "Ответить на звонок";
                        if (Input.GetKeyUp(KeyCode.F))
                        {
                            hit.collider.GetComponent<TelephoneController>().PlayRingPhone(false);
                            ScenarioOPN.scenarioOPNPhoneBlockedStep = 1;
                        }
                    }

                    if (ScenarioOPN.scenarioOPNPhoneBlockedStep == 2)
                    {
                        message.text = "Сообщить о результатах обхода";
                        // вкл окно с выбором ответа
                        if (Input.GetKeyUp(KeyCode.F)) hit.collider.GetComponent<Navigation>().SetProgressTask();
                    }
                    break;
            }

        }
        else
        {
            message.text = "";
        }
    }
}
