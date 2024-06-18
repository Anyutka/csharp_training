using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreatinonTest()
        {

            ContactData contact = new ContactData("bulyk");
            contact.Title = "At home";
            contact.Company = "Dog-bulldog";
            contact.Address = "Trees street 5-11";
            contact.Telhome = "555555";
            contact.Telmobile = "1111111";
            contact.Telwork = "2222222";
            contact.Telfax = "3333333";
            contact.Email = "bulyk@dogik.com";
            contact.Email2 = "bulyk1@dogik.com";
            contact.Email3 = "bulyk2@dogik.com";
            contact.Homepage = "http://all.bulldogs.com";
            app.ContactHelper.EnterContactNMS("Bulldog", "English", "Non-sporting dog");
            app.ContactHelper.Create(contact);
        }
        [Test]
        public void EmptyContactCreatinonTest()
        {

            ContactData contact = new ContactData("");
            contact.Title = " ";
            contact.Company = " ";
            contact.Address = " ";
            contact.Telhome = " ";
            contact.Telmobile = " ";
            contact.Telwork = " ";
            contact.Telfax = " ";
            contact.Email = " ";
            contact.Email2 = " ";
            contact.Email3 = " ";
            contact.Homepage = " ";
            app.ContactHelper.EnterContactNMS("", "", "");
            app.ContactHelper.Create(contact);
        }
    }
}
