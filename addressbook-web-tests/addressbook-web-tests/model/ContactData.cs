using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class ContactData : IEquatable<ContactData>, IComparable<ContactData> 
    {               

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
            
            if(Surname.Equals(other.Surname))
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
        
        public string Telhome { get; set; }
       
        public string Telmobile { get; set; }
        
        public string Telwork { get; set; }
        
        public string Telfax { get; set; }
        
        public string Email { get; set; }
        
        public string Email2 { get; set; }
        
        public string Email3 { get; set; }
        
        public string Homepage { get; set; }
        public string Id { get; set; }

    }
    }
