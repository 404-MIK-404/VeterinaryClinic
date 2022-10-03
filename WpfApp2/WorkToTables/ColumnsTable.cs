using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class ColumnsTable
    {

        private readonly List<List<string>> ColumnRus = new List<List<string>>() {
            new List<string>(){"Код Администратора","ФИО","Возраст","Зарплата","Стаж работы"},
            new List<string>(){"Код Ветеринара","ФИО","Возраст", "Зарплата","Стаж работы"},
            new List<string>(){"Код Уборщика","ФИО","Возраст","Зарплата"},
            new List<string>(){"Код ветклиники", "Код типа ветклиники", "Код карты животного", "Код администратора", "Код уборщика", "Наименование","Адрес"},//3
            new List<string>(){"Код типа ветклиники", "Наименование"},
            new List<string>(){"Код карты животного", "Код типа животного", "Кличка", "Пол", "Возраст", "Стаж пребывания" },//5
            new List<string>(){ "Код типа животного", "Код вида животного", "Наименование"},
            new List<string>(){ "Код вида животного","Код класса животного","Код ветеринара","Наименование" },
            new List<string>(){ "Код класса животного", "Наименование" },
            new List<string>(){ "Код рациона", "Код продукта", "Код карты животного", "Объем пищи"},
            new List<string>(){ "Код продукта", "Наименование" }
        };

        private readonly List<List<string>> ColumnDB = new List<List<string>>() {
            new List<string>(){ "КОД_АДМИНА", "ФИО", "ВОЗРАСТ", "ЗАРПЛАТА", "СТАЖ_РАБОТЫ"},
            new List<string>(){ "КОД_ВЕТЕРИНАРА", "ФИО", "ВОЗРАСТ", "ЗАРПЛАТА", "СТАЖ_РАБОТЫ"},
            new List<string>(){ "КОД_УБОРЩИКА", "ФИО", "ВОЗРАСТ", "ЗАРПЛАТА"},
            new List<string>(){ "КОД_ВЕТКЛИНИКИ", "КОД_ТИПА_ВЕТ", "КОД_КАРТЫ", "КОД_АДМИНА", "КОД_УБОРЩИКА", "НАИМЕНОВАНИЕ","АДРЕС"},//3
            new List<string>(){ "КОД_ТИПА_ВЕТ", "НАИМЕНОВАНИЕ"},
            new List<string>(){ "КОД_КАРТЫ", "КОД_ТИПА", "КЛИЧКА", "ПОЛ", "ВОЗРАСТ", "СТАЖ_ПРЕБЫВАНИЯ" },//5
            new List<string>(){ "КОД_ТИПА", "КОД_ВИДА", "НАИМЕНОВАНИЕ"},
            new List<string>(){ "КОД_ВИДА", "КОД_КЛАССА", "КОД_ВЕТЕРИНАРА", "НАИМЕНОВАНИЕ" },
            new List<string>(){ "КОД_КЛАССА", "НАИМЕНОВАНИЕ" },
            new List<string>(){ "КОД_РАЦИОНА", "КОД_ПРОДУКТА", "КОД_КАРТЫ", "ОБЪЁМ_ПИЩИ"},
            new List<string>(){ "КОД_ПРОДУКТА", "НАИМЕНОВАНИЕ" }
        };


        private readonly List<List<string>> ViewColumn = new List<List<string>>(){
        new List<string>(){"Код карты","Тип животного","Вид животного","Класс животного","Кличка","Пол","Возраст","Стаж пребывания","ФИО Ветеринара"},
        new List<string>(){"Имя","Кличка","Продукт","Объём пищи","Возраст"} };

        private readonly List<string> NameTables = new List<string>() { "АДМИНИСТРАТОР", "ВЕТЕРИНАР" , "УБОРЩИК" , "ВЕТКЛИНИКА" , "ТИП_ВЕТКЛИНИКИ" , "КАРТА_ЖИВОТНОГО" , "ТИП_ЖИВОТНОГО" , "ВИД_ЖИВОТНОГО" , "КЛАСС_ЖИВОТНОГО", "РАЦИОН", "ПРОДУКТЫ" };


        public List<List<string>> getColumnRus()
        {
            return ColumnRus;
        }

        public List<List<string>> getColumnDB()
        {
            return ColumnDB;
        }

        public List<List<string>> getViewColumn()
        {
            return ViewColumn;
        }

        public List<string> getNameTables()
        {
            return NameTables;
        }



    }
}
