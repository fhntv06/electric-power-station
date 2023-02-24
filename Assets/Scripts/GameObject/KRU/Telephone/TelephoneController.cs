using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TelephoneController : MonoBehaviour
{
    public GameObject indicatorRing;    
    public EditorTaskController EditorTaskController;
    private void Start()
    {
        PlayRingPhone(true);
    }
    public void PlayRingPhone(bool onOrOff)
    {
        StartCoroutine(WaitPlayPhoneSong(onOrOff));

        if (!onOrOff) EditorTaskController.SetTaskScenarioOPN();
    }

    IEnumerator WaitPlayPhoneSong(bool state)
    {
        if (state) yield return new WaitForSeconds(2);
        GetComponent<AudioSource>().enabled = state;
        indicatorRing.SetActive(state);
    }
}
