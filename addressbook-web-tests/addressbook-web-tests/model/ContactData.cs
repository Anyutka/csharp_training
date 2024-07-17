using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class ContactData : IEquatable<ContactData>, IComparable<ContactData> 
    {
        
        public string Name ="";
        public string Middle =""; // без get set 
        public string Surname = "";
        private string nickname = "";
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
        

        public ContactData()
        {
        }
        
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name  == other.Name &&
           Surname == other.Surname;  
            
        }
        public override int GetHashCode()

        {
            return Name.GetHashCode() + Surname.GetHashCode();
        }
        
        public override string ToString()
        {
            return "name=" +Name+ ", surname=" +Surname;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name) + Surname.CompareTo(other.Surname);
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
