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
   public class GroupRemovalTests : AuthTestBase
    {
        

        [Test]
        public void  GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(1);
       
            List<GroupData> newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);
            Trace.WriteLine("old groups count: " + oldGroups.Count, "new groups count: " + newGroups.Count);
        }    
    }
}
