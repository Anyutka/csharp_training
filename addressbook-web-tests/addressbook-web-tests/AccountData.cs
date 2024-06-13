using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
     class AccountData
    {
        private string username;
        private string password;
        public AccountData(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string Username
        {
            get
            {
                return username; //возвращает
            }
            set
            {
                username = value; //присваивает
            }
        }

        public string Password
        {
            get
            {
                return password; //возвращает
            }
            set
            {
                password = value; //присваивает
            }
        }
    }
}
