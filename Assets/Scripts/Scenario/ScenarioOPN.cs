using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioOPN : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public GameObject sparks;
    public Transform cabelPoint;
    public Vector3 newCabelPointPosition;

    public GameObject windowTransition;
    public GameObject windowDeath;
    public GameObject windowWarning;

    public GameObject NextStepScenarioOPN;

    public GameObject DangerObject;
    public GameObject DeathObject;

    public AudioSource WarningSignaling;

    public static int scenarioOPNPhoneBlockedStep = 0;

    public List<GameObject> gameObjectsOnInStart = new List<GameObject>(2);

    public List<Renderer> indicators = new List<Renderer>(2);
    public Material indicatorOn;

    void Start()
    {
        foreach (GameObject gameobject in gameObjectsOnInStart)
            gameobject.SetActive(true);
    }

    public void ToggleStateWindowTransition(bool state)
    {
        windowTransition.SetActive(state);
        GlobalVariables.USER_FREEZE = state;
    }

    public void NextStep()
    {
        StartCoroutine(Delay());
        ChangePositionCabel();
        AddSparksEffect();
        ChangeWeather();
        ChangeLigth();
    }

    public void ChangeWeather() // плохая погода - change wearthe
    {

    }
    public void ChangeLigth() // ночь на дворе - night
    {

    }

    public void ChangePositionCabel()
    {
        cabelPoint.localPosition = newCabelPointPosition;
    }

    public void AddSparksEffect()
    {
        sparks.SetActive(true);
    }

    public void OnWarningSignaling()
    {
        WarningSignaling.enabled = true;
    }

    public void InitStateIndicators()
    {
        foreach (Renderer indicator in indicators)
            indicator.material = indicatorOn;
    }

    IEnumerator Delay()
    {
        ToggleStateWindowTransition(true);
        DangerObject.SetActive(true);
        DeathObject.SetActive(true);
        NextStepScenarioOPN.SetActive(false);
        scenarioOPNPhoneBlockedStep = 2;
        yield return new WaitForSeconds(5);
        ToggleStateWindowTransition(false);
        OnWarningSignaling();
        InitStateIndicators();
    }
}
