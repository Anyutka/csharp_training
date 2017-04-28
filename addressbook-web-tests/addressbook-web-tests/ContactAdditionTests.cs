using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactAdditionTests : TestBase
    {


        [Test]
        public void ContactAdditionTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewContactAddition();
            ContactData contact = new ContactData("Alisa");
            contact.Lastname = "Moonny";
            FillContactForm(contact);
            SubmitNewContactAdditionHomePage();
            driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}    
