using UnityEngine;

public class RopeExampleScript : MonoBehaviour
{
    public GameObject target, samplerope;
    public float step = 0.2f; //��� �������
    public int spring = 1;
    public int damper = 1;

    // Start is called before the first frame update
    void Start()
    {
        // ���������� ������ ����� ����
        Vector3 tarvec = target.transform.position - transform.position;
        // ������� ������� ����� � �������� � ������ ������� ��������� �� ���� ���
        GameObject newrope = Instantiate(samplerope, transform.position +
            tarvec.normalized * step, Quaternion.identity);
        // �������� ������ � ���������� ������� �����
        RopeNodeExampleScript newrope_rnes = newrope.GetComponent<RopeNodeExampleScript>();
        // ��������� ����� �����
        newrope_rnes.lbond = gameObject;
        // ��������� ������-����
        newrope_rnes.target = target;

        // ��������� �� ������-�������� ��������� �����
        SpringJoint source_sj = gameObject.AddComponent<SpringJoint>();
        // ��� ��������� ����������� ���������������� �� ����� ��� ����� ����
        source_sj.spring = 25;
        source_sj.damper = 1;
        // ������������ � ���� ����� ���� ����� �����
        source_sj.connectedBody = newrope.GetComponent<Rigidbody>();
    }
}