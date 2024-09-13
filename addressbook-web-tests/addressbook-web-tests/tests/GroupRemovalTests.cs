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
   public class GroupRemovalTests : GroupTestBase
    {
        

        [Test]
        public void  GroupRemovalTest()
        {
            GroupData group = new GroupData("zzz");
            group.Header = "zzz";
            group.Footer = "zzz";

            app.Groups.VerifyGroupPresent(group);
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            
            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupp in newGroups) 
            {
                Assert.AreNotEqual(groupp.Id, toBeRemoved.Id);
            }
            Trace.WriteLine("old groups count: " + oldGroups, "new groups count: " + newGroups);
        }    
    }
}
