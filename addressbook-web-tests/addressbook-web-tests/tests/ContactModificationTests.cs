using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData();
            contact.Name = "Bulldog";
            contact.Middle = "English";
            contact.Surname = "Non-sporting dog";
            contact.Nickname = "bulyk";

            ContactData contactnewData = new ContactData();
            contactnewData.Name = "Labrador";
            contactnewData.Middle = null;
            contactnewData.Surname = "Sporting";
            contactnewData.Nickname = "pointic";
            contactnewData.Title = "At office";
            contactnewData.Company = "Dog-Shorthaired";
            contactnewData.Address = "Bushes street 5-11";
            contactnewData.Telhome = "4444444";
            contactnewData.Telmobile = "9999999";
            contactnewData.Telwork = "7777777";
            contactnewData.Telfax = "6666666";
            contactnewData.Email = "pointic@dogik.com";
            contactnewData.Email2 = "pointic1@dogik.com";
            contactnewData.Email3 = "pointic2@dogik.com";
            contactnewData.Homepage = "http://all.pointers.com";
            
            app.Contacts.VerifyContactPresent(contact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(0, contactnewData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
           
            oldContacts[0].Surname = contactnewData.Surname;
            oldContacts[0].Name = contactnewData.Name;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            Trace.WriteLine("old counts count: " + oldContacts, "new contacts count: " + newContacts);
        }

        
    }
}
