using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GenerationCabel : MonoBehaviour
{
    public int steps = 100;
    public float radius;
    public bool invertNormals;

    void Generate()
    {
        Transform tp1 = transform;
        Transform tp2 = transform.GetChild(0);

        Vector3 p1 = Vector3.zero;
        Vector3 p2 = tp2.position - tp1.position;

        // для определения поворота
        Vector3 projectOnPlane = Vector3.ProjectOnPlane(p2 - p1, Vector3.up);
        float angle = Vector3.SignedAngle(Vector3.right, projectOnPlane, Vector3.up);

        float length = projectOnPlane.magnitude;
        float height = Mathf.Abs(p2.y);

        Mesh m = new Mesh();
        List<Vector3> vertices = new List<Vector3>();

        float nSign = invertNormals ? -1f : 1f;

        for (int i = 0; i < steps; i++)
        {
            float a = height / (length * length);
            float x = i * length / steps;
            float y = a * x * x;

            float ny1 = y - (0 - x) / (2 * a * x);
            float ny2 = y - (1 - x) / (2 * a * x);

            Vector3 n1 = (new Vector3(0f, ny1, 0f) - new Vector3(1f, ny2, 0f)).normalized * radius;
            Vector3 n2 = -n1;
            Vector3 pos = new Vector3(x, y, 0f);

            Quaternion rot = Quaternion.Euler(0f, angle, 0f);
            vertices.Add(rot * (pos + n1 * nSign));
            vertices.Add(rot * (pos + n2 * nSign));
        }

        List<int> triangles = new List<int>();
        
        for (int i = 2; i < vertices.Count - 2; i += 2)
        {
            triangles.Add(i);
            triangles.Add(i + 3);
            triangles.Add(i + 1);
        
            triangles.Add(i);
            triangles.Add(i + 2);
            triangles.Add(i + 3);
        }

        m.vertices = vertices.ToArray();
        m.triangles = triangles.ToArray();
        m.RecalculateNormals();

        transform.GetComponent<MeshFilter>().mesh = m;
    }

    private void Update()
    {
        Generate();
    }
}
