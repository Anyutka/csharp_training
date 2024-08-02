using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string firstName, string secondName)
        {
            Name = firstName;
            Surname = secondName;
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
            return Name == other.Name &&
           Surname == other.Surname;

        }
        public override int GetHashCode()

        {
            return Name.GetHashCode() + Surname.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + ", surname=" + Surname;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (Surname.Equals(other.Surname))
            {
                return Name.CompareTo(other.Name);
            }
            else
            {
                return Surname.CompareTo(other.Surname);
            }

        }
        public string Name { get; set; }

        public string Middle { get; set; }

        public string Surname { get; set; }
        public string Nickname { get; set; }


        public string Title { get; set; }

        public string Company { get; set; }


        public string Address { get; set; }

        public string TelHome { get; set; }

        public string TelMobile { get; set; }

        public string TelWork { get; set; }

        public string TelFax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }
        public string Id { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (Cleanup(TelHome) + Cleanup(TelMobile) + Cleanup(TelWork)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string Cleanup(string phone)
        {
            if (phone == null || phone=="")
            {
                return "";
            }
            //return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        public string AllEmails

        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Cleanup(Email) + Cleanup(Email2) + Cleanup(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }
    }
}
