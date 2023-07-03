using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GlobalVariables GlobalVariables;

    public Transform Player;
    public float SENSIVITY_MOUSE = 100f;
    public float borderRotateCameraUp = .4f;
    public float borderRotateCameraDown = -.35f;

    float mouseX;
    float mouseY;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        Cursor.visible = false;
        if (!GlobalVariables.USER_FREEZE)
        {
            mouseX = Input.GetAxis("Mouse X") * SENSIVITY_MOUSE * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * SENSIVITY_MOUSE * Time.deltaTime;


            transform.Rotate(-mouseY * new Vector3(1, 0, 0));
            Player.Rotate(mouseX * new Vector3(0, 1, 0));
        }
    }
}
