using UnityEngine;

//��� ������� ���������� ��� ��� ������ �� ��������� ���� �� ������ ����� ������������� ������ ����������
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

// ������ �� ������: https://ru.stackoverflow.com/questions/936026/%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F-%D1%80%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F-%D0%BF%D0%B5%D1%80%D0%B5%D0%B4%D0%B2%D0%B8%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D0%BF%D0%B5%D1%80%D1%81%D0%BE%D0%BD%D0%B0%D0%B6%D0%B0 
public class MovePhysicController : MonoBehaviour
{
    public float Speed = 0.3f;
    public float JumpForce = 1f;

    //���� ����������� ������� ��� ����.
    //��� �� ��������� ��� ��� Player ��� �� ��������� � ������� ����. 

    //!!!!�������� �� ���� ������������� Layer, �������� Player!!!!
    public LayerMask GroundLayer = 1; // 1 == "Default"

    private Rigidbody rb;
    private CapsuleCollider collider; // ������ ��������� ������������ CapsuleCollider
    //� ������� ���� ��������� ���� �� ����

    private bool IsGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z);

            //������� ��������� ���������� ������� � ��������� �� ���������� �� ��� ������ ������� ��������� � ����

            //collider.bounds.size.x / 2 * 0.9f -- ��� �������� ����������� ����� ������ �������.
            // ��� �� ����������� ������ -- ������ �� ������ ��������, � ��� ����� ��-�������������

            return Physics.CheckCapsule(collider.bounds.center, bottomCenterPoint, collider.bounds.size.x / 2 * 0.9f, GroundLayer);
            // ���� ����� ����� ������� � �������, �� ����� ����� �������� ���������� 0.9 �� �������.
        }
    }

    private Vector3 MovementVector
    {
        get
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            return new Vector3(horizontal, 0.0f, vertical);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collider = GetComponent<CapsuleCollider>();

        //�.�. ��� �� ����� ��� �� �������� ��� ������ ��� ��-���� ��� ������ �� �� ��������.
        //�� ����� ��������� ������� �� ���� X � Z
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //  ������ �� ������
        if (GroundLayer == gameObject.layer)
            Debug.LogError("Player SortingLayer must be different from Ground SourtingLayer!");
    }

    void FixedUpdate()
    {
        JumpLogic();
        MoveLogic();
    }

    private void MoveLogic()
    {
        // �.�. �� ������ ������ ������������ ���������� �������� �����,
        // �� ������ � ��������� Time.fixedDeltaTime
        rb.AddForce(MovementVector * Speed, ForceMode.Impulse);
    }

    private void JumpLogic()
    {
        if (IsGrounded && (Input.GetAxis("Jump") > 0))
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}