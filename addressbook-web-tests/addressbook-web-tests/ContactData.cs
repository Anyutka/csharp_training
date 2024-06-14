using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string nickname;
        private string title = "";
        private string company = "";
        private string address = "";
        private string telhome = "";
        private string telmobile = "";
        private string telwork = "";
        private string telfax = "";
        private string email = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        public ContactData(string nickname)
        {
            this.nickname = nickname;
        }
        
        public string Nickname
        {
            get
            {
                return nickname; //возвращает
            }
            set
            {
                nickname = value; //присваивает
            }
        }

        public string Title
        {
            get
            {
                return title; //возвращает
            }
            set
            {
                title = value; //присваивает
            }
        }
        public string Company
        {
            get
            {
                return company; //возвращает
            }
            set
            {
                company = value; //присваивает
            }
        }

        public string Address
        {
            get
            {
                return address; //возвращает
            }
            set
            {
                address = value; //присваивает
            }
        }
        public string Telhome
        {
            get
            {
                return telhome; //возвращает
            }
            set
            {
                telhome = value; //присваивает
            }
        }
        public string Telmobile
        {
            get
            {
                return telmobile; //возвращает
            }
            set
            {
                telmobile = value; //присваивает
            }
        }
        public string Telwork
        {
            get
            {
                return telwork; //возвращает
            }
            set
            {
                telwork = value; //присваивает
            }
        }
        public string Telfax
        {
            get
            {
                return telfax; //возвращает
            }
            set
            {
                telfax = value; //присваивает
            }
        }
        public string Email
        {
            get
            {
                return email; //возвращает
            }
            set
            {
                email = value; //присваивает
            }
        }
        public string Email2
        {
            get
            {
                return email2; //возвращает
            }
            set
            {
                email2 = value; //присваивает
            }
        }
        public string Email3
        {
            get
            {
                return email3; //возвращает
            }
            set
            {
                email3 = value; //присваивает
            }
        }
        public string Homepage
        {
            get
            {
                return homepage; //возвращает
            }
            set
            {
                homepage = value; //присваивает
            }
        }

    }
    }
