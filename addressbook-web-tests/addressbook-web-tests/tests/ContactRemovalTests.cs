using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            ContactData contact = new ContactData();
            contact.Name = "Bulldog";
            contact.Middle = "English";
            contact.Surname = "Non-sporting dog";
            contact.Nickname = "bulyk";
            app.Contacts.VerifyContactPresent(contact);

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(1);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count -1, newContacts.Count);
            Trace.WriteLine("old contacts count: " + oldContacts.Count,
                "new contacts count: " + newContacts.Count);

        }

    }
}
