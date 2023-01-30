using JetBrains.Annotations;
using System;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public float speedAnimation;
    public GameObject Text;
    bool doorIsOpened = false;
    private Animation doorAnimation;
    private void Start()
    {
        doorAnimation = GetComponent<Animation>();
        doorAnimation["open__door"].speed = speedAnimation;

    }
    private void Update()
    {
        if (doorAnimation.isPlaying)
        {
            return;
        }

        if (Input.GetKeyUp(KeyCode.F))
        {

            if (doorIsOpened == false)
            {
                doorAnimation.Play("open__door");
                foreach (AnimationState state in doorAnimation)
                {
                    print(state.speed);
                }

            }
            if (doorIsOpened == true)
            {
                doorAnimation.Play("close__door");
            }

            doorIsOpened = !doorIsOpened;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Text.SetActive(true);
        Debug.Log(123);
    }
    void OnTriggerExit(Collider other)
    {
        Text.SetActive(false);
    }

}
