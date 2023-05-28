using UnityEngine;

public class RopeExampleScript : MonoBehaviour
{
    public GameObject target, samplerope;
    public float step = 0.2f; //шаг веревки
    public int spring = 1;
    public int damper = 1;

    // Start is called before the first frame update
    void Start()
    {
        // определяем вектор нашей цепи
        Vector3 tarvec = target.transform.position - transform.position;
        // создаем образец звена и помещаем в нужную позицию сдвигаясь на один шаг
        GameObject newrope = Instantiate(samplerope, transform.position +
            tarvec.normalized * step, Quaternion.identity);
        // получаем доступ к параметрам скрипта звена
        RopeNodeExampleScript newrope_rnes = newrope.GetComponent<RopeNodeExampleScript>();
        // указываем левую связь
        newrope_rnes.lbond = gameObject;
        // указываем объект-цель
        newrope_rnes.target = target;

        // добавляем на объект-источник пружинную связь
        SpringJoint source_sj = gameObject.AddComponent<SpringJoint>();
        // эти параметры подбираются экспериментально по вкусу для своей игры
        source_sj.spring = 25;
        source_sj.damper = 1;
        // присоединяем к этой связи наше новое звено
        source_sj.connectedBody = newrope.GetComponent<Rigidbody>();
    }
}