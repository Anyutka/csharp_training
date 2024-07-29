using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V123.FedCm;

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
            ContactData oldData = oldContacts[3];
            
            app.Contacts.Modify(3, contactnewData);
            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            
            List<ContactData> newContacts = app.Contacts.GetContactList();
           
            oldContacts[3].Surname = contactnewData.Surname;
            oldContacts[3].Name = contactnewData.Name;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contactt in newContacts)
            {
                if (contactt.Id == oldData.Id)
                {
                    Assert.AreEqual(contactnewData.Surname, contactt.Surname);
                    Assert.AreEqual(contactnewData.Name, contactt.Name);
                }
            }
            Trace.WriteLine("old counts count: " + oldContacts, "new contacts count: " + newContacts);
        }
        
    }
}
