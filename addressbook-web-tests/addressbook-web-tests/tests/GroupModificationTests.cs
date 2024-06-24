﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData groupnewData = new GroupData("zzz");
            groupnewData.Header = "ttt";
            groupnewData.Footer = "qqq";

            app.Groups.Modify(1, groupnewData);

        }
    }
}
