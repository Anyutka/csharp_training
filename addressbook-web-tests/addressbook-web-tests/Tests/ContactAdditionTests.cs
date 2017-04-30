using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactAdditionTests : TestBase
    {


        [Test]
        public void ContactAdditionTest()
        {
            
            ContactData contact = new ContactData("Alisa");
            contact.Lastname = "Moonny";
            app.Contacts
                .InitNewContactAddition()
                .FillContactForm(contact)
                .SubmitNewContactAdditionHomePage();
           
        }

    }
}    
