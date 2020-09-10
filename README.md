# Plando

**Plando** - система для управления франчайзинговой сетью прачечных.

## Техническое задание на разработку программного обеспечения баз данных

### 1. Термины, используемые в техническом задании

**Программное обеспечение** (ПО, программа для ЭВМ, приложение) – это объективная форма представления совокупности данных и команд, предназначенных для функционирования электронных вычислительных машин (ЭВМ) и других компьютерных устройств с целью получения определенного результата. Под программой для ЭВМ подразумеваются также подготовительные материалы, полученные в ходе ее разработки, и порождаемые ею аудиовизуальные отображения.

**База данных** – представленная в объективной форме совокупность самостоятельных материалов, систематизированных таким образом, чтобы эти материалы могли быть найдены и обработаны с помощью электронной вычислительной машины (ЭВМ).

**Сервер** – компьютер (или специальное компьютерное оборудование), выделенный и/или специализированный для выполнения определенных сервисных функций.

**Пользователь** – человек, работающий с ПО.

**Администратор** – пользователь, обладающий максимальными правами по работе с ПО, в частности по настройке ПО.

**Система управления базами данных (СУБД)** – совокупность программных и лингвистических средств общего или специального назначения, обеспечивающих управление созданием и использованием баз данных.

**Рабочая станция** – стационарный компьютер в составе локальной вычислительной сети (ЛВС), на котором решаются прикладные задачи.

**Спецификация ПО** – документ, содержащий полное и точное описание функций и ограничений разрабатываемого программного обеспечения, а также требования, предъявляемые к техническим средствам, надежности, информационной безопасности и т.д.

**Руководство разработчика** – документ, содержащий информацию, необходимую для дальнейшего развития функциональности разрабатываемого программного обеспечения. Может содержать описание скриптов, динамических библиотек и программных модулей, классов, функций, параметров, структур, констант, а также примеры их использования; сведения по настройке программы.

**Руководство администратора** – документ, в котором содержаться инструкции по установке и настройке приложения.

**Руководство пользователя** – документ, в котором содержатся инструкции для пользователей по работе с приложением.

### 2. Введение

2.1. Наименование программы: система управления сетью прачечных Plando.

2.2. Назначение и область применения: программа предназначена для использования в сети прачечных.

### 3. Основания для разработки

3.1. Документ (документы), на основании которых ведется разработка:
Договор на создание программного обеспечения № Договора от Дата г.

3.2. Наименование и (или) условное обозначение темы разработки: веб-сервис для обеспечения работы сети прачечных.

### 4. Назначение и цели создания системы

4.1. Назначение разработки: создание инструмента для управления сетью прачечных.

4.2. Цели создания: автоматизация управления, сбор и анализ цифрового следа отдельных прачечных и клиентов.

### 5. Требования к надежности

5.1. Требования к обеспечению надежного функционирования:

Надежное (устойчивое) функционирование программы должно быть обеспечено выполнением «Заказчиком» совокупности организационно-технических мероприятий, перечень которых приведен ниже:

- организацией бесперебойного питания технических средств;
- использованием лицензионного программного обеспечения;
- регулярным выполнением рекомендаций Министерства труда и социального развития РФ, изложенных в Постановлении от 23 июля 1998 г. "Об утверждении межотраслевых типовых норм времени на работы по сервисному обслуживанию ПЭВМ и оргтехники и сопровождению программных средств";
- регулярным выполнением требований ГОСТ 51188-98. Защита информации. Испытания программных средств на наличие компьютерных вирусов.

5.2. Время восстановления после отказа:

Время восстановления после отказа, вызванного сбоем электропитания технических средств (иными внешними факторами), не фатальным сбоем (не крахом) операционной системы, не должно превышать 30-ти минут при условии соблюдения условий эксплуатации технических и программных средств. Время восстановления после отказа, вызванного неисправностью технических средств, фатальным сбоем (крахом) операционной системы, не должно превышать времени, требуемого на устранение неисправностей технических средств и переустановки программных средств.

5.3. Отказы из-за некорректных действий пользователей системы:

Отказы программы возможны вследствие некорректных действий оператора (пользователя) при взаимодействии с операционной системой. Во избежание возникновения отказов программы по указанной выше причине следует обеспечить работу конечного пользователя без предоставления ему административных привилегий.

### 6. Условия эксплуатации

6.1. Требования к квалификации и численности персонала:

Системный администратор, отслеживающий состояние работы сервера, на котором развернуто решение. Системный администратор должен иметь высшее профильное образование и сертификаты компании-производителя операционной системы.
Главный администратор системы, управляющей сетью, должен обладать практическими навыками работы с графическим пользовательским интерфейсом операционной системы.

Администратор прачечной должен обладать практическими навыками работы с графическим пользовательским интерфейсом операционной системы.
Пользователь программы (оператор) должен обладать практическими навыками работы с графическим пользовательским интерфейсом операционной системы.

### 7. Требования к защите информации и программ

7.1. Требования к защите информации от несанкционированного доступа:

Информация должна быть защищена от несанкционированного доступа посредством протокола защиты OAuth2.0.

7.2. Требования к сохранности информации:

При отказе технических средств(в том числе - потеря питания) обеспечена сохранность информации в системе.

### 8. Требования к программной документации

8.1. Предварительный состав программной документации. Состав программной документации должен включать в себя:

