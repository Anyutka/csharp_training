using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Threading;

namespace mantis_projects
{

    [TestFixture]
    public class ProjectRemovalTests : TestBase
    {

        [Test]
        public void ProjectRemovalTest()
        {
            
            app.Management.GoToManagementPane();
            app.Management.GoToProjectManagement();

            app.ProjectManagement.Remove(1);
            
            app.Navigator.ReturnToProjectsPage();
        }
    }
}


