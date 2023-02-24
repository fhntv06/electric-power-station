using UnityEngine;

//эти строчки гарантирют что наш скрипт не завалитс€ если на плеере будет отсутствовать нужные компоненты
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

// ссылка на автора: https://ru.stackoverflow.com/questions/936026/%D0%9F%D1%80%D0%B0%D0%B2%D0%B8%D0%BB%D1%8C%D0%BD%D0%B0%D1%8F-%D1%80%D0%B5%D0%B0%D0%BB%D0%B8%D0%B7%D0%B0%D1%86%D0%B8%D1%8F-%D0%BF%D0%B5%D1%80%D0%B5%D0%B4%D0%B2%D0%B8%D0%B6%D0%B5%D0%BD%D0%B8%D1%8F-%D0%BF%D0%B5%D1%80%D1%81%D0%BE%D0%BD%D0%B0%D0%B6%D0%B0 
public class MovePhysicController : MonoBehaviour
{
    public float Speed = 0.3f;
    public float JumpForce = 1f;

    //даем возможность выбрать тэг пола.
    //так же убедитесь что ваш Player сам не относитс€ к данному слою. 

    //!!!!Ќацепите на него нестандартный Layer, например Player!!!!
    public LayerMask GroundLayer = 1; // 1 == "Default"

    private Rigidbody rb;
    private CapsuleCollider collider; // теперь прийдетс€ использовать CapsuleCollider
    //и удалите бокс коллайдер если он есть

    private bool IsGrounded
    {
        get
        {
            var bottomCenterPoint = new Vector3(collider.bounds.center.x, collider.bounds.min.y, collider.bounds.center.z);

            //создаем невидимую физическую капсулу и провер€ем не пересекает ли она обьект который относитс€ к полу

            //collider.bounds.size.x / 2 * 0.9f -- эта странна€ конструкци€ берет радиус обьекта.
            // был бы об€зательно сферой -- бралс€ бы радиус напр€мую, а так пишем по-универсальнее

            return Physics.CheckCapsule(collider.bounds.center, bottomCenterPoint, collider.bounds.size.x / 2 * 0.9f, GroundLayer);
            // если можно будет прыгать в воздухе, то нужно будет изменить коэфициент 0.9 на меньший.
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

        //т.к. нам не нужно что бы персонаж мог падать сам по-себе без нашего на то указани€.
        //то нужно заблочить поворот по ос€х X и Z
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        //  «ащита от дурака
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
        // т.к. мы сейчас решили использовать физическое движение снова,
        // мы убрали и множитель Time.fixedDeltaTime
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