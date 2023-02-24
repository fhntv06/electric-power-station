using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ShowOrbitObject : MonoBehaviour
{
    public Transform camera;
    GameObject targetObject;
    public GameObject hiddenEnviroment;

    bool showOrbit = false;
    bool grabViewMode = false;
    bool orbitViewMode = false;

    public Vector3 offset;
    float prevMousePositionX;
    float prevMousePositionY;
    float newMousePositionX;
    float newMousePositionY;
    public int K = 4000;

    public float sensitivity = 3; // чувствительность мышки
    public float limit = 80; // ограничение вращения по Y
    public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    public float zoomMax = 10; // макс. увеличение
    public float zoomMin = 3; // мин. увеличение
    float X, Y;


    public Vector3 Scale;
    public Vector3 Position;
    public Vector3 Rotation;

    float speedRotate = 0.002f;

    bool rotateUp;
    bool rotateDown;
    bool rotateRigth;
    bool rotateLeft;

    void Update()
    {
        if (showOrbit) {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
                ZoomToObject(zoom);
            else if (Input.GetAxis("Mouse ScrollWheel") < 0)
                ZoomToObject(-zoom);

           if (Input.GetMouseButtonDown(0))
           {
                grabViewMode = true;
              prevMousePositionX = Input.mousePosition.x;
                prevMousePositionY = Input.mousePosition.y;
           }
           else if (Input.GetMouseButtonUp(0))
               grabViewMode = false;
           else if (Input.GetMouseButtonDown(1))
                orbitViewMode = true;
            else if (Input.GetMouseButtonUp(1))
                orbitViewMode = false;
            
            if (grabViewMode)
                GrabCameraViewMode();
            else if (orbitViewMode)
                OrbitCameraViewMode();

            // кнопки навигации
            //if (rotateUp)
            //{
            //ModelRotateUp();
            //}
            //else if (rotateLeft)
            //{
            //ModelRotateLeft();
            //}
            //else if (rotateRigth)
            //{
            //ModelRotateRigth();
            //}
            //else if (rotateDown)
            //{
            //ModelRotateDown();
            //}
        }
    }
    public void ActiveShowOrbitMode(RaycastHit hit)
    {
        hiddenEnviroment.SetActive(false);
        gameObject.SetActive(true);

        AddObject(hit);

        limit = Mathf.Abs(limit) > 90 ? 90 : limit;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);

        showOrbit = true;
    }

    void AddObject(RaycastHit hit)
    {
        targetObject = Instantiate(hit.transform.gameObject, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));

        targetObject.transform.SetParent(transform);
        targetObject.transform.localScale = Scale;
        targetObject.transform.position = Position;
        targetObject.transform.Rotate(Rotation);
    }
    void ZoomToObject(float zoom)
    {
        ChangeCameraPosition(0, 0, zoom);
    }

    void GrabCameraViewMode()
    {
        if (prevMousePositionX < Input.mousePosition.x)
        {
            newMousePositionX = Input.mousePosition.x / K;
            ChangeCameraPosition(newMousePositionX, 0, 0);
        }
        else
        {
            newMousePositionX = Input.mousePosition.x / -K;
            ChangeCameraPosition(newMousePositionX, 0, 0);
        }

        if (prevMousePositionY < Input.mousePosition.y)
        {
            newMousePositionY = Input.mousePosition.y / K;
            ChangeCameraPosition(0, newMousePositionY, 0);
        }
        else
        {
            newMousePositionY = Input.mousePosition.y / -K;
            ChangeCameraPosition(0, newMousePositionY, 0);
        }
    }

    void OrbitCameraViewMode()
    {
        X += Input.GetAxis("Mouse X") * sensitivity;
        Y += Input.GetAxis("Mouse Y") * sensitivity;

        Rotation = new Vector3(0, -X, -Y);
        targetObject.transform.localEulerAngles = Rotation;
    }

    void ChangeCameraPosition(float offsetX, float offsetY, float offsetZ)
    {
        camera.position = new Vector3(camera.position.x + offsetX, camera.position.y + offsetY, camera.position.z + offsetZ);
    }
    public void DeactiveShowOrbitMode()
    {
        showOrbit = false;
        Destroy(targetObject);

        gameObject.SetActive(false);
        hiddenEnviroment.SetActive(true);
    }

    // методы стрелок
    public void ModelRotateUpDown()
    {
        rotateUp = true;
    }
    void ModelRotateUp()
    {
        targetObject.transform.Rotate(Rotation + new Vector3(0, 0, 1) * Time.deltaTime * speedRotate);
    }
    public void ModelRotateUpUp()
    {
        rotateUp = false;
    }
    public void ModelRotateLeftDown()
    {
        rotateLeft = true;
    }
    void ModelRotateLeft()
    {
        targetObject.transform.Rotate(Rotation + new Vector3(0, -1, 0) * Time.deltaTime * speedRotate);
    }
    public void ModelRotateLeftUp()
    {
        rotateLeft = false;
    }
    public void ModelRotateRigthDown()
    {
        rotateRigth = true;
    }
    void ModelRotateRigth()
    {
        targetObject.transform.Rotate(Rotation + new Vector3(0, 1, 0) * Time.deltaTime * speedRotate);
    }
    public void ModelRotateRigthUp()
    {
        rotateRigth = false;
    }
    public void ModelRotateDownDown()
    {
        rotateDown = true;
    }
    void ModelRotateDown()
    {
        targetObject.transform.Rotate(Rotation + new Vector3(0, 0, -1) * Time.deltaTime * speedRotate);
    }
    public void ModelRotateDownUp()
    {
        rotateDown = false;
    }
}
