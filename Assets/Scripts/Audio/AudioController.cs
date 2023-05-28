using UnityEngine;

public class AudioController : MonoBehaviour
{
    public void PlayAudio(Collider AudioSource, bool state)
    {
        AudioSource.GetComponent<AudioSource>().enabled = state;
    }

    public void StopSignalized(Collider element)
    {
        Transform parent = element.transform.parent;

        foreach (Transform child in parent)
            if (child.tag == "AudioSource") child.GetComponent<AudioSource>().enabled = false;
    }
}
