﻿using System;
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
    public class ContactModificationTests : ContactTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("Bulldog", "Non-sporting dog");
            //contact.Name = "Bulldog";
            contact.Middle = "English";
            //contact.Surname = "Non-sporting dog";
            contact.Nickname = "bulyk";

            ContactData contactnewData = new ContactData("Labrador", "Sporting");
            //contactnewData.Name = "Labrador";
            contactnewData.Middle = null;
           // contactnewData.Surname = "Sporting";
            contactnewData.Nickname = "pointic";
            contactnewData.Title = "At office";
            contactnewData.Company = "Dog-Shorthaired";
            contactnewData.Address = "Bushes street 5-11";
            contactnewData.TelHome = "4444444";
            contactnewData.TelMobile = "9999999";
            contactnewData.TelWork = "7777777";
            contactnewData.TelFax = "6666666";
            contactnewData.Email = "pointic@dogik.com";
            contactnewData.Email2 = "pointic1@dogik.com";
            contactnewData.Email3 = "pointic2@dogik.com";
            contactnewData.Homepage = "http://all.pointers.com";
            
            app.Contacts.VerifyContactPresent(contact);

            List<ContactData> oldContacts = ContactData.GetAll();

            ContactData toBeModified = oldContacts[0];

            ContactData oldData = toBeModified;
            
            app.Contacts.Modify(toBeModified, contactnewData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            
            List<ContactData> newContacts = ContactData.GetAll();

            toBeModified.Surname = contactnewData.Surname;
            toBeModified.Name = contactnewData.Name;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contactt in newContacts)
            {
                if (contactt.Id == toBeModified.Id)
                {
                    Assert.AreEqual(contactnewData.Surname, contactt.Surname);
                    Assert.AreEqual(contactnewData.Name, contactt.Name);
                }
            }
            Trace.WriteLine("old counts count: " + oldContacts, "new contacts count: " + newContacts);
        }
        
    }
}
