using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
        GetInput();
    }

    void GetInput()
    {
        Vector3 newTransformPosition = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.W)) newTransformPosition = transform.forward;
        if (Input.GetKey(KeyCode.S)) newTransformPosition = -transform.forward;
        if (Input.GetKey(KeyCode.A)) newTransformPosition = -transform.right;
        if (Input.GetKey(KeyCode.D)) newTransformPosition = transform.right;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A)) newTransformPosition = transform.forward + -transform.right;
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) newTransformPosition = -transform.forward + -transform.right;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) newTransformPosition = transform.forward + transform.right;
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D)) newTransformPosition = -transform.forward + transform.right;

        transform.localPosition += newTransformPosition * speed; 
    }
}
