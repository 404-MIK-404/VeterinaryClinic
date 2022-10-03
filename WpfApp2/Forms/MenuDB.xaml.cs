using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MenuDB.xaml
    /// </summary>
    public partial class MenuDB : Window
    {

        OledbDB Oracle = OledbDB.CreateOracleDB();

        private DataRowView dr;



        private String accessDB;

        private ListBoxItem currentItem;

        private ColumnsTable columnsTable = new ColumnsTable();

        private AccessTables Tables = new AccessTables();

        private MessageSender msSender = new MessageSender();



        public MenuDB()
        {
            InitializeComponent();
        }

    
 
        private void AvailTableCall()
        {
            switch (User.getCurrentUser().getAccessUser()) {
                case "Админ":
                    Tables.setSqlAdmin(TableChange.SelectedIndex, TableDB);
                    Tables.QueryTableAvail(Tables.getSelectNow(),TableDB, TableChange.SelectedIndex, columnsTable.getNameTables()[TableChange.SelectedIndex],
                        Oracle.getSQLcommand(),Oracle.getOracleConnection(),Oracle.getSqlAdapter(), columnsTable.getColumnRus());
                    break;


                case "Ветеринар":
                    Tables.setSqlVeterinar(TableChange.SelectedIndex, TableDB);
                    Tables.QueryTableAvail(Tables.getSelectNow(), TableDB, TableChange.SelectedIndex, columnsTable.getNameTables()[TableChange.SelectedIndex],
                        Oracle.getSQLcommand(), Oracle.getOracleConnection(), Oracle.getSqlAdapter(), columnsTable.getColumnRus());
                    break;

            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            accessDB = User.getCurrentUser().getAccessUser();
            currentItem = ((ListBoxItem)TableChange.SelectedItem);
            AvailTableCall();
            
        }



        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowSelected = TableDB.SelectedItem as DataRowView;
            
            if (Oracle.CheckEmptyValue(dr, rowSelected.Row.ItemArray.Length))
            {
                List<string> data = new List<string>();
                for (int i = 0; i < rowSelected.Row.ItemArray.Length; i++)
                {
                    data.Add(rowSelected.Row.ItemArray[i].ToString());
                }
                Oracle.PrepareSqlAction(Tables.getSqlAddNow(), "Insert", data);
                AvailTableCall();
            }
            else
            {
                msSender.ErrorMessage("Добавить данные, которые были введены нельзя", "Добавление данных");
                AvailTableCall();
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowSelected = TableDB.SelectedItem as DataRowView;
            if (Oracle.CheckEmptyValue(dr, rowSelected.Row.ItemArray.Length))
            {
                List<string> data = new List<string>();
                for (int i = 0; i < rowSelected.Row.ItemArray.Length;i++)
                {
                    data.Add(rowSelected.Row.ItemArray[i].ToString());
                }
                Oracle.PrepareSqlAction(Tables.getSqlUpdateNow(), "Update", data);
                AvailTableCall();
            }
            else
            {
                msSender.ErrorMessage("Обновить данные, которые были выбраны нельзя", "Обновление данных");
                AvailTableCall();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView rowSelected = TableDB.SelectedItem as DataRowView;
            if (Oracle.CheckEmptyValue(dr, rowSelected.Row.ItemArray.Length))
            {
                List<string> data = new List<string>();
                for (int i = 0; i < rowSelected.Row.ItemArray.Length; i++)
                {
                    data.Add(rowSelected.Row.ItemArray[i].ToString());
                }
                Oracle.PrepareSqlAction(Tables.getSqlDelNow(), "Delete", data);
                AvailTableCall();
            }
            else
            {
                msSender.ErrorMessage("Удалить данные, которые были выбраны нельзя", "Удаление данных");
                AvailTableCall();
            }
        }

        private void TableDB_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            dr = dg.SelectedItem as DataRowView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View view = new View();
            this.Close();
            view.Show();
        }

        private void ExitApp_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите закрыть данное приложение ?", "Закрытие программы", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }

}
