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
    public class ContactRemovalTests : AuthTestBase
    {
        
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("Bulldog", "Non-sporting dog");
            //contact.Name = "Bulldog";
            contact.Middle = "English";
            //contact.Surname = "Non-sporting dog";
            contact.Nickname = "bulyk";
            app.Contacts.VerifyContactPresent(contact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(3);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            ContactData toBeRemoved = oldContacts[3];
            oldContacts.RemoveAt(3);
            Assert.AreEqual(oldContacts, newContacts);

            
            foreach (ContactData contactt in newContacts)
            {
                Assert.AreNotEqual(contactt.Id, toBeRemoved.Id);
            }
            

            Trace.WriteLine("old contacts count: " + oldContacts,
                "new contacts count: " + newContacts);

        }

    }
}
