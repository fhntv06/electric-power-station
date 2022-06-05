using System;
# Общая информация
## Переменные
  private string name; - показана не будет

### Если переменная была privat и вы хотим её показать
  [Serializable] - работает при подключении System
  private string name; - показана будет

### Показать переменнную в Unity
  public string name; - показана будет

### Скрытие переменной от Unity
  [NonSerialized] - работает при подключении System
  public string name; - показана не будет

## Работа с игровым объектом
  ### Работа с компонентами
  <blockquote>
    <p>Компонент позволяет получить данные о позиции и вращении и размере игрового объекта.</p>
    <p>Также можно у компонента получить игровой объект через ".gameObject": transform[i].gameObject.</p>
    <p>Возможно получить имя объекта через ".name": transform[i].gameObject.name</p>
  </blockquote>

  <h4>Компонент Transform:</h4>
  <pre>
    <ul>
      <li>Position: GameObject.GetComponent<Transform>().position = new Vector3(10, 20, 30);</li>
      <li>Rotation: GameObject.GetComponent<Transform>().rotation = Quaternion.Euler(0,0,0);</li>
      <li>Scale: GameObject.GetComponent<Transform>().scale = new Vector3(10, 20, 30); - не верно</li>
    </ul>
  </pre>