﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTest : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            System.Console.Out.Write(app.Contacts.GetNumberOfSearchResults());        
        }
    }
}
