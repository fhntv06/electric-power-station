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

  
  
  

  