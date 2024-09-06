using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using WebAddressbookTests;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace addressbook_contact_test_data_generators
{
    class ContactProgram
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count= Convert.ToInt32(args[1]);          
            StreamWriter writer = new StreamWriter(args[2]);
            string format = args[3];

            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                {
                    Name = TestBase.GenerateRandomString(10),
                    Surname = TestBase.GenerateRandomString(10)
                });
            }
                if (format == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }  
                else if(format == "xml")                   
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }               
            
            writer.Close();
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer) 
        {
            foreach(ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    contact.Name, contact.Surname, contact.Middle));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer) 
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));                        
        }


    }
}
