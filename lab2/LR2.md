### Крок 3. Діаграма прецедентів (Use Case Diagram)

![Діаграма прецедентів](usecasediagram.png)

**Код PlantUML:**
```text
@startuml
left to right direction
actor "Незареєстрований\nкористувач" as Guest
actor "Зареєстрований\nкористувач" as User
actor "Адміністратор" as Admin

rectangle "Веб-додаток Style You" {
  usecase "Реєстрація/Авторизація" as UC01
  usecase "Завантаження фото" as UC02
  usecase "Аналіз типу фігури" as UC03
  usecase "Генерація образів (4-5 шт)" as UC04
  usecase "Віртуальна примірка (Try-On)" as UC05
  usecase "Збереження в історію" as UC06
  usecase "Управління користувачами" as UC07
}

Guest --> UC01
User --> UC02
User --> UC04
User --> UC05
User --> UC06
Admin --> UC07

UC02 ..> UC03 : <<include>>
UC04 ..> UC03 : <<extend>>
UC05 ..> UC01 : <<include>>
@enduml

