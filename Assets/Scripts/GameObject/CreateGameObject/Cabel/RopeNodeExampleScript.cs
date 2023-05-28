using UnityEngine;
public class RopeNodeExampleScript : MonoBehaviour
{
    public GameObject target, ropesample, lbond, rbond;

    public float step = 0.2f; //��� ������� 
    private SpringJoint[] sj; //��� ���������� �������
    public int spring = 1;
    public float damper = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // �������� ��� ���������� �������
        sj = GetComponents<SpringJoint>();
        // ��������� �� (��� �����, ����� ��������� ��������� �����).
        // ����� ���������� ������� �� �����������.
        sj[0].enableCollision = false;
        sj[1].enableCollision = false;

        // ���������� ������ ����� ����
        Vector3 tarvec = target.transform.position - transform.position;
        // ���������, ���� ��������� �� �������� ������� ������ ����, �� ������� �����
        if (tarvec.magnitude > step)
        {
            // ������� �����
            GameObject newrope = Instantiate(ropesample, transform.position +
                tarvec.normalized * step, Quaternion.identity);
            // �������� ������ � ������� ������ �����
            RopeNodeExampleScript newrope_rope = newrope.GetComponent<RopeNodeExampleScript>();
            // ������������� ����� ����� ��� ������ �����
            newrope_rope.lbond = gameObject;
            // ������������� ������-���� ��� ������ �����
            newrope_rope.target = target;
            // ������������� ������ ����� ��� �������� �����
            rbond = newrope;

        }
        else // ���� ��������� �� �������� ������� ������ ����, �� �������� ���� �� ���
        {
            //�������� ������ ����� �� �������-����
            rbond = target;
            //��������� ��������� ����� �� ������ ����
            SpringJoint ropeknot_sj = target.AddComponent<SpringJoint>();
            //��� ��������� ����������� ���������������� �� ����� ��� ����� ����
            ropeknot_sj.spring = spring;
            ropeknot_sj.damper = damper;
            //������������ � ���� ����� ���� �����
            ropeknot_sj.connectedBody = GetComponent<Rigidbody>();
        }

        //������������ � �������� ����� � ������ ����
        sj[0].connectedBody = lbond.GetComponent<Rigidbody>();
        sj[1].connectedBody = rbond.GetComponent<Rigidbody>();
        //���������� ��������� ������
        sj[0].enableCollision = true;
        sj[1].enableCollision = true;
    }
}