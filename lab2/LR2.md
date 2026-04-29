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

```mermaid sequenceDiagram
    actor U as Зареєстрований користувач
    participant S as :System (Style You)
    participant AI as :AI Model (Computer Vision)
    participant DB as :Database

    U->>S: Вибирає подію та натискає "Згенерувати образи"
    S->>DB: Отримує завантажене фото та BodyProfile
    DB-->>S: photoData, bodyShape
    S->>AI: requestGenerateLooks(bodyShape, eventType)
    
    Note over AI: ШІ генерує 4-5 варіантів
    AI-->>S: List~Outfit~
    S-->>U: Відображає варіанти одягу
    
    U->>S: Натискає "Приміряти (Try-On)" на обраному луці
    S->>AI: requestVirtualTryOn(photoData, selectedOutfit)
    
    Note over AI: ШІ рендерить одяг на фото (очікування до 30с)
    AI-->>S: resultImageUrl
    
    S->>DB: saveSessionHistory(resultImageUrl)
    S-->>U: Відображає готовий результат```
