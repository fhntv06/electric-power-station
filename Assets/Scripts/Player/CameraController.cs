using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public Transform Player;
    public float SENSIVITY_MOUSE = 100f;

    float mouseX;
    float mouseY;

    void Update()
    {
        if (!GlobalVariables.USER_FREEZE)
        {
            mouseX = Input.GetAxis("Mouse X") * SENSIVITY_MOUSE * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * SENSIVITY_MOUSE * Time.deltaTime;

            Player.Rotate(mouseX * new Vector3(0, 1, 0));
            transform.Rotate(-mouseY * new Vector3(1, 0, 0));
        }
    }
}
