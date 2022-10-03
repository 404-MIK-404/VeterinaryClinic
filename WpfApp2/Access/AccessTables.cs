using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2
{
    class AccessTables
    {

        private String sqlAddNow;
        private String sqlDelNow;
        private String sqlUpdateNow;
        private String sqlSelectNow;

        private MessageSender msSender = new MessageSender();

        private ColumnsTable columnsTable = new ColumnsTable();

        public String getSqlAddNow()
        {
            return this.sqlAddNow;
        }

        public String getSqlDelNow()
        {
            return this.sqlDelNow;
        }

        public String getSqlUpdateNow()
        {
            return this.sqlUpdateNow;
        }

        public String getSelectNow()
        {
            return this.sqlSelectNow;
        }

        private void setAllSqlQuery(String sqlAddNow, String sqlDelNow, String sqlUpdateNow, String sqlSelectNow, DataGrid TableDB)
        {
            TableDB.CanUserAddRows = true;
            this.sqlAddNow = sqlAddNow;
            this.sqlDelNow = sqlDelNow;
            this.sqlUpdateNow = sqlUpdateNow;
            this.sqlSelectNow = sqlSelectNow;
        }

        public void setSqlAdmin(int selectTable, DataGrid TableDB)
        {
            switch (selectTable)
            {
                case 0:
                    setAllSqlQuery("INSERT INTO АДМИНИСТРАТОР (КОД_АДМИНА, ФИО, ВОЗРАСТ, ЗАРПЛАТА, СТАЖ_РАБОТЫ) VALUES (?, ?, ?, ?, ?)",
                       "DELETE FROM АДМИНИСТРАТОР WHERE КОД_АДМИНА=?", 
                       "UPDATE АДМИНИСТРАТОР SET  ФИО=?, ВОЗРАСТ=?, ЗАРПЛАТА=?, СТАЖ_РАБОТЫ=? WHERE КОД_АДМИНА=? ", "SELECT * FROM АДМИНИСТРАТОР",TableDB);
                    break;


                case 1:
                    setAllSqlQuery("INSERT INTO ВЕТЕРИНАР (КОД_ВЕТЕРИНАРА,ФИО,ВОЗРАСТ,ЗАРПЛАТА,СТАЖ_РАБОТЫ) VALUES (?,?,?,?,?)", 
                        "DELETE FROM ВЕТЕРИНАР WHERE КОД_ВЕТЕРИНАРА=?", 
                        "UPDATE ВЕТЕРИНАР SET ФИО=?,ВОЗРАСТ=?,ЗАРПЛАТА=?,СТАЖ_РАБОТЫ=? WHERE КОД_ВЕТЕРИНАРА=?", "SELECT * FROM ВЕТЕРИНАР", TableDB);
                    break;

                case 2:
                    setAllSqlQuery("INSERT INTO УБОРЩИК (КОД_УБОРЩИКА,ФИО,ВОЗРАСТ,ЗАРПЛАТА) VALUES (?,?,?,?)", 
                        "DELETE FROM УБОРЩИК WHERE КОД_УБОРЩИКА=?",
                        "UPDATE УБОРЩИК SET ФИО=?,ВОЗРАСТ=?,ЗАРПЛАТА=? WHERE КОД_УБОРЩИКА=?", "SELECT * FROM УБОРЩИК", TableDB);
                    break;


                case 3:
                    setAllSqlQuery("","","", "SELECT * FROM ВЕТКЛИНИКА", TableDB);
                    break;

                case 4:
                    setAllSqlQuery("","","", "SELECT * FROM ТИП_ВЕТКЛИНИКИ", TableDB);
                    break;

                case 5:
                    setAllSqlQuery("INSERT INTO КАРТА_ЖИВОТНОГО (КОД_КАРТЫ,КОД_ТИПА,КЛИЧКА,ПОЛ,ВОЗРАСТ,СТАЖ_ПРЕБЫВАНИЯ) VALUES (?,?,?,?,?,?)"
                        , "DELETE FROM КАРТА_ЖИВОТНОГО WHERE КОД_КАРТЫ=?",
                       "UPDATE КАРТА_ЖИВОТНОГО SET КОД_ТИПА=?,КЛИЧКА=?,ПОЛ=?,ВОЗРАСТ=?,СТАЖ_ПРЕБЫВАНИЯ=? WHERE КОД_КАРТЫ=? ", "SELECT * FROM КАРТА_ЖИВОТНОГО", TableDB);
                    break;

                case 6:
                    setAllSqlQuery("INSERT INTO ТИП_ЖИВОТНОГО (КОД_ТИПА,КОД_ВИДА,НАИМЕНОВАНИЕ) VALUES (?,?,?)",
                        "DELETE FROM ТИП_ЖИВОТНОГО WHERE КОД_ТИПА=?",
                        "UPDATE ТИП_ЖИВОТНОГО SET КОД_ВИДА=?,НАИМЕНОВАНИЕ=? WHERE КОД_ТИПА=?", "SELECT * FROM ТИП_ЖИВОТНОГО", TableDB);
                    break;

                case 7:
                    setAllSqlQuery("INSERT INTO ВИД_ЖИВОТНОГО (КОД_ВИДА,КОД_КЛАССА,КОД_ВЕТЕРИНАРА,НАИМЕНОВАНИЕ) VALUES (?,?,?,?)",
                        "DELETE FROM ВИД_ЖИВОТНОГО WHERE КОД_ВИДА=?",
                        "UPDATE ВИД_ЖИВОТНОГО SET КОД_КЛАССА=?,КОД_ВЕТЕРИНАРА=?,НАИМЕНОВАНИЕ=? WHERE КОД_ВИДА=?",
                        "SELECT * FROM ВИД_ЖИВОТНОГО", TableDB);
                    break;

                case 8:
                    setAllSqlQuery("INSERT INTO КЛАСС_ЖИВОТНОГО (КОД_КЛАССА,НАИМЕНОВАНИЕ) VALUES (?,?)",
                        "DELETE FROM КЛАСС_ЖИВОТНОГО WHERE КОД_КЛАССА=?",
                        "UPDATE КЛАСС_ЖИВОТНОГО SET НАИМЕНОВАНИЕ=? WHERE КОД_КЛАССА=?", "SELECT * FROM КЛАСС_ЖИВОТНОГО", TableDB);
                    break;

                case 9:
                    setAllSqlQuery("INSERT INTO РАЦИОН (КОД_РАЦИОНА, КОД_ПРОДУКТА,КОД_КАРТЫ,ОБЪЁМ_ПИЩИ) VALUES (?,?,?,?)",
                        "DELETE FROM РАЦИОН WHERE КОД_РАЦИОНА=?",
                        "UPDATE РАЦИОН SET КОД_ПРОДУКТА=?,КОД_КАРТЫ=?,ОБЪЁМ_ПИЩИ=? WHERE КОД_РАЦИОНА=?", "SELECT * FROM РАЦИОН", TableDB);
                    break;

                case 10:
                    setAllSqlQuery("INSERT INTO ПРОДУКТЫ (КОД_ПРОДУКТА,НАИМЕНОВАНИЕ) VALUES (?,?)"
                        , "DELETE FROM ПРОДУКТЫ WHERE КОД_ПРОДУКТА=?", 
                        "UPDATE ПРОДУКТЫ SET НАИМЕНОВАНИЕ=? WHERE КОД_ПРОДУКТА=?", "SELECT * FROM ПРОДУКТЫ", TableDB);
                    break;

            }
        }

        public void setSqlVeterinar(int selectTable,DataGrid TableDB)
        {
            switch (selectTable)
            {
                case 5:
                    setAllSqlQuery("INSERT INTO КАРТА_ЖИВОТНОГО (КОД_КАРТЫ,КОД_ТИПА,КЛИЧКА,ПОЛ,ВОЗРАСТ,СТАЖ_ПРЕБЫВАНИЯ) VALUES (?,?,?,?,?,?)",
                        "DELETE FROM КАРТА_ЖИВОТНОГО WHERE КОД_КАРТЫ=?",
                        "UPDATE КАРТА_ЖИВОТНОГО SET КОД_ТИПА=?,КЛИЧКА=?,ПОЛ=?,ВОЗРАСТ=?,СТАЖ_ПРЕБЫВАНИЯ=? WHERE КОД_КАРТЫ=? ", "SELECT * FROM КАРТА_ЖИВОТНОГО", TableDB);
                    break;


                case 6:
                    setAllSqlQuery("INSERT INTO ТИП_ЖИВОТНОГО (КОД_ТИПА,КОД_ВИДА,НАИМЕНОВАНИЕ) VALUES (?,?,?)",
                                   "DELETE FROM ТИП_ЖИВОТНОГО WHERE КОД_ТИПА=?",
                                   "UPDATE ТИП_ЖИВОТНОГО SET КОД_ВИДА=?,НАИМЕНОВАНИЕ=? WHERE КОД_ТИПА=?", "SELECT * FROM ТИП_ЖИВОТНОГО", TableDB);
                    break;

                case 7:
                    setAllSqlQuery("INSERT INTO ВИД_ЖИВОТНОГО (КОД_ВИДА,КОД_КЛАССА,КОД_ВЕТЕРИНАРА,НАИМЕНОВАНИЕ) VALUES (?,?,?,?)",
                                    "DELETE FROM ВИД_ЖИВОТНОГО WHERE КОД_ВИДА=?",
                                   "UPDATE ВИД_ЖИВОТНОГО SET КОД_КЛАССА=?,КОД_ВЕТЕРИНАРА=?,НАИМЕНОВАНИЕ=? WHERE КОД_ВИДА=?", "SELECT * FROM ВИД_ЖИВОТНОГО", TableDB);
                    break;

                case 8:
                    setAllSqlQuery("INSERT INTO КЛАСС_ЖИВОТНОГО (КОД_КЛАССА,НАИМЕНОВАНИЕ) VALUES (?,?)",
                        "DELETE FROM КЛАСС_ЖИВОТНОГО WHERE КОД_КЛАССА=?", 
                        "UPDATE КЛАСС_ЖИВОТНОГО SET НАИМЕНОВАНИЕ=? WHERE КОД_КЛАССА=?", "SELECT * FROM КЛАСС_ЖИВОТНОГО", TableDB);
                    break;

                case 9:
                    setAllSqlQuery("INSERT INTO РАЦИОН (КОД_РАЦИОНА, КОД_ПРОДУКТА,КОД_КАРТЫ,ОБЪЁМ_ПИЩИ) VALUES (?,?,?,?)",
                        "DELETE FROM РАЦИОН WHERE КОД_РАЦИОНА=?",
                        "UPDATE РАЦИОН SET КОД_ПРОДУКТА=?,КОД_КАРТЫ=?,ОБЪЁМ_ПИЩИ=? WHERE КОД_РАЦИОНА=?", "SELECT * FROM РАЦИОН", TableDB);
                    break;

                case 10:
                    setAllSqlQuery("INSERT INTO ПРОДУКТЫ (КОД_ПРОДУКТА,НАИМЕНОВАНИЕ) VALUES (?,?)",
                        "DELETE FROM ПРОДУКТЫ WHERE КОД_ПРОДУКТА=?", 
                        "UPDATE ПРОДУКТЫ SET НАИМЕНОВАНИЕ=? WHERE КОД_ПРОДУКТА=?", "SELECT * FROM ПРОДУКТЫ", TableDB);
                    break;

                default:
                    msSender.ErrorMessage("", "");
                    break;

            }
        }

        public void QueryTableAvail(string SQLQuery, DataGrid Table, int i, String NameTable,
            OleDbCommand SQLcommand, OleDbConnection OracleConnection, OleDbDataAdapter SQLadapter,List<List<string>> array)
        {
            DataTable DataTab = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection.Open();
                SQLcommand = new OleDbCommand(sqlSelectNow, OracleConnection);
                SQLadapter = new OleDbDataAdapter(SQLcommand);
                Table.CanUserAddRows = true;
                SQLadapter.Fill(DataTab);
                SQLadapter.Fill(dataSet, NameTable);

                for (int j = 0; j < array[i].Count; j++)
                {
                    dataSet.Tables[NameTable].Columns[j].ColumnName = array[i][j];
                }

                Table.ItemsSource = dataSet.Tables[NameTable].DefaultView;
            }
            catch (Exception)
            {
                msSender.ErrorMessage("Невозможно отобразить данную таблицу, пожалуйста обратитесь в тех. службу", "Системная ошибка");
            }
            finally
            {
                OracleConnection.Close();
                DataTab.Clear();
                SQLcommand = null;
                SQLadapter = null;
            }
        }



    }
}
