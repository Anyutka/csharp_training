using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {       
        
        [Test]
        public void GroupModificationTest()
        {
            GroupData groupnewData = new GroupData("kkk");
            groupnewData.Header = null;
            groupnewData.Footer = "kkk";
            GroupData group = new GroupData("zzz");
            group.Header = "zzz";
            group.Footer = "zzz";           
            
            app.Groups.VerifyGroupPresent(group);

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Modify(0, groupnewData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = groupnewData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            Trace.WriteLine("old groups count: " + oldGroups, "new groups count: " + newGroups);
        }
    }
}
