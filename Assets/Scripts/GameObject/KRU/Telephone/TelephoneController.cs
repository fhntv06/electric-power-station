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
    }

    IEnumerator WaitPlayPhoneSong(bool state)
    {
        if (state) yield return new WaitForSeconds(3);
        GetComponent<AudioSource>().enabled = state;
        GetComponent<AudioSource>().volume = state ? 0.2f : 0;
        indicatorRing.SetActive(state);
    }
}