1. техническое задание;
2. руководство системного администратора по развертке и отладке аварийных ситуаций;
3. руководство администратора прачечной;
4. ER-диаграмма базы данных;
5. Схематичное представление доменной модели.

### 9. Технико-экономические показатели

9.1. Экономические преимущества разработки:

Основное преимущество разработки заключается в предоставлении конечному потребителю возможности отслеживания состояния заказа и инструментов анализа деятельности точек обслуживание для владельца компании

### 10. Стадии и этапы разработки

10.1.Стадии разработки:

Разработка должна быть проведена в три стадии:

1. разработка технического задания;
2. рабочее проектирование;
3. внедрение.

10.2.Этапы разработки:

На стадии разработки технического задания должен быть выполнен этап разработки, согласования и утверждения настоящего технического задания.

На стадии рабочего проектирования должны быть выполнены перечисленные ниже этапы работ:

- разработка программы;
- разработка программной документации;
- испытания программы.

На стадии внедрения должен быть выполнен этап подготовка и передача программы.

10.3. Содержание работ по этапам:

На этапе разработки технического задания должны быть выполнены перечисленные ниже работы:

1. постановка задачи;
2. определение и уточнение требований к техническим средствам;
3. определение требований к программе;
4. определение стадий, этапов и сроков разработки программы и документации на неё;
5. согласование и утверждение технического задания.

На этапе разработки программы должна быть выполнена работа по программированию (кодированию) и отладке программы.

На этапе разработки программной документации должна быть выполнена разработка программных документов в соответствии с требованиями к составу документации.

На этапе испытаний программы должны быть выполнены перечисленные ниже виды работ:

1. разработка, согласование и утверждение и методики испытаний;
2. проведение приемо-сдаточных испытаний;
3. корректировка программы и программной документации по результатам испытаний.
На этапе подготовки и передачи программы должна быть выполнена работа по подготовке и передаче программы и программной документации в эксплуатацию на объектах "Заказчика".

### 11. Порядок контроля и приемки

11.1. Виды испытаний:

Приемо-сдаточные испытания должны проводиться на объекте "Заказчика" в оговоренные сроки. Приемо-сдаточные испытания программы должны проводиться согласно разработанной "Исполнителем" и согласованной "Заказчиком" Программы и методик испытаний. Ход проведения приемо-сдаточных испытаний "Заказчик" и "Исполнитель" документируют в Протоколе проведения испытаний.

11.2. Общие требования к приемке работы:

На основании Протокола проведения испытаний "Исполнитель" совместно с "Заказчиком" подписывает Акт приемки-сдачи программы в эксплуатацию.

### 12. Разработка проекта системы базы данных

12.1. Требования к составу данных:

Система должна хранить данные о:

1. прачечных,
2. пользователях,
3. заказах.

Это ключевые сущности домена, которые должны формироваться как агрегаты из набора событий, которые и будут храниться в системе (например: "Событие  регистрации новой прачечной" и т.д.). Эти данные в дальнейшем буду формировать различные представления для дальнейшего анализа.

12.2. Требования к представлению информации:

Доступ к информации осуществляется для пользователей с ролями посредством веб-клиента или напрямую для системного администратора через СУБД. Данные в БД из событийной модели формируются в конечные объекты (статистические или доменные).

12.3. Требования по применению СУБД :

Использование русского языка, как на уровне пользовательского интерфейса, так и на уровне серверного ядра. Поддержка реляционной модели базы данных. Поддержка технологии клиент-сервер.

### 13. Заполнение базы данных информацией

13.1. Требования к заполнению базы данных:

Для демонстрации работоспособности системы база данных заполнена тестовыми данными, однако заполнение демонстрационными данными необязательно, т.к. система может быть вручную заполнена с нуля посредством веб-клиента или в процессе демонстрации.

13.2. Требования к источникам информации:

Информацию предоставляют администраторы и клиенты сервиса. На основе различных ролей (клиент, оператор прачечной, администратор) пользователи могут помещать и извлекать из системы различные данные. Например, клиенты могут помещать в систему свои комментарии к исполнению заказов и оценки, операторы - заказы, администраторы - информацию о новых прачечных и т.д.

### 14. Разработка технической документации

14.1. Разработка Описания базы данных. Общее описание программных и лингвистических средств. Соответствие требованиям ГОСТ 7.70-96, ГОСТ 19.506-79.

14.2. Разработка Описания базы данных. Сведения о структуре таблиц базы данных. Соответствие требованиям ГОСТ 7.70-96

### 15. Разработка пользовательской документации

15.1. Разработка Описания применения. Соответствие требованиям ГОСТ 19.502-78.

15.2. Разработка Руководства администратора. Соответствие требованиям РД 50-34.698-90.

15.3. Разработка Руководства пользователя. Соответствие требованиям ГОСТ 34.201-89, РД 50-34.698-90.

### 16. Установка созданной базы данных на сервер и рабочие станции Заказчика

16.1. Указать требования по установке созданной базы данных на сервер и рабочие станции

### 17. Учебно-консультационные услуги

17.1 .Обучение администратора.

Обучение администраторов системы осуществляется посредством предоставления текстовых инструкций.

17.2. Обучение пользователей.

Интуитивно понятный интерфейс взаимодействия с различными встроенным подсказками в веб-клиенте.

17.3. Консультационно-методическая поддержка процессов разработки и внедрения.

Исполнитель обязывается предоставить консультативно-методическую поддержку в развертке решения и отладке аварийных ситуаций.