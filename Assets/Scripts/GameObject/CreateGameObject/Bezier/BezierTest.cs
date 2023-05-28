using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;
using UnityEngine;

public class BezierTest : MonoBehaviour
{

    public Transform P0;
    public Transform P1;
    public Transform P2;
    public Transform P3;

    // public int volumeParts;
    public float step;

    public GameObject prefab;
    public Transform parts;

    public float mass;
    public float drag;


    void Start()
    {
        int volumeParts = Mathf.RoundToInt(1f / step) + 1; // +1 for hidden last point P3
        GameObject prevCabel = null;

        ClearChildren(parts);

        for (int i = 0; i < volumeParts; i++)
        {
            Transform cabel = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity).transform;
            Vector3 position = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, step * i);
            Quaternion rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(P0.position, P1.position, P2.position, P3.position, step * i));

            cabel.GetComponent<Rigidbody>().mass = mass;
            cabel.GetComponent<Rigidbody>().drag = drag;
            cabel.SetPositionAndRotation(position, rotation);

            if (i > 0)
            {
                cabel.GetComponents<FixedJoint>()[0].connectedBody = prevCabel.GetComponent<Rigidbody>();
                prevCabel.GetComponents<FixedJoint>()[1].connectedBody = cabel.GetComponent<Rigidbody>();
            }
            // first
            if (i == 0)
            {
                P0.GetComponent<FixedJoint>().connectedBody = cabel.GetComponent<Rigidbody>();
                cabel.GetComponents<FixedJoint>()[0].connectedBody = P0.GetComponent<Rigidbody>();
            }

            // last
            if (i == volumeParts - 1)
            {
                cabel.GetComponents<FixedJoint>()[1].connectedBody = P3.GetComponent<Rigidbody>();
                P3.GetComponent<FixedJoint>().connectedBody = cabel.GetComponent<Rigidbody>();
            }

            prevCabel = cabel.gameObject;

            cabel.SetParent(parts);
        }
    }

    void ClearChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            print("Delete");
            Destroy(child.gameObject);
            DestroyImmediate(child.gameObject);
        }
    }

    [ExecuteAlways]
    private void OnDrawGizmos() {

        int sigmentsNumber = 20;
        Vector3 preveousePoint = P0.position;

        for (int i = 0; i < sigmentsNumber + 1; i++) {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(P0.position, P1.position, P2.position, P3.position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }

    }
}
