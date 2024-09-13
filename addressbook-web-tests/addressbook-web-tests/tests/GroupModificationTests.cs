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
    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[0];

            GroupData oldData = toBeModified;


            app.Groups.Modify(toBeModified, groupnewData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            toBeModified.Name = groupnewData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupp in newGroups)
                {
                if (groupp.Id == toBeModified.Id)
                {
                    Assert.AreEqual( groupnewData.Name, groupp.Name);
                }                   
            }
            Trace.WriteLine("old groups count: " + oldGroups, "new groups count: " + newGroups);
        }
    }
}
