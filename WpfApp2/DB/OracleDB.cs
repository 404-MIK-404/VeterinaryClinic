using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using Oracle.ManagedDataAccess;

namespace WpfApp2
{
    class OledbDB
    {

        private static OleDbConnection OracleConnection = new OleDbConnection("Provider=MSDAORA;Data Source=XE;Persist Security Info=True;User ID=LAVRENTIV;Password=KOLOBOK;Unicode=True");

        private static OleDbDataAdapter SQLadapter;

        private static OledbDB oracleDB;

        private static OleDbCommand SQLcommand;

        private static MessageSender mgSender = new MessageSender();

        private static ColumnsTable tableColumns = new ColumnsTable();

        private SQL_Querys querys = new SQL_Querys();

        private OledbDB()
        {}


        public static OledbDB CreateOracleDB()
        {
            if (oracleDB == null)
            {
                oracleDB = new OledbDB();
            }
            return oracleDB;
        }


        public String SQLAccesLog(String loginUser,String passwordUser)
        {
            return querys.QueryLogPassword(loginUser,passwordUser);
        }

        public OleDbDataAdapter getSqlAdapter()
        {
            return SQLadapter;
        }

        public OleDbConnection getOracleConnection()
        {
            return OracleConnection;
        }

        public OleDbCommand getSQLcommand()
        {
            return SQLcommand;
        }


        private static bool isInt(string text)
        {
            int test;
            return int.TryParse(text, out test);
        }


        public bool CheckEmptyValue(DataRowView dr,int i)
        {
            return true;
        }

    
        public void QueryView(string SQL,DataGrid Table,string NameView, int i )
        {
            DataTable DataTab = new DataTable();
            DataSet dataSet = new DataSet();
            try
            {
                OracleConnection.Open();
                SQLcommand = new OleDbCommand(SQL, OracleConnection);
                SQLadapter = new OleDbDataAdapter(SQLcommand);
                Table.CanUserAddRows = true;
                SQLadapter.Fill(DataTab);
                SQLadapter.Fill(dataSet, NameView);

                for (int j = 0; j < tableColumns.getViewColumn()[i].Count; j++)
                {
                    dataSet.Tables[NameView].Columns[j].ColumnName = tableColumns.getViewColumn()[i][j];
                }

                Table.ItemsSource = dataSet.Tables[NameView].DefaultView;
            }
            catch (Exception ex)
            {
                mgSender.ErrorMessage("Невозможно отобразить данное представление, пожалуйста обратитесь в тех. службу", "Системная ошибка");
            }
            finally
            {
                OracleConnection.Close();
                DataTab.Clear();
                SQLcommand = null;
                SQLadapter = null;
            }
        }

        public void PrepareSqlAction(string QueryNow, string TypeSQL, List<string> data)
        {
            querys.QueryAction(QueryNow, TypeSQL, data);
        }


        class SQL_Querys {


            public String QueryLogPassword(String loginUser, String passwordUser)
            {
                DataSet ds = new DataSet();
                try
                {
                    OracleConnection.Open();
                    SQLadapter = new OleDbDataAdapter("SELECT * FROM DATABASE_ACCESS WHERE LOGIN ='" + loginUser + "' AND PASSWORD='" + passwordUser + "'", OracleConnection);
                    SQLadapter.Fill(ds);
                    foreach (DataTable dt in ds.Tables)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            if (row["PASSWORD"].ToString().Equals(passwordUser) && row["LOGIN"].ToString().Equals(loginUser))
                            {
                                return row["ACCESSDB"].ToString();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    mgSender.ErrorMessage("Невозможно найти данные об этом пользователе, пожалуйста обратитесь в тех. службу", "Системная ошибка");
                }
                finally
                {
                    SQLadapter = null;
                    OracleConnection.Close();
                }
                return "no";
            }


            public void AddData(int countBegin,int countEnd,List<string> data)
            {
                for (int j = countBegin; j < countEnd; j++)
                {
                    if (isInt(data[j]))
                    {
                        SQLcommand.Parameters.Add("?", OleDbType.Integer).Value = Convert.ToInt32(data[j]);
                    }
                    else if (String.IsNullOrEmpty(data[j]))
                    {
                        SQLcommand.Parameters.Add("?", OleDbType.Integer).Value = DBNull.Value;
                    }
                    else
                    {
                        SQLcommand.Parameters.Add("?", OleDbType.VarChar).Value = data[j].ToString();
                    }
                }
            }

            public void EnterRow(string Access,List<string> data)
            {

                switch (Access)
                {
                    case "Insert":
                        AddData(0,data.Count,data);
                        break;

                    case "Delete":
                        AddData(0,1,data);
                        break;

                    case "Update":
                        AddData(1,data.Count,data);
                        AddData(0,1,data);
                        break;
                }
            }


            public void QueryAction(string Query, string SQL, List<string> data)
            {
                try
                {
                    OracleConnection.Open();
                    SQLcommand = new OleDbCommand(Query, OracleConnection);
                    SQLadapter = new OleDbDataAdapter();
                    switch (SQL)
                    {
                        case "Insert":
                           EnterRow("Insert", data);
                           SQLadapter.InsertCommand = SQLcommand;
                           SQLadapter.InsertCommand.ExecuteNonQuery();
                           mgSender.SuccessMessage("Данные были добавлены в таблицу", "Работа с данными");
                           break;

                        case "Delete":
                           EnterRow("Delete", data);
                           SQLadapter.DeleteCommand = SQLcommand;
                           SQLadapter.DeleteCommand.ExecuteNonQuery();
                           mgSender.SuccessMessage("Данные были удалены из таблицы", "Работа с данными");
                           break;

                        case "Update":
                           EnterRow("Update", data);
                           SQLadapter.UpdateCommand = SQLcommand;
                           SQLadapter.UpdateCommand.ExecuteNonQuery();
                           mgSender.SuccessMessage("Данные были обновлены в таблице", "Работа с данными");
                           break;


                    }
            
                }
                catch (Exception ex)
                {
                    mgSender.ErrorMessage("Невозможно обновить, удалить или добавить запись, возможно данные не введены или была выбрана не та запись \n Код ошибки: " + ex, "Ошибка при работе с данными");
                }
                finally
                {
                    OracleConnection.Close();
                    SQLadapter = null;
                }
            }


        }












    }
}
