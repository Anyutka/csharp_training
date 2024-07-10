﻿using System;
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

            app.Groups.Modify(1, groupnewData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            Trace.WriteLine("old groups count: " + oldGroups.Count, "new groups count: " + newGroups.Count);
        }
    }
}
