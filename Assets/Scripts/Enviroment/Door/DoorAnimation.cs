using JetBrains.Annotations;
using System;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public float speedAnimation;
    public GameObject Text;
    bool doorIsOpened = false;
    private Animation doorAnimation;
    void Start()
    {
        doorAnimation = GetComponent<Animation>();
        doorAnimation["open_door_one"].speed = speedAnimation;
        doorAnimation["close_door_one"].speed = speedAnimation;

    }
    void Update()
    {
        if (doorAnimation.isPlaying) return;

        if (Input.GetKeyUp(KeyCode.F))
        {
            string animateName = doorIsOpened ? "open_door_one" : "close_door_one";
            doorAnimation.Play(animateName);
            doorIsOpened = !doorIsOpened;
        }
    }
    void OnTriggerEnter(Collider other)
    {
    }
    void OnTriggerExit(Collider other)
    {
        Text.SetActive(false);
    }

}
