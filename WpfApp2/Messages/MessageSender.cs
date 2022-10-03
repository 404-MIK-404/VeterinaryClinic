using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    class MessageSender : Messages
    {
        public void ErrorMessage(String header, String title)
        {
            MessageBox.Show(header, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void SuccessMessage(String header, String title)
        {
            MessageBox.Show(header, title, MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
