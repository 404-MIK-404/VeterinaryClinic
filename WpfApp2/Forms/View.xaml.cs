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

namespace WpfApp2
{


    public partial class View : Window
    {

        private static OledbDB Oracle = OledbDB.CreateOracleDB();

        public View()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MenuDB menu = new MenuDB();
            this.Close();
            menu.Show();
        }

        private void SelectView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (SelectView.SelectedIndex)
            {
                case 0:
                    Oracle.QueryView("SELECT * FROM VET_WITH_ANIMAL", ViewDB, "VET_WITH_ANIMAL", SelectView.SelectedIndex);
                    break;

                case 1:
                    Oracle.QueryView("SELECT * FROM MENU_WITH_ANIMAL", ViewDB, "MENU_WITH_ANIMAL", SelectView.SelectedIndex);
                    break;

            }
        }
    }
}
