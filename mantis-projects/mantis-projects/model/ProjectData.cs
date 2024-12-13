using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mantis_projects
{
   
    public class ProjectData 
    {

        private string name;
        private string description="";

        public ProjectData(string name)
        {
            this.name = name;            
        }
       

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
               name = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        
        
        
        
        
        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;

        }
        public override int GetHashCode()

        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name=" + Name + "\n description= " + Description;
        }
        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }       
    }
}