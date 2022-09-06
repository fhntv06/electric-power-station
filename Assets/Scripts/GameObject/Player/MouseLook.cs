using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 200f;

    public Transform playerBody;
    
    float xRotation, yRotation;

    // Update is called once per frame

    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.fixedDeltaTime;
        
        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        playerBody.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
