using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Bulldog", "Non-sporting dog");
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
            
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);
            
            Assert.AreEqual(oldContacts.Count+1, app.Contacts.GetContactCount());


            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            Trace.WriteLine("old contacts count: " + oldContacts,
                "new contacts count: " + newContacts);

        }
        [Test]
        public void EmptyContactCreatinonTest()
        {
            
            ContactData contact = new ContactData("", "");
            //contact.Name = "";
            contact.Middle = "";
            //contact.Surname = "";
            contact.Nickname = "";
            contact.Title = "";
            contact.Company = "";
            contact.Address = "";
            contact.TelHome = "";
            contact.TelMobile = "";
            contact.TelWork = "";
            contact.TelFax = "";
            contact.Email = "";
            contact.Email2 = "";
            contact.Email3 = "";
            contact.Homepage = "";           
            

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
    }
}
