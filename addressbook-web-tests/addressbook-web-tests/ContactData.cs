using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class ContactData
    {
        private string firstname;
        private string lastname = "";
        private string middlename = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email = "";
        private string email2= "";
        private string email3 = "";
        private string homepage = "";
        private string address2 = "";
        private string phone = "";
        private string notes = "";



        public ContactData(string firstname)

        {
            this.firstname = firstname;
        }
        
        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }
        
        
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }
            set
            {
                middlename = value;
            }
        }
    }
}


  
