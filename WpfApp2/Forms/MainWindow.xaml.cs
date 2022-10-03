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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static OledbDB Oracle = OledbDB.CreateOracleDB();

        private static MessageSender msSender = new MessageSender();


        public MainWindow()
        {
            InitializeComponent();
        }

        private bool CheckEmptyText(String text)
        {
            if(String.IsNullOrEmpty(text))
            {
                return false;
            }
            return true;
        }

        private bool CheckPassword(String TextPass,String TextPassReap)
        {
            return TextPass == TextPassReap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckEmptyText(LoginText.Text) && CheckEmptyText(PasswordText.Password) 
                && CheckEmptyText(RepeatPasswordText.Password) 
                && CheckPassword(PasswordText.Password,RepeatPasswordText.Password))
            {
                String result = Oracle.SQLAccesLog(LoginText.Text, PasswordText.Password);
                if (!"no".Equals(result))
                {
                    User.createUser(LoginText.Text, PasswordText.Password, result);
                    MenuDB menu = new MenuDB();
                    this.Close();
                    menu.Show();
                }
                else
                {
                    msSender.ErrorMessage("Неудачная попытка входа в аккаунт", "Запрос для входа был выполнен неправильно");
                }
            }
            else
            {
                msSender.ErrorMessage("Пароли не совпадают или ввод логина неверный", "Ввод данных");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы хотите закрыть данное приложение ?", "Закрытие программы", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
