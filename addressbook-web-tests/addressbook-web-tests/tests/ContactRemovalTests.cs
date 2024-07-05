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
            

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(1);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count -1, newContacts.Count);
            Trace.WriteLine("old contacts count: " + oldContacts.Count,
                "new contacts count: " + newContacts.Count);

        }

    }
}
