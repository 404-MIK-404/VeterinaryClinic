using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    interface Messages
    {

        void ErrorMessage(String header,String title);

        void SuccessMessage(String header,String title);

    }
}
