using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class User
    {
        private String login;
        private String password;
        private String access;

        private static User currentUser;

        private User(String login,String password,String access)
        {
            this.login = login;
            this.password = password;
            this.access = access;
        }


        public static User createUser(String login, String password, String access)
        {
            if (currentUser == null)
            {
                currentUser = new User(login, password, access);
            }
            return currentUser;
        }

        public static User getCurrentUser()
        {
            return currentUser;
        }

        public String getAccessUser()
        {
            return this.access;
        }


        public String getLoginUser()
        {
            return this.login;
        }

        public String getPasswordUser()
        {
            return this.password;
        }

    }
}
