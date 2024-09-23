using NUnit.Framework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;
using System.IO;
using OpenQA.Selenium;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
    {
       public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(15))
                {
                    Name = GenerateRandomString(30),
                    Surname = GenerateRandomString(30),
                });
            }
            contacts.Add(new ContactData("")
            {
                Name = "",
                Surname = "",
            });

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0])
                {
                    Name = parts[1],
                    Surname = parts[2]

                });
                    
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
          return JsonConvert.DeserializeObject<List<ContactData>>(
               File.ReadAllText(@"contacts.json")); 
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            //ContactData contact = new ContactData("Bulldog", "Non-sporting dog");
            //contact.Name = ;
            contact.Middle = "English";
            //contact.Surname =;
            contact.Nickname = "bulyk";
            contact.Title = "At home";
            contact.Company = "Dog-bulldog";
            contact.Address = "Trees street 5-11";
            contact.TelHome = "555555";
            contact.TelMobile = "1111111";
            contact.TelWork = "2222222";
            contact.TelFax = "3333333";
            contact.Email = "bulyk@dogik.com";
            contact.Email2 = "bulyk1@dogik.com";
            contact.Email3 = "bulyk2@dogik.com";
            contact.Homepage = "http://all.bulldogs.com";
            
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Create(contact);
            
            Assert.AreEqual(oldContacts.Count+1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = ContactData.GetAll();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            Trace.WriteLine("old contacts count: " + oldContacts,
                "new contacts count: " + newContacts);
        }
        
        [Test]
        public void BadNameContactCreationTest()
        {
            ContactData contact = new ContactData("a'''a", "Non-sporting dog");
            //contact.Name = "a'''a";
            contact.Middle = "English";
           // contact.Surname = "Non-sporting dog";
            contact.Nickname = "bulyk";
            contact.Title = "At home";
            contact.Company = "Dog-bulldog";
            contact.Address = "Trees street 5-11";
            contact.TelHome = "555555";
            contact.TelMobile = "1111111";
            contact.TelWork = "2222222";
            contact.TelFax = "3333333";
            contact.Email = "bulyk@dogik.com";
            contact.Email2 = "bulyk1@dogik.com";
            contact.Email3 = "bulyk2@dogik.com";
            contact.Homepage = "http://all.bulldogs.com";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            Trace.WriteLine("old contacts count: " + oldContacts,
                "new contacts count: " + newContacts);

        }
        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUi = app.Contacts.GetContactList();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;

            List<ContactData> fromDb = ContactData.GetAll();

            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }

        
    }
}
