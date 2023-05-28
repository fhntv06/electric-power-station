# Методы
## Общие методы
### Start()
<blockquote>
  Метод запускающийся при старте игры
</blockquote>

### Update()
<blockquote>
  Метод запускающийся количество раз равное количеству кадров игры например, при просадке производительности будет 40 запусков в секунду, а при нормальной работе 60.
</blockquote>

### FixedUpdate()
<blockquote>
  Метод запускающися фиксированное количество раз количество раз настраивается в настройках Unity
</blockquote>

### OnDestroy()
<blockquote>
  Метод срабатывает в момент удаления объекта, на который он был повешен
</blockquote>

## Методы для игровых объектов
### AddForce()
  <blockquote>
    <p>Метод добавляет "толчок" к выбранному объекту. Может применяться с методом <b><a href="#OnCollisionEnter">OnCollisionEnter()</a></b></p>
  </blockquote>
  <pre>
    private void OnCollisionEnter(Collision other) {
      _rb1 = other.gameObject.GetComponent<Rigidbody>();
      _rb1.AddForce(new Vector3(1,1,1) * 500f);
    }
  </pre>
  <h4>Параметры:</h4>
  <pre>AddForce([Coorginates])</pre>
  <p><b>[Coorginates]</b> - координаты в направлении, которых будет толчок</p>

### Destroy()
  <blockquote>
    Метод уничтожает объект
  </blockquote>
  <pre>Destroy([GameObject])</pre>

### Instantial()
<blockquote>
    Метод создает объект
  </blockquote>
<pre>Instantial([GameObject], [Coorginates], [Rotation]);</pre>
<h4>Параметры:</h4>
  <ul>
    <li><b>[GameObject]</b> - объект</li>
    <li><b>[Coorginates]</b> - координаты появления объекта</li>
    <li><b>[Rotation]</b> - угол поворота объекта при появлении</li>
  </ul>
  <h4>Пример:</h4>
  <p>Присвоено значение в новый объект. При присвоении Instantiate новому игровому объекту в конце дописывается "as GameObject"</p>
  <pre>GameObject newObject = Instantiate(obj, new Vector3(0, 5, 5), Quaternion.Euler(12f, -15f, 40f)) as GameObject;</pre>
  <p>Для простого добавления объекта, например, на Canvas для Quaternion нужно использовать: <i>Quaternion.identity</i></p>
  
### OnCollisionEnter(Collision other) 
<blockquote id="OnCollisionEnter">
  <p>Метод позволяет отследить случившееся соприкосновение твердым объектов</p>
  <p>Пример: все объекты имеющие Box Collider и Rigidbody, с которыми будет соприкосновение уничтожатся</p>
  <ul>
    <li>other - тот объект, с которым мы взаимодействуем</li>
    <li>gameObject - используется для обращения к игровому объекту</li>
  <ul>
</blockquote>
<pre>
  private void OnCollisionEnter(Collision other) {
    other.gameObject.SetActive(false);
  }
</pre>

### OnCollisionStay(Collision other) 
<blockquote>
  <p>Метод позволяет отследить остающееся соприкосновение твердым объектов</p>
  <p>Синтаксис такой же <a href="#OnCollisionEnter">OnCollisionEnter</a></p>
</blockquote>

### OnCollisionExit(Collision other) 
<blockquote>
  <p>Метод позволяет отследить исчезновение соприкосновения твердым объектов</p>
  <p>Синтаксис такой же <a href="#OnCollisionEnter">OnCollisionEnter</a></p>
</blockquote>

### OnTriggerEnter(Collision other) 
<blockquote id="OnTriggerEnter">
  <p>Метод позволяет отследить случившееся соприкосновение не твердым объектов</p>
  <p>Пример: все объекты имеющие Box Collider и Rigidbody, с которыми будет соприкосновение уничтожатся</p>
</blockquote>
<pre>
  private void OnTriggerEnter(Collision other) {
    other.gameObject.SetActive(false);
  }
</pre>

### OnTriggerStay(Collision other) 
<blockquote>
  <p>Метод позволяет отследить остающееся соприкосновение не твердым объектов</p>
  <p>Синтаксис такой же <a href="#OnTriggerEnter">OnTriggerEnter</a></p>
</blockquote>

### OnTriggerExit(Collision other) 
<blockquote>
  <p>Метод позволяет отследить исчезновение соприкосновения не твердым объектов</p>
  <p>Синтаксис такой же <a href="#OnTriggerEnter">OnTriggerEnter</a></p>
</blockquote>

### SetActive()
  <blockquote>
    Метод управляет активностью объекта
  </blockquote>
  <h4>Параметры:</h4>
  <ul>
    <li><b>true</b> - показывает объект на сцене</li>
    <li><b>false</b> - скрывает объект со сцены</li>
  </ul>
  <h4>Пример: объект пропадет</h4>
  <pre>[GameObject].SetActive(false)</pre>

### Rotate()
  <blockquote>
    Метод дает возможность вращать объекты.
  </blockquote>
  <b>Синтаксис:<b> 
  <b><pre>[GameObject].transform.Rotate(new Vector3(x, y, z) * [например домножение на ускорение или коэффициент]);</pre></b>
  <blockquote>Коэффициент будет изменять только те координаты, значение которых отлично от 0.</blockquote>

### Translate()
  <blockquote>
    Метод дает возможность перемещать объекты
  </blockquote>
  <b>Синтаксис:</b> 
  <pre><b>[GameObject].Translate(new Vector3(x, y, z) * [например домножение на ускорение или коэффициент]);</b></pre>
  <blockquote>Коэффициент будет изменять только те координаты, значение которых отлично от 0.</blockquote>

### ProjectOnPlane()
  <blockquote>
    Возвращает проекцию переданного вектора на плоскость
  </blockquote>
  <b>Синтаксис:</b> 
  <pre><b>Vector3.ProjectOnPlane([someVector3], [direction]);</b></pre>
  <blockquote>Коэффициент будет изменять только те координаты, значение которых отлично от 0.</blockquote>

