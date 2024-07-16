﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
   public class GroupRemovalTests : AuthTestBase
    {
        

        [Test]
        public void  GroupRemovalTest()
        {
            GroupData group = new GroupData("zzz");
            group.Header = "zzz";
            group.Footer = "zzz";

            app.Groups.VerifyGroupPresent(group);
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);
            Trace.WriteLine("old groups count: " + oldGroups, "new groups count: " + newGroups);
        }    
    }
}
