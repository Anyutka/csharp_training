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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.ContactHelper.EnterContactNMS("Bulldog", "English", "Non-sporting dog");
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
            app.ContactHelper.EnterContactData(contact);
            app.ContactHelper.SelectContactDatesGroup();
            app.ContactHelper.SubmitContact();
            app.ContactHelper.ReturnToContactsPage();
            
        }

        
        

        

        

        

        

       
       
        
        
    }
}
