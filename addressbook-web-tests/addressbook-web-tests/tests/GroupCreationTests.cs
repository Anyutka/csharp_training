using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0;i<5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(15))
                {
                    Header = GenerateRandomString(30),
                    Footer = GenerateRandomString(30)
                });
            }
            groups.Add(new GroupData("")
            {
                Header = "",
                Footer = ""
            });

            return groups;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        
        public void GroupCreationTest(GroupData group)
        {           
             
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);            
            
           
            Assert.AreEqual(oldGroups.Count +1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
           Assert.AreEqual(oldGroups, newGroups);
           Trace.WriteLine("old groups count: " + oldGroups, "new groups count: " + newGroups);
        }
        
        
        [Test]
        public void BadNameGroupCreationTest()
        {

            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            Trace.WriteLine("old groups count: " + oldGroups, "new groups count: " + newGroups);
        }
    }
    }

