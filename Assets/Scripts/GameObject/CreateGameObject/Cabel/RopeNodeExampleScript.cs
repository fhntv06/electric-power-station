using UnityEngine;
public class RopeNodeExampleScript : MonoBehaviour
{
    public GameObject target, ropesample, lbond, rbond;

    public float step = 0.2f; //шаг веревки 
    private SpringJoint[] sj; //все компоненты пружины
    public int spring = 1;
    public float damper = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Получаем все компоненты пружины
        sj = GetComponents<SpringJoint>();
        // Выключаем их (это нужно, чтобы корректно настроить связи).
        // Можно изначально держать их выключеными.
        sj[0].enableCollision = false;
        sj[1].enableCollision = false;

        // определяем вектор нашей цепи
        Vector3 tarvec = target.transform.position - transform.position;
        // проверяем, если дистанция до целевого объекта больше шага, то создаем звено
        if (tarvec.magnitude > step)
        {
            // создаем звено
            GameObject newrope = Instantiate(ropesample, transform.position +
                tarvec.normalized * step, Quaternion.identity);
            // получаем доступ к скрипту нового звена
            RopeNodeExampleScript newrope_rope = newrope.GetComponent<RopeNodeExampleScript>();
            // устанавливаем левую связь для нового звена
            newrope_rope.lbond = gameObject;
            // устанавливаем объект-цель для нового звена
            newrope_rope.target = target;
            // устанавливаем правую связь для текущего звена
            rbond = newrope;

        }
        else // если дистанция до целевого объекта меньше шага, то замыкаем цепь на нем
        {
            //замыкаем правую связь на объекте-цели
            rbond = target;
            //добавляем пружинную связь на объект цель
            SpringJoint ropeknot_sj = target.AddComponent<SpringJoint>();
            //эти параметры подбираются экспериментально по вкусу для своей игры
            ropeknot_sj.spring = spring;
            ropeknot_sj.damper = damper;
            //присоединяем к этой связи наше звено
            ropeknot_sj.connectedBody = GetComponent<Rigidbody>();
        }

        //присоединяем к пружинам левое и правое тело
        sj[0].connectedBody = lbond.GetComponent<Rigidbody>();
        sj[1].connectedBody = rbond.GetComponent<Rigidbody>();
        //активируем пружинные модули
        sj[0].enableCollision = true;
        sj[1].enableCollision = true;
    }
}