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
        private string allDetails;
        private string anniversary;
        private string birthday;
        

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

        public string BDay { get; set; }
        public string BMonth { get; set; }
        public string BYear { get; set; }
        public string ADay { get; set; }
        public string AMonth { get; set; }
        public string AYear { get; set; }


        public string Birthday
        {
            get
            {
                if (birthday != null)
                {
                    return birthday;
                }
                else
                {
                    //return BDay + "." + " " + BMonth + " " + BYear;
                    return $"{BDay}. {BMonth} {BYear}";
                    //return $"13. nov 2012";
                }
            }
            set
            {
                birthday = value;
            }
        }
        public string Anniversary
        {
            get
            {
                if (anniversary != null)
                {
                    return anniversary;
                }
                else
                {
                    return ADay + "." + " " + AMonth + " " + AYear;
                }
            }
            set
            {
                anniversary = value;
            }
        }

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
       
        
        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    return GetAllDetails();
                }
            }
            set
            {
                allDetails = value;
            }
        }
        public string GetAllDetails()
        {
            var nameList = new[] { Name, Middle, Surname }.Where(x => !string.IsNullOrEmpty(x));
            string names = string.Join(" ", nameList);

            // "1Labrador English Sporting\r\npointic\r\nAt office\r\nDog-Shorthaired\r\nBushes street 5-11\r\n\r\nH: 4444444\r\nM: 9999999\r\nW: 7777777\r\nF: 6666666\r\n\r\npointic@dogik.com\r\npointic1@dogik.com\r\npointic2@dogik.com\r\nHomepage:\r\nall.pointers.com\r\n\r\nBirthday 14. September 2021 (2)\r\nAnniversary 11. July 2022 (2)"
            return $"{names}\r\n{Nickname}\r\n{Title}\r\n{Company}\r\n{Address}\r\n\r\nH: {TelHome}\r\nM: {TelMobile}\r\nW: {TelWork}\r\nF: {TelFax}\r\n\r\n{Email}\r\n{Email2}\r\n{Email3}\r\nHomepage:\r\n{Homepage.Replace("http://","")}\r\n\r\nBirthday {Birthday} (2)\r\nAnniversary {Anniversary} (2)";
        }
               
    }
}
