using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeletingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestDeletingContactFromGroup()
        {            
            GroupData group = GroupData.GetAll()[25];
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = oldList[0];
            
            app.Contacts.DeleteContactFromGroup(contact, group);
                                  
            List<ContactData> newList = group.GetContacts();

            oldList.RemoveAt(0);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
           
            Trace.WriteLine("new contacts count: " + newList.Count);

        }
    }

    
}
