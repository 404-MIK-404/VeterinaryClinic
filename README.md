# Разработка баз данных для ИС «Ветеринарная клиника»

Целью курсового проекта является разработка базы данных « Сеть ветеринарных клиник «ЗвероМед» » для автоматизации работы с животными.

**Приложение было разработанно на языке C# с использованием платформы WPF**

## Задачи курсового проекта: ##

•	провести системный анализ предметной области «Сеть ветеринарных клиник «ЗвероМед»»;

•	провести обзор информационных технологий, подходящих для разработки БД;

•	изучить аналогичные информационные системы данной предметной области;

•	описать требования, предъявляемые к разработке данной базы данных;

•	разработать инфологическую модель базы данных;

•	обосновать выбор модели данных и осуществить логическое проектирование базы данных;

•	нормализовать спроектированную модель и составить схему базы данных;

•	осуществить реализацию БД на выбранной СУБД;


## Структура БД ##

База данных «Сеть зоопарков «ЗвероМед»» содержит 11 таблиц, которые были спроектированы в БД а также 3 триггера, 2 представления.

База данных содержит 11 таблиц:

•	Класс животного;

•	Вид животного;

•	Ветеринар;

•	Тип животного;

•	Карта животного;

•	Рацион;

•	Продукты;

•	ВетКлиника;

•	Тип ВетКлиники;

•	Администратор;

•	Уборщик.


## Триггеры ##

•Первый триггер под названием "salary_veterinar", данный триггер вычисляет надбавку ветеринару, которая считается таким образом,
если у ветеринара стаж работы больше или равен четырех, то к текущей зарплате прибавляется четыре тысячи. 

•Второй триггер под названием "random_vet" суть это триггера заключается в том, что при заполнений таблицы «Вид животного», 
можно не указывать ветеринара, триггер сам случайным образ выберет ветеринара из набора уже существующих.

•Третий триггер под названием "food" данный триггер работает следующим образом.
Он удваивает объем потребляемой пищи данного животного, в случай если его возраст превышает два года.

## Представление ##

•Первое представление под названием "MENU_WITH_ANIMAL" отображает тип животного его кличку, возраст, что он употребляет и в каком объеме. 

•Второе представление под названием "VET_WITH_ANIMAL" отображает животных с прикрепленными к ним ветеринарами.

