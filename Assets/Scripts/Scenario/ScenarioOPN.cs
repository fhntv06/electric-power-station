using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioOPN : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public Transform cabel;
    public Transform cabelChildFront;
    public Transform cabelChildBack;

    public Vector3 cabelPositionNew;
    public Vector3 cabelChildPositionNew;
    public Vector3 sparksPositionNew;

    public GameObject sparks;
    public GameObject windowTransition;
    public GameObject windowDeath;
    public GameObject windowWarning;

    public GameObject NextStepScenarioOPN;

    public GameObject DangerObject;
    public GameObject DeathObject;

    float delayShowWindowTransition = 5;
    bool delayActive = false;

    public static int scenarioOPNPhoneBlockedStep = 0;
    void Update()
    {
        if (delayActive)
        {
            delayShowWindowTransition -= Time.deltaTime;

            if (delayShowWindowTransition <= 0)
                ToggleStateWindowTransition(false);
        }
    }
    public void ToggleStateWindowTransition(bool state)
    {
        windowTransition.SetActive(state);
        delayActive = state;
        GlobalVariables.USER_FREEZE = state;
        scenarioOPNPhoneBlockedStep = 2;
        DangerObject.SetActive(true);
        DeathObject.SetActive(true);
    }

    public void NextStep()
    {
        ToggleStateWindowTransition(true);
        ChangePositionCabel();
        AddSparksEffect();
        ChangeWeather();
        ChangeLigth();
    }

    public void ChangeWeather() // плохая погода
    {

    }
    public void ChangeLigth() // ночь на дворе
    {

    }
    public void ChangePositionCabel()
    {
        cabel.localPosition = cabelPositionNew;
        cabelChildFront.localPosition = cabelChildPositionNew;
        cabelChildBack.localPosition = cabelChildPositionNew;
    }

    public void AddSparksEffect()
    {
        GameObject sparksClone = Instantiate(sparks, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        sparksClone.transform.SetParent(cabel);
        sparksClone.transform.localPosition = sparksPositionNew;
    }
}
