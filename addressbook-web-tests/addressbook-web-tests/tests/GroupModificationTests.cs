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
            groupnewData.Footer = null;
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            //prepare test situation
            app.Groups.CreateGroup(group);
            //action
            app.Groups.Modify(1, groupnewData);

            //verification
            //Assert.IsTrue(IsGroupPresentIn(group));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            Trace.WriteLine("old groups count: " + oldGroups.Count, "new groups count: " + newGroups.Count);
        }
    }
}
