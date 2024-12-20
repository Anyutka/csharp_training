﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_projects
{
    public class TestBase
    {              
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
           app = new ApplicationManager();
            app.Navigator.OpenLoginPage();
            app.Auth.Login(new AccountData("administrator", "root"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }             
}
