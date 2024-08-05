using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
           ContactData fromTable= app.Contacts.GetContactInformationFromTable(1);
           ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(1);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }
        [Test]
        public void TestDetailsContactInformation()
        {
            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(1);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(1);
            Assert.AreEqual(fromForm.AllDetails, fromDetails.AllDetails);

            //Assert.AreEqual(fromDetails.Address, fromForm.Address);
            //Assert.AreEqual(fromDetails.AllPhones, fromForm.AllPhones);
            //Assert.AreEqual(fromDetails.AllEmails, fromForm.AllEmails);
        }
    }
}
