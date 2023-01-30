using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;
    readonly float SENSIVITY__MOUSE = 200f;

    float mouseX;
    float mouseY;

    void FixedUpdate()
    {
        mouseX = Input.GetAxis("Mouse X") * SENSIVITY__MOUSE * Time.fixedDeltaTime;
        mouseY = Input.GetAxis("Mouse Y") * SENSIVITY__MOUSE * Time.fixedDeltaTime;

        Player.Rotate(mouseX * new Vector3(0, 1, 0));

        transform.Rotate(-mouseY * new Vector3(1, 0, 0));
    }
}
