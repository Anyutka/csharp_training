using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace mantis_projects
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        
        [Test]
        public void ProjectCreationTest()
        {
            
            app.Management.GoToManagementPane();
            app.Management.GoToProjectManagement();                        
            ProjectData project=new ProjectData("projectone");
            project.Description = "testing one project";
            
            app.ProjectManagement.CreateProject(project); 
            app.Navigator.ReturnToProjectsPage();

        }             
    }
}

