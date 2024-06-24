using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contactnewData = new ContactData();
            contactnewData.Name = "Pointer Shorthaired";
            contactnewData.Middle = "German";
            contactnewData.Surname = "Sporting dog";
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
            app.Contacts.Modify(1, contactnewData);
        }
    }
}
