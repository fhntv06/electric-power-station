using System;
# Общая информация
## Переменные
  <blockquote>
    <p>Показана не будет<pre>private string name;</pre></p> 
  </blockquote>

### Если переменная была privat и вы хотим её показать
  <blockquote>
    <p><i>Работает при подключении using System</i></p>
    <p>Показана будет<pre>[Serializable]<br>private string name;</pre></p> 
  </blockquote>

### Показать переменнную в Unity
  <blockquote>
    <p>Показана будет<pre>public string name;</pre></p> 
  </blockquote>

### Скрытие переменной от Unity
  <blockquote>
    <p><i>Работает при подключении System</i></p>
    <p>Показана не будет<pre>[NonSerialized]<br>public string name;</pre></p> 
  </blockquote>

## Работа с игровым объектом
  ### Работа с компонентами
  <blockquote>
    <p>Компонент позволяет получить данные о позиции и вращении и размере игрового объекта.</p>
    <p>Также можно у компонента получить игровой объект через ".gameObject": <pre>transform[i].gameObject</pre></p>
    <p>Возможно получить имя объекта через ".name": <pre>transform[i].gameObject.name</pre></p>
    <p>Если скрипт весит на нужном нам объекте, то к свойствам можно обратиться через gameObject: <pre>gameObject.Translate(new Vector3(x, y, z)</pre></p>
  </blockquote>

  <h4>Компонент Transform:</h4>
  <p>Пример:</p>
  <pre>
    <ul>
      <li>Position: GameObject.GetComponent<Transform>().position = new Vector3(x, y, z);</li>
      <li>Rotation: GameObject.GetComponent<Transform>().rotation = Quaternion.Euler(x, y, z);</li>
      <li>Scale: GameObject.GetComponent<Transform>().scale = new Vector3(x, y, z); - <i>не верно</i></li>
    </ul>
  </pre>

## Работа с пользователем
<blockquote>
  <p>Нажатие клавиш можно отслеживать с помощью: <pre>Input.GetKeyUp(KeyCode.[KeyCode])</pre></p>
  <p>Пример: если нажата клавишу <b>W</b>, то переместить объект во реальном времени <b>Time.deltaTime</b> со скоростью moveSpeed по координатам <b>new Vector3(1, 0, 0)</b> - координата <b>x</b> будет изменяться.</p>
  <pre>
    if ( Input.GetKey(KeyCode.W) ) {
        transform.Translate(new Vector3(1, 0, 0) * moveSpeed * Time.deltaTime);
      }
  </pre>
</blockquote>

## Работа с физикой
<blockquote>
  <p>Лучше получать один раз данные при запуске сцены, которые нужно будет использовать много раз. Такое получение реализуется в методе <b>Awake()</b></p>
  <p>Работа с физикой происходит в методе <b>FixedUpdate()</b>:</p>
  <pre>
    public float speed = 5f, hSpeed = 10f;  
    private Rigidbody _rb;
    <br>
    private void Awake() {
      _rb = GetComponent<Rigidbody>();
    }
    <br>
    private void FixedUpdate() {
      float h = Input.GetAxis("Horizontal") * hSpeed * Time.deltaTime;
      float v = Input.GetAxis("Vertical") * speed * Time.deltaTime;
      _rb.velocity = transform.TransformDirection(new Vector3(h, _rb.velocity.y, v));
    }
  </pre>
</blockquote>

## Работа с курсором
<blockquote>
  <p>Во время игры требуется скрыть курсор.</p>
   <pre>
    void Start () {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
    }
   </pre>
</blockquote>

## Работа с анимацией
<blockquote>
    <p><a href="https://docs.unity3d.com/ScriptReference/Animation.html">Документация</a></p>
    <p>Получение компонента анимации</p>
    <pre>
        private void Start()
        {
            private Animation doorAnimation;
            doorAnimation = GetComponent<Animation>();
        }
    </pre>
    <p>Пример изменения свойста speed анимации</p>
    <pre>
        [component__animation]["[name__animation]"].speed = 0.5f;
    </pre>
    <p>Проигрывние анимации</p>
    <pre>
        [component__animation].Play("[name__animation]");
    </pre>
</blockquote>

## Работа с UI
<blockquote>
  <p>При использовании GetMouseButtonDown([number__button]) нарушается нажатие на кнопку. Для устранения этого можно добавить проверку, что курсор находится на кнопке - EventSystem.current.IsPointerOverGameObject()</p>
</blockquote>

